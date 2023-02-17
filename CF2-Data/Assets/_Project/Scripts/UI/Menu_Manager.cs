using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Manager : MonoBehaviour
{

    public GameObject /*removeAdsButton, shopButton,mode_iap_pnl*/iap_panel, iap_button;

    //public GameObject[] canvses;
    public Text cash;
    public static Menu_Manager instance;
    public GameObject ExitPanel, MainMenuPanel, LevelSelection, Modeselection;
    public GameObject PrivacySubPanel;
    //public Button ContinueBtn;

    public GameObject Playbtn, RateBtn, Morebtn, ExitBtn, PrivacyBtn;
    public static bool adsalternative = false;

    //public GameObject selectButton;
    public static int index;
    public static bool NextLevel;
    public GameObject Rewarded_coins;
    public GameObject content;
    public static int rewarded_type = 0;

    //public GameObject UnlockEverthing_modeselection;

    public void coins_get()
    {
        Rewarded_coins.SetActive(true);
        Constants.SetPref(Constants.Totalreward, Constants.Getprefs(Constants.Totalreward) + 200);
        updatestats();
        Invoke("waited", 2f);
    }
    void waited()
    {
        Rewarded_coins.SetActive(false);

    }
    public void Awake()
    {
        Application.targetFrameRate = 600;
        //Instantiate(Env_obj);
        //if (PlayerPrefs.GetInt("RemoveAds") == 1)
        //{
        //    removeAdsButton.GetComponent<Button>().interactable = false;
        //}
        if (PlayerPrefs.GetInt("RemoveAds") == 1 && PlayerPrefs.GetInt("Unlocked") >= 59 && PlayerPrefs.GetInt("Unlocked1") >= 19 && PlayerPrefs.GetInt("Unlocked2") >= 19 && PlayerPrefs.GetInt("Unlocked3") >= 19)
        {
            // shopButton.GetComponent<Button>().interactable = false;
            // mode_iap_pnl.GetComponent<Button>().interactable = false;
            iap_panel.SetActive(false);
            iap_button.SetActive(false);
        }

        Time.timeScale = 1f;
        instance = this;
        //Constants.SetPref(Constants.lastselectedLevel, PlayerPrefs.GetInt("CurrentMission", 0));
        updatestats();
        SoundsManager.Instance.PlayMusic_Menu();
    }
    public void Start()
    {
        Time.timeScale = 1f;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;


        if (Constants.DirectModeselectionshow)
        {
            Modeselection.SetActive(true);
            MainMenuPanel.SetActive(false);
            try
            {
                if (FindObjectOfType<MediationHandler>())
                    FindObjectOfType<MediationHandler>().ShowInterstitial();
            }

            catch (Exception e)
            {
                //GameAnalytics.NewErrorEvent(GAErrorSeverity.Info, "MediationHandler Not Found!");
            }
            Invoke(nameof(loadAds), 2f);
        }
        else
        {
            Modeselection.SetActive(false);
            MainMenuPanel.SetActive(true);
            loadAds();
        }
        PlayerPrefs.SetInt("trail", 0);

        Smallbanner();
    }
    #region Ad calling 
    private void Mediumbanner()
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
    private void Smallbanner()
    {
        try
        {
            if (FindObjectOfType<MediationHandler>())
            {
                FindObjectOfType<MediationHandler>().ShowSmallBanner(GoogleMobileAds.Api.AdPosition.Top);
                FindObjectOfType<MediationHandler>().hideMediumBanner();
            }
        }
        catch (Exception e)
        {
        }
    }
    private void loadAds()
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
        CancelInvoke(nameof(loadAds));
    }
    public void MBAD()
    {
        try
        {
            if (FindObjectOfType<MediationHandler>())
            {
                FindObjectOfType<MediationHandler>().ShowMediumBanner(GoogleMobileAds.Api.AdPosition.BottomLeft);
                // FindObjectOfType<MediationHandler>().hideSmallBanner();
            }
        }
        catch (Exception e)
        {
        }
    }
    public void HideMbad()
    {
        try
        {
            if (FindObjectOfType<MediationHandler>())
            {
               // FindObjectOfType<MediationHandler>().ShowMediumBanner(GoogleMobileAds.Api.AdPosition.BottomLeft);
                FindObjectOfType<MediationHandler>().hideMediumBanner();
            }
        }
        catch (Exception e)
        {
        }
    }
    #endregion


    public void updatestats()
    {
        cash.text = Constants.Getprefs(Constants.Totalreward).ToString();
    }
    public void inapp_off()
    {
        //  UnlockEverthing_modeselection.SetActive(false);
        content.gameObject.GetComponent<Animator>().enabled = true;
        //EnvSelection.SetActive(true);
    }

    void inapp_inmode()
    {

        //  UnlockEverthing_modeselection.SetActive(true);
        Invoke("inapp_off", 5f);
        //if (PlayerPrefs.GetInt("modeinapp") == 1 && PlayerPrefs.GetInt("uneverthing") == 0)
        //{
        //    UnlockEverthing_modeselection.SetActive(true);

        //}

        //    else
        //    {
        //        UnlockEverthing_modeselection.SetActive(false);

        //}

    }



    private void OnEnable()
    {
        rewarded_type = 0;
        UI_Manager.ads_call = 0;
    }
    public void Mega_Offer()
    {

        InAppHandler.Instance.Buy_MegaOffer();
    }

    IEnumerator LoadScene()
    {
        yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Game_Play");
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        //Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            //  loadingBar.GetComponent<Image>().fillAmount += 0.002f;
            // string percent = (loadingBar.GetComponent<Image>().fillAmount * 100).ToString("F0");
            //    loadingText.text = string.Format("<size=35>{0}%</size>", percent);
            // Check if the load has finished
            //if (asyncOperation.progress >= 0.9f && loadingBar.GetComponent<Image>().fillAmount == 1.0f)
            //{

            //    asyncOperation.allowSceneActivation = true;

            //}

            yield return null;
        }
    }



    public void Wheel()
    {
        SceneManager.LoadScene(1);
    }


    public void ChangePlayer()
    {
        MainMenuPanel.SetActive(false);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }

    public void OnBackToMain()
    {
        Modeselection.SetActive(true);
        LevelSelection.SetActive(false);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);


    }

    public void OnOkay()
    {
        MainMenuPanel.SetActive(true);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }

    public void OnPlayButtonClicked()
    {
        Constants.FBAnalytic_EventDesign("Menu_Play_");
        Modeselection.SetActive(true);
        // MainMenuPanel.SetActive(false);
        print("OnPlayButtonClicked");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }

    public void OnRateButtonClicked()
    {
        // Application.OpenURL("https://play.google.com/store/apps/details?id=com.offroad.snow.excavator.simulator.games");
        Application.OpenURL(Constants.link_StoreInitial+ Application.identifier);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }

    public void OnMoreButtonClicked()
    {
        //Application.OpenURL("https://play.google.com/store/apps/dev?id=8343798540401422884");
        Application.OpenURL(Constants.link_MoreGames);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }
    public void OnPrivcyButtonClicked()
    {
       // Application.OpenURL("https://liongamezstudio.blogspot.com/2020/06/lion-gamez-studio.html");
        Application.OpenURL(Constants.link_PrivacyPolicy);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }
    public void startScene()
    {
        SceneManager.LoadScene(5);
    }
    public void OnClickYes()
    {
        Constants.FBAnalytic_EventDesign("Yes_Click_");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        Application.Quit();
    }
    public void OnExit()
    {
        ExitPanel.SetActive(true);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        Mediumbanner();

    }
    public void OnClickNo()
    {
        Constants.FBAnalytic_EventDesign("No_Click_");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        ExitPanel.SetActive(false);
        Smallbanner();

    }
    //
    public void Backtolevels()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }

    public void OnClickContinue()
    {
        //if (loading)
        //    loading.SetActive(true);
        Invoke("LoadTheScene", 10f);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);


    }

    public void OnClickNewGame()
    {
        //if (loading)
        //    loading.SetActive(true);
        PlayerPrefs.SetInt("CurrentMission", 0);
        Constants.SetPref(Constants.lastselectedLevel, 0);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        Invoke("LoadTheScene", 15f);
    }
    public void OnClickPrivacy()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        PrivacySubPanel.SetActive(true);
        RateBtn.SetActive(false);
        Morebtn.SetActive(false);
        PrivacyBtn.SetActive(false);
        ExitBtn.SetActive(false);
        Playbtn.SetActive(false);
    }
    public void OnClickCross()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        PrivacySubPanel.SetActive(false);
        RateBtn.SetActive(true);
        Morebtn.SetActive(true);
        PrivacyBtn.SetActive(true);
        ExitBtn.SetActive(true);
        Playbtn.SetActive(true);
    }
    public void OnReset()
    {
        PlayerPrefs.SetInt("CurrentMission", 0);
        //Constants.Getprefs(Constants.lastselectedLevel) = 0;
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }
    public void OnOK()
    {
        AudioListener.pause = true;
        MainMenuPanel.SetActive(false);
        LevelSelection.SetActive(false);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        StartCoroutine(LoadScene());
    }
    void LoadTheScene()
    {
        SceneManager.LoadScene(5);
    }
    IEnumerator GamePlay_Scene()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(5);
    }
    public void SelectBtton()
    {
        PlayerPrefs.SetInt("Selection", index);
        Menu_Manager.instance.MainMenuPanel.SetActive(false);
        Menu_Manager.instance.LevelSelection.SetActive(true);
    }

    public void Back()
    {
        Menu_Manager.instance.MainMenuPanel.SetActive(true);
        Menu_Manager.instance.LevelSelection.SetActive(false);
    }

    public void removeAds()
    {
        if (SystemInfo.systemMemorySize > 2048)
        {
            // InApp_Manager.instance.Buy_RemoveAds();
        }
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }

    public void shop()
    {
        if (SystemInfo.systemMemorySize > 2048)
        {
            //InApp_Manager.instance.Buy_UnlockAll_Eveything();
            if (PlayerPrefs.GetInt("RemoveAds") == 1 && PlayerPrefs.GetInt("Unlocked") == 59 && PlayerPrefs.GetInt("Unlocked1") == 19 && PlayerPrefs.GetInt("Unlocked2") == 19 && PlayerPrefs.GetInt("Unlocked3") == 19)
            {
                SceneManager.LoadScene(1);
            }
        }
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }


    public void rewarded_video()
    {
        try
        {
            if (FindObjectOfType<MediationHandler>())
                FindObjectOfType<MediationHandler>().ShowRewardedVideo(reward);
        }
        catch (Exception e)
        {

        }
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }

    private void reward()
    {
        Constants.SetPref(Constants.Totalreward, Constants.Getprefs(Constants.Totalreward) + 200);
        updatestats();
    }
    public void unlocklevels()
    {
        PlayerPrefs.SetInt("Unlocked", 59);
        PlayerPrefs.SetInt("Unlocked1", 19);
        PlayerPrefs.SetInt("Unlocked2", 19);
        PlayerPrefs.SetInt("Unlocked3", 19);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("curr_lvl", 0);
        PlayerPrefs.SetInt("backmode", 0);
    }
    private void OnDisable()
    {
        CancelInvoke();
        StopAllCoroutines();
    }

    public void UnlockAll_Guns()
    {
        InAppHandler.Instance.Buy_AllVehicles();
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);

    }


}
