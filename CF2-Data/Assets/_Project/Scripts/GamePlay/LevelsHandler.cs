using UnityEngine;
using UnityEngine.UI;

public class LevelsHandler : MonoBehaviour
{

    int changeMaterials;
    public GameObject player;
    public static LevelsHandler instance;
    public int[] isallocated;//enemy position check

    public GameObject Targets_Root, Player_Root/*, AllLevels, AllLevels1, AllLevels2, AllLevels3, AllLevels4*/;

    public Transform[] levelparent;
    public int Total_TargetCount;

    GameObject MainPlayer;

    public float[] TimeCount;

    public int[] TargetCount;

    public GameObject[] Targets_Position_Holder, Player_PositionHolder;
    //public Material[] DummyMaterials, StandredMaterial;

    public GameObject[] Animals;
    //public GameObject[] AnimalLungs, AnimalBrain, AnimalHeart;

    public GameObject TargetsObject;

    public GameObject[] RandomPostions;

    public GameObject[] PlayerPostions;
    //public Material bulletMat;
    //public Texture bulletTexBlack;
    //public Texture bulletTexGold;

    int EnvironmentNo, PlayerPosNo;
    // public static int LevelNo;
    public static bool Played_once = false, isReached = false;


    void Awake()
    {

        Application.targetFrameRate = 600;
        //TempinfraTime = infraTime;//Inam
        instance = this;
        Total_TargetCount = TargetCount[Constants.Getprefs(Constants.lastselectedLevel)];
        Timer.timemanager.time = TimeCount[Constants.Getprefs(Constants.lastselectedLevel)];
        SoundsManager.Instance.Stop_PlayingMusic();
        SoundsManager.Instance.PlayMusic_Game(SoundsManager.Instance.gameBG[Random.Range(0, SoundsManager.Instance.gameBG.Length)]);
    }

    public void ins_data()
    {
      
        //if (Constants.Getprefs(Constants.lastselectedMode) == 2)
        //{
        //    data_get.inst.Jeep.SetActive(true);
        //    Timer.timemanager.stoptime();
        //    data_get.inst.Animalspawnersystem.SetActive(true);
        //    for (int a = 0; a < UI_Manager.instance.safarimode_buttons.Length; a++)
        //    {
        //        UI_Manager.instance.safarimode_buttons[a].SetActive(false);
        //    }
        //}
       
            GameObject level = Resources.Load<GameObject>(Constants.folderPath_Prefabs_Levels_Mode + Constants.Getprefs(Constants.lastselectedMode) + "/" + Constants.Getprefs(Constants.lastselectedLevel));
            level = Instantiate(level);
            level.transform.SetParent(levelparent[Constants.Getprefs(Constants.lastselectedMode)].transform);
            level.transform.localPosition = Vector3.zero;
            level.transform.localRotation = Quaternion.identity;
            level.SetActive(true);
        

    }
    // Start is called before the first frame update
    private void Start()
    {
        int TempIndex = 0;
        Constants.FBAnalytic_EventLevel_Started(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode)), Constants.Getprefs(Constants.lastselectedLevel));
    }



    public bool pause_con = false;
    void time_pause(bool condition)
    {
        if (condition == true)
        {
            Time.timeScale = 0.001f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }


    Button infra_btn;
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


    }


    public void EnvironmentGenerator(int TempIndex)
    {

    }

    public void ActiveMainPlayer(GameObject player)
    {
        MainPlayer = player;


        MainPlayer.transform.position = PlayerPostions[PlayerPosNo].transform.position;
        MainPlayer.transform.rotation = PlayerPostions[PlayerPosNo].transform.rotation;
        MainPlayer.SetActive(true);


    }

    //Enemy Prefeb  Instantiater w.r.t Environment
    bool isExist;

    public void EnemyGenerator(int animalCount)
    {
        bool tempallocate = false;

        int TempIndex = Random.Range(0, RandomPostions.Length);



        if (isallocated[TempIndex] == 0)
        {
            isallocated[TempIndex] = 1;
            tempallocate = true;
        }
        else
        {
            TempIndex += 1;
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

            EnemyGenerator(animalCount);
        }
        else
        {
            if (Constants.Getprefs(Constants.lastselectedLevel) == 3)
            {
                Transform temp = Instantiate(TargetsObject.transform.GetChild(0), RandomPostions[TempIndex].transform.position, RandomPostions[TempIndex].transform.rotation) as Transform;
                //  TargetsObject[TempIndex].SetActive(true);
                Animals[animalCount] = temp.gameObject;
            }
            else if (Constants.Getprefs(Constants.lastselectedLevel) == 4)
            {
                Transform temp = Instantiate(TargetsObject.transform.GetChild(1), RandomPostions[TempIndex].transform.position, RandomPostions[TempIndex].transform.rotation) as Transform;
                //  TargetsObject[TempIndex].SetActive(true);
                Animals[animalCount] = temp.gameObject;
            }
            else if (Constants.Getprefs(Constants.lastselectedLevel) == 6)
            {
                Transform temp = Instantiate(TargetsObject.transform.GetChild(7), RandomPostions[TempIndex].transform.position, RandomPostions[TempIndex].transform.rotation) as Transform;
                //  TargetsObject[TempIndex].SetActive(true);
                Animals[animalCount] = temp.gameObject;
            }
            else if (Constants.Getprefs(Constants.lastselectedLevel) == 7)
            {
                Transform temp = Instantiate(TargetsObject.transform.GetChild(6), RandomPostions[TempIndex].transform.position, RandomPostions[TempIndex].transform.rotation) as Transform;
                //  TargetsObject[TempIndex].SetActive(true);
                Animals[animalCount] = temp.gameObject;
            }
            else
            {
                Transform temp = Instantiate(TargetsObject.transform.GetChild(Constants.Getprefs(Constants.lastselectedLevel)), RandomPostions[TempIndex].transform.position, RandomPostions[TempIndex].transform.rotation) as Transform;
                //  TargetsObject[TempIndex].SetActive(true);
                //print("awais:" + Constants.Getprefs(Constants.lastselectedLevel));
                Animals[animalCount] = temp.gameObject;
            }
            //F
            //AnimalLungs = GameObject.FindGameObjectsWithTag("Lungs");
            //AnimalBrain = GameObject.FindGameObjectsWithTag("Brain");
            //AnimalHeart = GameObject.FindGameObjectsWithTag("Heart");
        }
    }
}


