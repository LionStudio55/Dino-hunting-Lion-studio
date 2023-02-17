using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Cutscene_Hunting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] True_objects;
    public Camera Fps_Player_cam;
    public Text Objective_text;
    public string[] Objective;
    public Material[] skybox_Material;
    public GameObject[] modes;
    public GameObject main_Parent;
    private AudioSource _AudioSource;
    [SerializeField] private string CutscenesLevelsPath;
    private void Awake()
    {
        Application.targetFrameRate = 600;
        if (Objective_text.GetComponent<AudioSource>())
            _AudioSource = Objective_text.GetComponent<AudioSource>();
    }
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        //cutscene_objects[Global_Scripts.CurrLevelIndex].SetActive(true);

        GameObject level = Resources.Load(CutscenesLevelsPath + "Cut" + (Constants.Getprefs(Constants.lastselectedLevel) + 1).ToString()) as GameObject;
        GameObject activeLevel = Instantiate(level);
        activeLevel.transform.SetParent(this.gameObject.transform);
        activeLevel.transform.localPosition = Vector3.zero;
        activeLevel.transform.localRotation = Quaternion.identity;
        activeLevel.SetActive(true);


        //  Objective_text.text = Objective[Constants.Getprefs(Constants.lastselectedLevel)];
        StartCoroutine(typeText());
    }


    public void Play_game()
    {
        for (int i = 0; i < True_objects.Length; i++)
        {
            True_objects[i].SetActive(true);
        }
        Destroy(main_Parent);
    }
    void wait()
    {
        Destroy(main_Parent);
    }
    IEnumerator typeText()
    {
        string str = Objective[Constants.Getprefs(Constants.lastselectedLevel)];
        for (int i = 0; i < Objective[Constants.Getprefs(Constants.lastselectedLevel)].Length; i++)
        {
            if (i != Objective[Constants.Getprefs(Constants.lastselectedLevel)].Length)
            {
                Objective_text.text += Objective[Constants.Getprefs(Constants.lastselectedLevel)][i].ToString();
            }
            _AudioSource.Play();
            yield return new WaitForSeconds(0.08f);
            // Objective_text.text += str[i].ToString();
            _AudioSource.Stop();
        }
        yield return new WaitForSeconds(0.5f);
    }

}
