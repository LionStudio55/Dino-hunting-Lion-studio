using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inapp_autooff : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        Invoke("off_this_obj", 4f);   
    }

    void off_this_obj()
    {
     
        this.gameObject.SetActive(false);
    }
}
