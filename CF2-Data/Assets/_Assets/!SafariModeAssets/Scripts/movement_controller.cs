using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movement_controller : MonoBehaviour
{
    public NavMeshAgent main_jeep;
    public static movement_controller mv_cn;
    public int no_of_animals;
    private void Awake()
    {
        mv_cn = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "jeep")
        {
            main_jeep.speed = 0f;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;

        }
    }

    public void check_movement()
    {
        if (DamageManager.KilledAnimal == no_of_animals)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            main_jeep.speed = 3f;
        }
    }
}
