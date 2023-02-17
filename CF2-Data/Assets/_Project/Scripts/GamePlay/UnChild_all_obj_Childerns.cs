using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnChild_all_obj_Childerns : MonoBehaviour
{
    public GameObject[] all_animals;
    public void OnEnable()
    {
        all_animals = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < all_animals.Length; i++)
        {
            all_animals[i].gameObject.transform.parent = null;
            
            // transform.GetChild(i).parent = null;
        }
        Invoke("wait", 1f);
    }


    void wait()
    {
        for (int i = 0; i < all_animals.Length; i++)
        {
            
            all_animals[i].SetActive(false);
            // transform.GetChild(i).parent = null;
        }
        Invoke("wait1", 0.5f);

    }

    void wait1()
    {
        for (int i = 0; i < all_animals.Length; i++)
        {

            all_animals[i].SetActive(true);
            // transform.GetChild(i).parent = null;
        }
    }
}