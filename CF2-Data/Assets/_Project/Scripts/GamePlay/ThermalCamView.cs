using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermalCamView : MonoBehaviour
{
    public Camera NormalCam;

    void Start()
    {
        
    }

    
    void Update()
    {
        this.gameObject.GetComponent<Camera>().fieldOfView = NormalCam.fieldOfView;
        if(GetComponent<Camera>().fieldOfView<58)
        {
            //GetComponent<Camera>().cullingMask =LayerMask.GetMask("");
           // print("Filed");
        }
    }
}
