using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UI_Manager : MonoBehaviour
{
    public GameObject[] inappPanels;
    public GameObject[] gamePlayPanels;
    public static UI_Manager instance;
    public GameObject Message, successPanel, failedPanel, pausedPanel, loadingPanel, timeUpText, BloodImage, ObjectivePanel, joystick, victoryPanel;
    public GameObject AdloadingBreak;
    public GameObject carcontrols,carinoutbtn;
    public GameObject[] GunsModel, DummyGuns, GunsBolt;
    public GameObject hitText, ScoreText;
    public Text HuntedAnimal;
    public static bool AnimalDected;
    public Text Distance;
    bool loading;
    public Image loadingimage;
    public int[] kills;
    public int[] kills_safarimode;
    public Text ObjectiveText, failedText/*, completetext*/;
    public GameObject CrossHair_Image;
    public Text ZoomText, show_curr_level;
    public static bool onFollowCam;
    public bool stop_respwan;
    public GameObject Tutorail_obj;
    public Camera rfps_pl;
    public static bool shot_org;
    public WeaponBehavior sniper_gun;
    // public Slider zoom_slider;
    public static int ads_call = 0;
    public GameObject Main_Player;
    public GameObject[] safarimode_buttons;
    public SmoothMouseLook sm_look;
    public static int lvls_counters, lvls_counters1, lvls_counters2, lvls_counters3, lvls_counters4;
    void Awake()
    {
        Application.targetFrameRate = 600;
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        if (PlayerPrefs.GetInt("tutorial") == 1)
        {
            Tutorail_obj.SetActive(false);
        }
        //if (Constants.Getprefs(Constants.lastselectedMode) == 1)
        //{
        //    joystick.SetActive(false);
        //}
        if (Constants.Getprefs(Constants.lastselectedMode) == 4)
        {
            for (int a = 0; a < safarimode_buttons.Length; a++)
            {
                safarimode_buttons[a].SetActive(false);
                sm_look.maximumY = 30f;
                sm_look.minimumY = -20f;
                sm_look.sensitivity = 1.5f;
            }
        }
        if (SystemInfo.systemMemorySize < 2500)
        {
            rfps_pl.farClipPlane = 120;
        }
        else
        {
            rfps_pl.farClipPlane = 180;
        }
        show_curr_level.text = (Constants.Getprefs(Constants.lastselectedLevel) + 1).ToString();
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("play_once", 1);
        //ads calling 
        //Smallbanner();
        loadIAD();
    }
    int onetime;
    public GameObject bullet_Slowmo, mainParent;
    public GameObject[] offcontrols;
    public InputControl maincontroller_fps;
    public Camera Weapon_Camera;
    public Camera MainCamera;
    public void playslomotion()
    {
        if (onetime == 0)
        {
            Time.timeScale = 0.01f;
            Instantiate(bullet_Slowmo, maincontroller_fps.StartPosition.transform.position, maincontroller_fps.StartPosition.transform.rotation);
            rfps_pl.farClipPlane = 0.5f;
            Weapon_Camera.farClipPlane = 0.5f;
            maincontroller_fps.enabled = false;
            for (int i = 0; i < offcontrols.Length; i++)
            {
                offcontrols[i].SetActive(false);
            }
            onetime = 1;
        }
    }

    public void controls_status()
    {
        if (onetime == 0)
        {
            Time.timeScale = 0.01f;
            rfps_pl.farClipPlane = 0.5f;
            Weapon_Camera.farClipPlane = 0.5f;
            maincontroller_fps.enabled = false;
            for (int i = 0; i < offcontrols.Length; i++)
            {
                offcontrols[i].SetActive(false);
            }
            onetime = 1;
        }
    }
    // Car In out Btn 
    public void CarInoutBtnstatus(bool _Val)
    {
        carinoutbtn.SetActive(_Val);
    }

    #region Ads Calling Function 
    private void Smallbanner()
    {
        try
        {
            if (FindObjectOfType<MediationHandler>())
            {
                FindObjectOfType<MediationHandler>().ShowSmallBanner(GoogleMobileAds.Api.AdPosition.TopRight);
                FindObjectOfType<MediationHandler>().hideMediumBanner();
            }
        }
        catch (Exception e)
        {
        }
    }
    private void MediumBanner()
    {
        try
        {
            if (FindObjectOfType<MediationHandler>())
            {
                FindObjectOfType<MediationHandler>().ShowMediumBanner(GoogleMobileAds.Api.AdPosition.BottomLeft);
                FindObjectOfType<MediationHandler>().hideSmallBanner();
            }
        }
        catch (Exception e)
        {
        }
    }
    private void loadIAD()
    {
        try
        {
            if (FindObjectOfType<MediationHandler>())
                FindObjectOfType<MediationHandler>().LoadInterstitial();
        }

        catch (Exception e)
        {
            //GameAnalytics.NewErrorEvent(GAErrorSeverity.Info, "MediationHandler Not Found!");
        }
    }
    private void IAD()
    {
        try
        {
            if (FindObjectOfType<MediationHandler>())
                FindObjectOfType<MediationHandler>().ShowInterstitial();
        }
        catch (Exception e)
        {
        }
    }
    #endregion
    public void endslowmo()
    {
        rfps_pl.farClipPlane = 120;
        Weapon_Camera.farClipPlane = 15f;
        maincontroller_fps.enabled = true;
        Time.timeScale = 1.0f;
        for (int i = 0; i < offcontrols.Length; i++)
        {
            offcontrols[i].SetActive(true);
        }




    }
    public void start_tutorial()
    {
        Tutorail_obj.SetActive(false);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        PlayerPrefs.SetInt("tutorial", 1);
    }
    // Update is called once per frame
    void Update()
    {
        if (loading)
        {
            loadingimage.fillAmount += Time.deltaTime / 4;
            if (loadingimage.fillAmount >= 1)
            {
                loading = false;
                StartCoroutine("Loading_off");
            }
        }
    }


    public void Animalbarstatus(int total)
    {
        HuntedAnimal.text = "" + DamageManager.KilledAnimal.ToString() + "/" + total;
    }

    //void gum()
    //{
    //    successPanel.SetActive(true);
    //    successPanel.transform.GetChild(3).gameObject.SetActive(true);
    //}
    void waitedd_panels()
    {
        // successPanel.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);

        successPanel.transform.GetChild(3).gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("RemoveAds") == 1 && PlayerPrefs.GetInt("Unlocked") == 59 && PlayerPrefs.GetInt("Unlocked1") == 19 && PlayerPrefs.GetInt("Unlocked2") == 19 && PlayerPrefs.GetInt("Unlocked3") == 19)
        {
            successPanel.transform.GetChild(1).gameObject.SetActive(false);
            successPanel.transform.GetChild(0).gameObject.SetActive(true);
            //add_showw_panel.SetActive(false);
            //af  add_showw_panel.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Unlocked") == 5 && Constants.Getprefs(Constants.lastselectedMode) == 0 && PlayerPrefs.GetInt("sniper1") == 0)
        {
            successPanel.transform.GetChild(2).gameObject.SetActive(true);
            successPanel.transform.GetChild(1).gameObject.SetActive(false);
            //Invoke("wait_com", 3f);
            PlayerPrefs.SetInt("sniper1", 1);
            PlayerPrefs.SetInt("Gun2", 1);
        }
        else if (Constants.Getprefs(Constants.lastselectedLevel) < 4)
        {
            successPanel.transform.GetChild(2).gameObject.SetActive(true);
            successPanel.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            successPanel.transform.GetChild(1).gameObject.SetActive(true);
            PlayerPrefs.SetInt("trail", 0);
        }
    }
    void wait_com()
    {
        successPanel.transform.GetChild(2).gameObject.SetActive(false);
    }
    public Text HeadShots, BodyShots, Level_Rewrad, Total_score, levelNotext;
    public void Level_Completed()
    {


        if (Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)) < Constants.TotallevelofMode[Constants.Getprefs(Constants.lastselectedMode)] && Constants.Getprefs(Constants.lastselectedLevel) >= Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)))
        {
            Constants.SetPref(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode), (Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode))) + 1);
            print(" val :" + Constants.Getprefs(Constants.lastUnlockedLevel + Constants.lastselectedMode) + "_Val" + Constants.TotallevelofMode[Constants.Getprefs(Constants.lastselectedMode)]);
        }

        offcontrols[0].SetActive(false);
        offcontrols[1].SetActive(false);
        offcontrols[2].SetActive(false);
        offcontrols[3].SetActive(false);
        offcontrols[4].SetActive(false);
        maincontroller_fps.gameObject.SetActive(false);
        //Instantiate(demo, demo.transform.position, demo.transform.rotation);
        stop_respwan = true;
        //reward_calculations();
        StartCoroutine(CR_CoinsAnimation());
        //Level_Selection.selected_level = Constants.Getprefs(Constants.lastselectedLevel);
        Caching.ClearCache();
        //Smart_Banner.SetActive(false);
        successPanel.SetActive(true);
        // successPanel.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0.5f); 
        //  Invoke("waitedd_panels", 6f);
        //if (environmentSelection.Curr_Mode == 4)
        //{
        //    FindObjectOfType<MissionHandler>().Jeeb_obj.GetComponent<AudioSource>().enabled = false;
        //}
        IAD();
        MediumBanner();
        Constants.FBAnalytic_EventLevel_Complete(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode)), Constants.Getprefs(Constants.lastselectedLevel));
        if (Constants.TryWeapon)
            Constants.WeaponTrialFinished = true;
    }
    private void reward_calculations()
    {
        HeadShots.text = Constants.Getprefs(Constants.Headshot).ToString();
        BodyShots.text = Constants.Getprefs(Constants.Bodyshot).ToString();
        Constants.SetPref(Constants.Levelreward, Random.Range(300, 500));
        Level_Rewrad.text = Constants.Getprefs(Constants.Levelreward).ToString();
        Constants.SetPref(Constants.Totalreward,Constants.Getprefs(Constants.Totalreward) + Constants.Getprefs(Constants.Headshot) + Constants.Getprefs(Constants.Bodyshot) + Constants.Getprefs(Constants.Levelreward));
        Total_score.text = Constants.Getprefs(Constants.Totalreward).ToString();
        Constants.SetPref(Constants.Headshot, 0);
        Constants.SetPref(Constants.Bodyshot, 0);
        Constants.SetPref(Constants.Levelreward, 0);

    }

    int curheadshotBonus = 0;
    int curbodyshotBonus = 0;
    int curlevelBonus = 0;
    int curtotalCoins = 0;

    int headshotBonus = 0;
    int levelBonus = 0;
    int bodyshotBonus = 0;
    int totalCoins = 0;
    int coinsReward = 0;
    int coinIncVal = 20;
    IEnumerator CR_CoinsAnimation()
    {
        yield return new WaitForSeconds(0.8f);
        headshotBonus = Constants.Getprefs(Constants.Headshot);
        bodyshotBonus = Constants.Getprefs(Constants.Bodyshot);
        Constants.SetPref(Constants.Levelreward, Random.Range(300, 500));
        levelBonus = Constants.Getprefs(Constants.Levelreward);
        //HeadShots.text = Constants.Getprefs(Constants.Headshot).ToString();
        //BodyShots.text = Constants.Getprefs(Constants.Bodyshot).ToString();
        //Level_Rewrad.text = Constants.Getprefs(Constants.Levelreward).ToString();
        //print("headshotBonus :" + headshotBonus);
        //print("bodyshotBonus :" + bodyshotBonus);
        //print("levelBonus :" + levelBonus);
        while (curheadshotBonus <= headshotBonus && curheadshotBonus <= headshotBonus - coinIncVal)
        {
            curheadshotBonus += coinIncVal;
            HeadShots.text = curheadshotBonus.ToString();
            yield return new WaitForSeconds(0.012345f);
        }
        HeadShots.text = Constants.Getprefs(Constants.Headshot).ToString();
        while (curbodyshotBonus <= bodyshotBonus && curbodyshotBonus <= bodyshotBonus - coinIncVal)
        {
            curbodyshotBonus += coinIncVal;
            BodyShots.text = curbodyshotBonus.ToString();
            yield return new WaitForSeconds(0.01234f);
        }
        BodyShots.text = Constants.Getprefs(Constants.Bodyshot).ToString();
        while (curlevelBonus <= levelBonus && curlevelBonus <= levelBonus - coinIncVal)
        {
            curlevelBonus += coinIncVal;
            Level_Rewrad.text = curlevelBonus.ToString();
            yield return new WaitForSeconds(0.01234f);
        }
        Level_Rewrad.text = Constants.Getprefs(Constants.Levelreward).ToString();
        totalCoins = Constants.Getprefs(Constants.Headshot) + Constants.Getprefs(Constants.Bodyshot) + Constants.Getprefs(Constants.Levelreward);
        Constants.SetPref(Constants.Totalreward,Constants.Getprefs(Constants.Totalreward)+totalCoins);
        while (curtotalCoins <= totalCoins && curtotalCoins <= totalCoins - coinIncVal)
        {
            curtotalCoins += coinIncVal;
            Total_score.text = curtotalCoins.ToString();
            yield return new WaitForSeconds(0.0123f);
        }

        Total_score.text = totalCoins.ToString();
        Constants.SetPref(Constants.Headshot, 0);
        Constants.SetPref(Constants.Bodyshot, 0);
        Constants.SetPref(Constants.Levelreward, 0);
        StopCoroutine(CR_CoinsAnimation());
    }
    public void Rewardedad(Button btn)
    {
        try
        {
            if (FindObjectOfType<MediationHandler>())
            {
                if (FindObjectOfType<MediationHandler>().IsRewardedAdReady())
                {
                    FindObjectOfType<MediationHandler>().ShowRewardedVideo(DoubleReward);
                    btn.interactable = false;
                }
            }
        }
        catch (Exception e)
        {
        }
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }

    private void DoubleReward()
    {
        int doublereward = (Constants.Getprefs(Constants.Totalreward) * 2);
        Constants.SetPref(Constants.Totalreward, doublereward);
        Total_score.text = Constants.Getprefs(Constants.Totalreward).ToString();
    }
    public void Level_Failed()
    {
        Time.timeScale = 0.0001f;
        failedPanel.SetActive(true);
        Caching.ClearCache();
        //Smart_Banner.SetActive(false);
        if (PlayerPrefs.GetInt("RemoveAds") == 1 && PlayerPrefs.GetInt("Unlocked") == 59 && PlayerPrefs.GetInt("Unlocked1") == 19 && PlayerPrefs.GetInt("Unlocked2") == 19 && PlayerPrefs.GetInt("Unlocked3") == 19)
        {
            failedPanel.transform.GetChild(1).gameObject.SetActive(false);
            failedPanel.transform.GetChild(0).gameObject.SetActive(true);
        }
        Main_Player.GetComponent<CapsuleCollider>().enabled = false;
        Constants.FBAnalytic_EventLevel_Fail(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode)), Constants.Getprefs(Constants.lastselectedLevel));
        IAD();
        MediumBanner();
    }
    public void OnTapPause()
    {
        Global_Scripts.GameStarted = false;
        Time.timeScale = 0.0f;
        pausedPanel.SetActive(true);
        MediumBanner();
        Constants.FBAnalytic_EventLevel_pause(Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode)), Constants.Getprefs(Constants.lastselectedLevel));
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }
    public void OnTapResume()
    {
        Global_Scripts.GameStarted = true;
        Time.timeScale = 1f;
        pausedPanel.SetActive(false);
        Smallbanner();
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }
    public void OnTapNext()
    {
        Time.timeScale = 1f;

        if (Constants.Getprefs(Constants.lastselectedLevel) < Constants.TotallevelofMode[Constants.Getprefs(Constants.lastselectedMode)])
        {
            Constants.SetPref(Constants.lastselectedLevel, Constants.Getprefs(Constants.lastselectedLevel) + 1);
            DamageManager.KilledAnimal = 0;
            SceneManager.LoadScene(Constants.scene_GamePlay);
        }

        else
        {
            lvls_counters4 = 0;
            PlayerPrefs.SetInt("backmode", 1);
            DamageManager.KilledAnimal = 0;
            Menu_Manager.NextLevel = false;
            SceneManager.LoadScene(Constants.scene_Menu);
        }
        stop_respwan = true;
        ads_call++;
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }
    public void OnTapRestart()
    {
        Time.timeScale = 1f;
        if (successPanel.activeInHierarchy || failedPanel.activeInHierarchy || pausedPanel.activeInHierarchy)
        {
            successPanel.SetActive(false);
            // failedPanel.SetActive(false);
            pausedPanel.SetActive(false);
            loadingPanel.SetActive(true);
        }
        loading = true;
        DamageManager.KilledAnimal = 0;
        stop_respwan = true;
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        //PlayerPrefs.SetInt("trail", 0);
    }
    IEnumerator Loading_off()
    {
        yield return new WaitForSeconds(0.5f);
        loadingimage.fillAmount = 0;
        loading = false;
        AudioListener.pause = false;
        //loadingPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnTapRestart_Success()
    {
        Time.timeScale = 1f;
        DamageManager.KilledAnimal = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
     //   IAD();
    }
    public void OnTapHome()
    {
        Time.timeScale = 1f;
        DamageManager.KilledAnimal = 0;
        Constants.DirectModeselectionshow = true;
        AdloadingBreak.SetActive(true);
        loadIAD();
        Invoke(nameof(sceneMainmenuloadondelay),3f);
        //SceneManager.LoadScene("Menu_Handler_UZ");
        stop_respwan = true;
        PlayerPrefs.SetInt("modeinapp", 1);
        PlayerPrefs.SetInt("backmode", 0);
        lvls_counters = 0;
        lvls_counters1 = 0;
        lvls_counters2 = 0;
        lvls_counters3 = 0;
        lvls_counters4 = 0;
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        //Invoke(nameof(IAD),2f);
       
        // PlayerPrefs.SetInt("trail", 0);
    }
    private void sceneMainmenuloadondelay()
    {
        SceneManager.LoadScene(Constants.scene_Menu);
        CancelInvoke(nameof(sceneMainmenuloadondelay));
    }
    public void hitText_Off()
    {
        Invoke("text_off", 1.5f);
    }
    void text_off()
    {
        hitText.gameObject.transform.parent.gameObject.SetActive(false);
        ScoreText.gameObject.transform.parent.gameObject.SetActive(false);
    }
    //public void HeadShotScore()
    //{
    //    hitText.SetActive(true);
    //    ScoreText.SetActive(true);
    //    hitText.GetComponent<Text>().text = "HEAD SHOT";
    //    ScoreText.GetComponent<Text>().text = "$250";   
    //    PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 250); 
    //    Invoke("text_off", 2.5f);
    //}
    //public void BodyShotScore()
    //{
    //    hitText.SetActive(true);
    //    ScoreText.SetActive(true);
    //    hitText.GetComponent<Text>().text = "BODY SHOT";
    //    ScoreText.GetComponent<Text>().text = "$150";    
    //    PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 150);
    //    Invoke("text_off", 2.5f);
    //}
    public void Complete_level()//InamS
    {
        //if (Constants.Getprefs(Constants.lastselectedMode) == 4)
        //{
        //    if (kills_safarimode[Constants.Getprefs(Constants.lastselectedLevel)] <= DamageManager.KilledAnimal)
        //    {
        //        Global_Scripts.GameStarted = false;
        //        Global_Scripts.timeOver = true;
        //        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1000);
        //        Invoke("Lev_Com_Wait", 1f);
        //        //if (Constants.Getprefs(Constants.TotalLevelofMode) < 60)
        //        //{
        //        //    Invoke("Lev_Com_Wait", 1f);
        //        //}
        //    }
        //}
        //else
        //{
        //    if (kills[Constants.Getprefs(Constants.lastselectedLevel)] <= DamageManager.KilledAnimal)
        //    {
        //        Global_Scripts.GameStarted = false;
        //        Global_Scripts.timeOver = true;
        //        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1000);
        //        Invoke("Lev_Com_Wait", 1f);
        //        //if (Constants.Getprefs(Constants.TotalLevelofMode) < 60)
        //        //{
        //        //    Invoke("Lev_Com_Wait", 1f);
        //        //}
        //    }
        //}
       // print("Complete_level");
        Global_Scripts.GameStarted = false;
        Global_Scripts.timeOver = true;
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1000);
        Invoke("Lev_Com_Wait", 1f);
    }
    public void Lev_Fail_Text()
    {
        if (CrossHair_Image.activeInHierarchy)
        {
            CrossHair_Image.SetActive(false);
        }
        failedText.gameObject.SetActive(true);
        failedText.text = "Sorry You Failed to Shoot the Target Point";
    }
    public void Lev_Fail_Wait()
    {
        Level_Failed();
        failedText.gameObject.SetActive(false);
    }

    public void Lev_Com_Wait()
    {
        //Level_Completed();
        //print("Lev_Com_Wait");
        Victory();
    }

    private void Victory()
    {
       // print("Victory");
        victoryPanel.SetActive(true);
        levelNotext.text = "LEVEL" + " \n" + (Constants.Getprefs(Constants.lastselectedLevel) + 1).ToString();
        try
        {
            if (FindObjectOfType<MediationHandler>())
            {
                FindObjectOfType<MediationHandler>().hideSmallBanner();
            }
        }
        catch (Exception e)
        {
        }
        Invoke(nameof(Level_Completed), 5f);
    }
    public void OnObjectiveOk()
    {
        Global_Scripts.GameStarted = true;
        Global_Scripts.timeOver = false;
        // LevelsHandler.instance.ins_data();
        ObjectivePanel.SetActive(false);
        Time.timeScale = 1f;
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }
    private void OnApplicationQuit()
    {
        stop_respwan = true;
        PlayerPrefs.SetInt("backmode", 0);
    }
    public void Restart_Scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void shop()
    {
        // InApp_Manager.instance.Buy_UnlockAll_Eveything();
    }
    public static int counter_no;
    //public GameObject add_showw_panel;
    public void continue_inapp()
    {
        counter_no++;
        if (counter_no == 3)
        {
            successPanel.transform.GetChild(2).gameObject.SetActive(true);
            counter_no = 0;
        }
        else
        {
            successPanel.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    public void OnMoreButtonClicked()
    {
        Application.OpenURL("");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }
}
