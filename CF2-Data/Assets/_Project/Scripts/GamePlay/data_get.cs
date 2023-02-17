using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data_get : MonoBehaviour
{
    public static data_get inst;
    [Header("lights_Data")]
    public GameObject[] Lights_objs;
    [Header("particles_Data")]
    public GameObject[] particles_objs;
    public GameObject MainPlayer;
    public GameObject Night_light;

    

   // public Material jungle_low, Desert_low, Snow_low;


    [Header("TerrainData")]
    public TerrainLayer[] Layer_arrangement;
    public Texture2D[] All_texturess_Forset;
    public Texture2D[] All_texturess_Snow;
    public Texture2D[] All_texturess_Desert;

    [Header("Skyboxes_Data")]
    public Material[] Skyboxes_Materails;

    [Header("Trees_data")]
    public Texture[] tree_textures;
    public Material Tree_material;

    [Header("Script Access")]
    public SmoothMouseLook sm_look;

    //.......................\
    public Material watermat;
    public float speed;

    [Header("Free Mode Data")]

    public GameObject Jeep;
    public GameObject Carcontrols;
    //public GameObject FpsPlayer;
    //public GameObject MainFpsPlayer;
    public GameObject Fpscontrols;
    public GameObject FpsCamera;
    public GameObject CarCamera;
    public Transform Inoutpoint;
    public MapCanvasController map;
    public GameObject Animalspawnersystem;
    public Transform Playerspawnpoint;
    public GameObject[] True_objects;

    [Header("Survival Mode Data")]
    public GameObject Joystick;
    // Start is called before the first frame update
    void Awake()
    {
        inst = this;
        Load_data();
        ResetOffset();
       InvokeRepeating("MoveOffset", 0.1f, 0.01f);
    }

   void Load_data()
    {
         Resources.Load<GameObject>("Mode1_Levels/Lev (1)");
    }


    public void MoveOffset()
    {
        watermat.mainTextureOffset += new Vector2(0, 0.01f * speed);

    }

    public void ResetOffset()
    {
        watermat.mainTextureOffset = new Vector2(0f, 0f);
    }
    int index = 0;
    public void Jeepstatus()
    {
        index++;
        if (index==1)
        {
            Jeep.SetActive(true);
            Carcontrols.SetActive(true);
            CarCamera.SetActive(true);
            Jeep.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            Jeep.GetComponent<Rigidbody>().drag = 0.01f;
            Jeep.GetComponent<RCCData>().PlayerinCar = true;
            Fpscontrols.SetActive(false);
            FpsCamera.SetActive(false);
            MainPlayer.SetActive(false);
            map.playerTransform = Jeep.transform;
           
        }
        else
        {
            index = 0;
            // Jeep.SetActive(false);
            //Physics.IgnoreLayerCollision(0, 9, false);
            Carcontrols.SetActive(false);
            CarCamera.SetActive(false);
            Fpscontrols.SetActive(true);
            Jeep.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            Jeep.GetComponent<Rigidbody>().drag = 5.0f;
            Jeep.GetComponent<RCCData>().PlayerinCar = false;
            FpsCamera.transform.position = Inoutpoint.transform.position;
            FpsCamera.transform.rotation = Inoutpoint.transform.rotation;
            MainPlayer.transform.position = Inoutpoint.transform.position;
            MainPlayer.transform.rotation = Inoutpoint.transform.rotation;
            FpsCamera.SetActive(true);
            MainPlayer.SetActive(true);
            //Invoke(nameof(PlayerOn),3f);
            map.playerTransform = MainPlayer.transform;
           
        }
    }
     private void PlayerOn()
    {
        FpsCamera.SetActive(true);
        MainPlayer.SetActive(true);
    }
    public void FreemodeStart()
    {
        for (int i = 0; i < True_objects.Length; i++)
        {
            True_objects[i].SetActive(true);
        }
        for (int a = 0; a < UI_Manager.instance.safarimode_buttons.Length; a++)
        {
            UI_Manager.instance.safarimode_buttons[a].SetActive(false);
        }
        data_get.inst.Jeep.SetActive(true);
        Timer.timemanager.stoptime();
        data_get.inst.Animalspawnersystem.SetActive(true);
        UI_Manager.instance.OnObjectiveOk();
        MainPlayer.transform.position = Playerspawnpoint.transform.position;
        MainPlayer.transform.rotation = Playerspawnpoint.transform.rotation;
        changetextures(Constants.Getprefs(Constants.lastselectedEnv));
        Change_Skyboxes(Constants.Getprefs(Constants.lastselectedEnv));
    }
    void Change_Skyboxes(int selected)
    {
        switch (selected)
        {
            case 0:
                    RenderSettings.ambientIntensity = 0.45f;
                if (GPULevelChecker.graphicLevelGPUBased == GPULevelChecker.GraphicLevelGPUBased.Low)
                {
                    data_get.inst.particles_objs[selected].SetActive(false);
                }
                break;

            case 1:
                    RenderSettings.ambientIntensity = 0.8f;

                if (GPULevelChecker.graphicLevelGPUBased != GPULevelChecker.GraphicLevelGPUBased.Low)
                {
                    data_get.inst.particles_objs[selected].SetActive(true);
                }
                break;

            case 2:
                    RenderSettings.ambientIntensity = 1.5f;
                if (GPULevelChecker.graphicLevelGPUBased != GPULevelChecker.GraphicLevelGPUBased.Low)
                {
                    data_get.inst.particles_objs[selected].SetActive(false);
                }
                ram_checker.instanceeed.Trees_Parent.SetActive(false);
                ram_checker.instanceeed.Trees_desert.SetActive(true);
                break;

            case 3:
                    RenderSettings.ambientIntensity = 1.2f;

                if (GPULevelChecker.graphicLevelGPUBased != GPULevelChecker.GraphicLevelGPUBased.Low)
                {
                    data_get.inst.particles_objs[selected].SetActive(true);
                }

                ram_checker.instanceeed.Trees_Parent.SetActive(false);
                ram_checker.instanceeed.Trees_desert.SetActive(true);
                break;

            case 4:
                    RenderSettings.ambientIntensity = 1.2f;
                if (GPULevelChecker.graphicLevelGPUBased != GPULevelChecker.GraphicLevelGPUBased.Low)
                {
                    data_get.inst.particles_objs[selected].SetActive(true);
                }
                break;
            case 5:
                    RenderSettings.ambientIntensity = 1.2f;
                if (GPULevelChecker.graphicLevelGPUBased != GPULevelChecker.GraphicLevelGPUBased.Low)
                {
                    data_get.inst.particles_objs[selected].SetActive(true);
                }
                break;

        }
    }
    public void set_statusjoystick()
    {
        Joystick.SetActive(false);
    }

    void changetextures(int No)
    {
        switch (No)
        {
            case 0:
                for (int f = 0; f < data_get.inst.Layer_arrangement.Length; f++)
                {
                    data_get.inst.Layer_arrangement[f].diffuseTexture = data_get.inst.All_texturess_Forset[f];
                }
                data_get.inst.Tree_material.mainTexture = data_get.inst.tree_textures[0];
                break;
            case 1:
                for (int s = 0; s < data_get.inst.Layer_arrangement.Length; s++)
                {
                    data_get.inst.Layer_arrangement[s].diffuseTexture = data_get.inst.All_texturess_Snow[s];
                }
                data_get.inst.Tree_material.mainTexture = data_get.inst.tree_textures[1];

                break;
            case 2:
                for (int d = 0; d < data_get.inst.Layer_arrangement.Length; d++)
                {
                    data_get.inst.Layer_arrangement[d].diffuseTexture = data_get.inst.All_texturess_Desert[d];
                }
                data_get.inst.Tree_material.mainTexture = data_get.inst.tree_textures[2];

                break;
        }

    }
}
