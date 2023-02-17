using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects_Rotate : MonoBehaviour
{
   public float rotationSpeed = 0.2f;
    public bool use_main;

    void OnMouseDrag()
    {
        float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed*Mathf.Deg2Rad;
       // float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
        // select the axis by which you want to rotate the GameObject
        transform.RotateAround(Vector3.down, XaxisRotation);  
    }
}
