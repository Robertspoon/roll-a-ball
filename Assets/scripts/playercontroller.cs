using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playercontroller : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public  float upwardBounce = 10f;
    public LayerMask groundLayers;
    public SphereCollider col;
    public float maxSpeed = 25.0f;
  
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 16)
        {
            winTextObject.SetActive(true);
        }
    }




    void FixedUpdate()
    {

        Vector3 movement = new Vector3(movementX, 0.0f,movementY);

        rb.AddForce(movement * speed);


        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }
        RelativeCameraMovement();
        
    }

    void RelativeCameraMovement()
    {

        //Get player input
        float playerVerticalInput = Input.GetAxis("Vertical");
        float playerHorizontalInput = Input.GetAxis("Horizontal");

        //Get camera-normalized directional vectors
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;

        //Create direction-relative input vectors
        Vector3 forwardRelativeVerticalInput = playerVerticalInput * forward;
        Vector3 rightRelativeVerticalInput = playerHorizontalInput * right;

        //create camera-relative movement
        Vector3 cameraRelativeMovement = forwardRelativeVerticalInput + rightRelativeVerticalInput;

        transform.Translate(cameraRelativeMovement, Space.World);
    }
   



    void Update()
    {   
        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space)){

        
            rb = gameObject.GetComponent<Rigidbody>();
         
            if (rb != null)
            {
                rb.velocity = new Vector3(0, upwardBounce, 0);
            }
        }

        
       

    }  
    
     

     private bool IsGrounded()
     {
         return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
          col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);       
     }


      private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("pickup"))
       {
          other.gameObject.SetActive(false);
          count = count + 1;

          SetCountText();
       }
       if(other.gameObject.CompareTag("Kill plane 1"))
        {
            rb.Sleep();
            transform.position = new Vector3(-1.64f, 0.5f, 0);
        }
       if(other.gameObject.CompareTag("KillPlane2"))
        {
            rb.Sleep();
            transform.position = new Vector3(25.55f, 5.46f, 21.16f);
        }
        if(other.gameObject.CompareTag("JumpPowerUp"))
        {
            upwardBounce = 20.0f;
        }
        
    }

   
}
