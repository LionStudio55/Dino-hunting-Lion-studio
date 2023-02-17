using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respwan_enemies : MonoBehaviour
{
    public MissionHandler Curr_Mission;
    DamageManager Curr_damage;
    void Start()
    {
        
    }

    private void OnDisable()
    {
        if (FindObjectOfType<MissionHandler>())
        {
            Curr_Mission = FindObjectOfType<MissionHandler>();
            Curr_damage = this.gameObject.GetComponent<DamageManager>();
            if (UI_Manager.instance.stop_respwan == false)
            {
                if (Curr_Mission.Total_TargetCount > 9)
                {
                    if (DamageManager.KilledAnimal > 8)
                    {
                        int no_random = Random.RandomRange(0, 8);
                        Instantiate(Curr_Mission.TargetsObject[0], Curr_Mission.RandomPostions[no_random].transform.position, Curr_Mission.RandomPostions[no_random + 1].transform.rotation);
                        // Instantiate(Curr_Mission.TargetsObject[0], Curr_Mission.RandomPostions[no_random+1].transform.position, Curr_Mission.RandomPostions[no_random+1].transform.rotation);

                    }
                }
            }
        }
       
    }
}
