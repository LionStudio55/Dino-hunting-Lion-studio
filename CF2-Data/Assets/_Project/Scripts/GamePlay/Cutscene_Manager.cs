using UnityEngine;

public class Cutscene_Manager : MonoBehaviour
{
    public GameObject[] Cutscnes;
    //public GameObject[] True_objects;

    public GameObject Env, ammotext, ammotext1;
    public GameObject[] Thirdmodedata;

    private void Awake()
    {
        // Instantiate(Env);
        Env = Instantiate(Resources.Load("env 1", typeof(GameObject))) as GameObject;
    }
    public int modeno;
    public int levelno;
    public bool setmode_level;
    private void OnEnable()
    {


        Time.timeScale = 1.0f;
        if (Constants.Getprefs(Constants.lastselectedMode) == 2)
        {
            data_get.inst.FreemodeStart();
            //data_get.inst.Jeep.SetActive(true);
            //Timer.timemanager.stoptime();
            //data_get.inst.Animalspawnersystem.SetActive(true);
            //for (int a = 0; a < UI_Manager.instance.safarimode_buttons.Length; a++)
            //{
            //    UI_Manager.instance.safarimode_buttons[a].SetActive(false);
            //}
            //for (int i = 0; i < True_objects.Length; i++)
            //{
            //    True_objects[i].SetActive(true);
            //}
            //UI_Manager.instance.OnObjectiveOk();
           // LevelsHandler.instance.ins_data();
        }
        
        else
        {
            for (int cutscne = 0; cutscne < Cutscnes.Length; cutscne++)
            {
                Cutscnes[cutscne].SetActive(false);
            }
            Cutscnes[Constants.Getprefs(Constants.lastselectedMode)].SetActive(true);
            if (Constants.Getprefs(Constants.lastselectedMode) == 4)
            {
                data_get.inst.set_statusjoystick();
            }
        }

        Invoke("wait", 1f);


    }

    void wait()
    {
        ammotext.SetActive(false);
        ammotext1.SetActive(false);
    }

    private void startgame()
    {

    }
}
