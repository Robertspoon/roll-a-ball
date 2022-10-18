using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{

    
    public GameObject player;
    public float angleX;
    public float angleY;
    public float radius = 10;
    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {   
        transform.position = player.transform.position + offset;

        angleX += Input.GetAxis("Mouse X");
        angleY = Mathf.Clamp(angleY -= Input.GetAxis("Mouse Y"), -89, 89);
        radius = Mathf.Clamp(radius -= Input.mouseScrollDelta.y, 1, 50);
        if (angleX > 360)
        {
            angleX -= 360;
        }
        else if (angleX < 0)
        {
            angleX += 360;
        }
        Vector3 orbit = Vector3.forward * radius;
        orbit = Quaternion.Euler(angleY, angleX, 50) * orbit;
        transform.position = player.transform.position + orbit;
        transform.LookAt(player.transform.position);
    }
}
