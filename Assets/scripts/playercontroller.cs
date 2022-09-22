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
        if(count >= 13)
        {
            winTextObject.SetActive(true);
        }
    }




    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f,movementY);

        rb.AddForce(movement * speed);
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
       else if(other.gameObject.CompareTag("Kill plane 1"))
        {
            rb.Sleep();
            transform.position = new Vector3(-1.64f, 0.5f, 0);
        }
        else if (other.gameObject.CompareTag("kill plane 2"))
        {
            rb.Sleep();
            transform.position = new Vector3(-1, 3.4f, 21);
        }
        else if (other.gameObject.CompareTag("kill plane 3"))
        {
            rb.Sleep();
            transform.position = new Vector3(10, 3.4f, 20);
        }
        else if (other.gameObject.CompareTag("kill plane 4"))
        {
            rb.Sleep();
            transform.position = new Vector3(24, 5.4f, 20.4f);
        }
    }
}
