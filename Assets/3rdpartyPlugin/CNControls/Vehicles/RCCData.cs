using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCCData : MonoBehaviour
{
    public bool PlayerinCar = false;
    //public float speed;
    //public int direction = 1;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Player is Near to Vehicle");
            UI_Manager.instance.CarInoutBtnstatus(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (PlayerinCar)
            return;
        if (other.CompareTag("Player"))
        {
            print("Player is away to Vehicle");
            UI_Manager.instance.CarInoutBtnstatus(false);
        }
    }

}
