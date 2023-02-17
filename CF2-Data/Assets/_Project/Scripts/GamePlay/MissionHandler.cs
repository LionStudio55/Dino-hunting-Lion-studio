using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MissionHandler : MonoBehaviour
{
    public static MissionHandler ins;
    int animalsCheck = 0;
    public int[] isallocated;//enemy position check

    public GameObject Targets_Root, Player_Root;
    public float RotationX, RotationY;

    public int Total_TargetCount;

    public GameObject MainPlayer;

    
    public int[] TargetCount;

    public GameObject[] Targets_Position_Holder, Player_PositionHolder;

    public GameObject[] TargetsObject;

    public GameObject[] RandomPostions;

    public GameObject[] PlayerPostions;

    int EnvironmentNo, PlayerPosNo;
    public GameObject[] EnableObjects,DisableObjects;


    [Header("Car moving Objects")]
    public GameObject Jeeb_obj;
    public bool Playermove;
    void Awake()
    {
        ins = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        ins = this;
        int TempIndex = 0;
        MainPlayer = data_get.inst.MainPlayer;


        AnimalCounter();

        if (Targets_Root != null)
        {
            AssignedTarget_RandomPostion(TempIndex);//Assigned Target Random Position
        }
        AssignedPlayer_RandomPostion(TempIndex);//Assigned Player Random Position
        if (Targets_Root != null)
        {
            Target_Instantiater();
        }

        foreach(GameObject objc in EnableObjects)
        {
            objc.SetActive(true);
        }

        foreach (GameObject objc in DisableObjects)
        {
            objc.SetActive(false);
        }

        playermove_withjeep();
    }

    public void AnimalCounter()
    {
      
        UI_Manager.instance.Animalbarstatus(Total_TargetCount);
        complete();
    }


    public void complete()
    {
        if (Total_TargetCount <= DamageManager.KilledAnimal)
        {
            UI_Manager.instance.Complete_level();
        }
        //if (Constants.Getprefs(Constants.lastselectedMode) == 2)
        //{
        //    if (Total_TargetCount / 2 == DamageManager.KilledAnimal)
        //    {
        //        AdloadingOn();
        //    }
        //}
    }

  
    void playermove_withjeep()
    {
        if(Playermove)
        {
            MainPlayer.transform.parent = Jeeb_obj.transform;
            MainPlayer.GetComponent<NavMeshObstacle>().enabled = false;
        }
    }

    public void Target_Instantiater()
    {
        if (Total_TargetCount <= 0)
            return;

        int m = 0,n=0;

        for (int k = 0; k < TargetCount.Length; k++)
        {
            while(m < TargetCount[n])
            {
                //Debug.Log("k   " + k + "    m   " + m + "    n    " + n);
                EnemyGenerator(k);
                m++;
            }
            n++;
            m = 0;
            //Debug.Log("k   " + k + "    n    " + n);
        }
    }

    //Assigned Target Positions
    public void AssignedTarget_RandomPostion(int TempIndex)
    {

        RandomPostions = new GameObject[Targets_Root.transform.childCount];

        for (int j = 0; j < RandomPostions.Length; j++)
        {
            RandomPostions[j] = Targets_Root.transform.GetChild(j).gameObject;
        }

        isallocated = new int[RandomPostions.Length];



    }

    public void AssignedPlayer_RandomPostion(int TempIndex)
    {

        PlayerPostions = new GameObject[Player_Root.transform.childCount];


        for (int j = 0; j < PlayerPostions.Length; j++)
        {
            PlayerPostions[j] = Player_Root.transform.GetChild(j).gameObject;

        }

        MainPlayer.transform.position = PlayerPostions[0].transform.position;
        MainPlayer.transform.rotation = PlayerPostions[0].transform.rotation;
        //UI_Manager.instance.sm_look.enabled = false;
        //UI_Manager.instance.sm_look.transform.localRotation = PlayerPostions[0].transform.localRotation;
        UI_Manager.instance.sm_look.rotationX = RotationX/*PlayerPostions[0].transform.localRotation.eulerAngles.x*/;
        UI_Manager.instance.sm_look.rotationY = RotationY/*PlayerPostions[0].transform.localRotation.eulerAngles.y*/;
        //UI_Manager.instance.sm_look.enabled = true;
        print("Player Position Assign");
        if (Constants.Getprefs(Constants.lastselectedMode) == 2)
        {
            data_get.inst.Jeep.transform.position = PlayerPostions[1].transform.position;
            data_get.inst.Jeep.transform.rotation = PlayerPostions[1].transform.rotation;
        }

    }


    public void EnvironmentGenerator(int TempIndex)
    {
        Instantiate(TargetsObject[TempIndex], RandomPostions[TempIndex].transform.position, RandomPostions[TempIndex].transform.rotation);
    }

    public void ActiveMainPlayer(GameObject player)
    {
        MainPlayer = player;


        MainPlayer.transform.position = PlayerPostions[PlayerPosNo].transform.position;
        MainPlayer.transform.rotation = PlayerPostions[PlayerPosNo].transform.rotation;
        MainPlayer.SetActive(true);

        //GlobalScripts.GameStarted = true;
        //GlobalScripts.timeOver = false;

    }

    //Enemy Prefeb  Instantiater w.r.t Environment
    bool isExist;

    public void EnemyGenerator(int TargetIndex)
    {
        bool tempallocate = false;

        //int TempIndex = Random.Range(0, RandomPostions.Length);
        int TempIndex = animalsCheck;

        //int TempIndex = RandomPostions.Length - 1;
       // print(TempIndex);


        if (isallocated[TempIndex] == 0)
        {
            isallocated[TempIndex] = 1;
            tempallocate = true;
        }
        else
        {
            TempIndex += 1;
            print(TempIndex);
            for (int k = TempIndex; k < RandomPostions.Length; k++)
            {
                if (isallocated[k] == 0)
                {
                    isallocated[k] = 1;

                    TempIndex = k;
                    tempallocate = true;
                    break;
                }
            }

            if (!tempallocate)
            {
                for (int k = TempIndex; k < 0; k--)
                {
                    if (isallocated[k] == 0)
                    {
                        isallocated[k] = 1;

                        TempIndex = k;
                        tempallocate = true;
                        break;
                    }
                }
            }


        }
        if (!tempallocate)
        {

            EnemyGenerator(TargetIndex);
        }
        else
        {
            //Debug.Log("TargetIndex    "+ TargetIndex + "     TempIndex     " + TempIndex);
            Instantiate(TargetsObject[TargetIndex], RandomPostions[TempIndex].transform.position, RandomPostions[TempIndex].transform.rotation);

            animalsCheck++;

        }




    }

}
