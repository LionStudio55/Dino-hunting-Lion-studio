using System;
using UIAnimatorCore;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Mode_Selection : MonoBehaviour
{

    public bool[] ModesUnlocked;
    public int[] NoofwatchvideoforUnlockvideo;
    public Text Coinstext;
    public GameObject[] Modebtn;
    public GameObject[] Hover;
    public GameObject[] locks;
    public GameObject[] WatchVideo;
    public Text[] VideosText;
    public GameObject messagePanel;
    public GameObject Loading;
    public GameObject Modeselection;
    public GameObject Envselection;
    public GameObject Levelselection;
    public GameObject UnlockAllModesBtn;
    public GameObject UnlockAllEverythingInapps;

    private void OnEnable()
    {
       
        if (!PlayerPrefs.HasKey("ModesUnlocked"))
        {
          //  print("FIRST");
            PlayerPrefsX.SetBoolArray("ModesUnlocked", ModesUnlocked);
        }
        else
        {
           // print("nOTFIRST");
            ModesUnlocked = PlayerPrefsX.GetBoolArray("ModesUnlocked");
        }
        ModesUnlockstatus();
        Updatestats();
        Invoke(nameof(Megaoffer),1f);
    }
    private void Megaoffer()
    {
        if (AreAllModesUnlocked())
            UnlockAllEverythingInapps.SetActive(false);
        else
            UnlockAllEverythingInapps.SetActive(true);
        CancelInvoke(nameof(Megaoffer));
    }
    private void OnDisable()
    {
        PlayerPrefsX.SetBoolArray("ModesUnlocked", ModesUnlocked);
    }
    public void Updatestats()
    {
        ModesUnlocked = PlayerPrefsX.GetBoolArray("ModesUnlocked");
        Coinstext.text = Constants.Getprefs(Constants.Totalreward).ToString();
        InitGunsButtonsState();
        Hover[Constants.Getprefs(Constants.lastselectedMode)].SetActive(true);
        if (AreAllModesUnlocked())
            UnlockAllModesBtn.SetActive(false);
        else
            UnlockAllModesBtn.SetActive(true);


    }
    
    private void InitGunsButtonsState()
    {

        bool watchVideoBtnEnabled = false;
        int GunUnlocked = Get_LastUnlockedMode();
        Debug.Log("InitLevelButtonsState");
        for (int i = 0; i < ModesUnlocked.Length; i++)
        {
            Modebtn[i].gameObject.SetActive(true);
           

            //Watch video Btn for Unlock Next Level
            if (!watchVideoBtnEnabled && !ModesUnlocked[i])
            {
                WatchVideo[i].SetActive(true);
                VideosText[i].text = "watch " + (NoofwatchvideoforUnlockvideo[i] - Constants.Getprefs(Constants.Totalvideoswatched)) + " video to Unlock this MODE ";
                print("TryWeapon :"+i);
                watchVideoBtnEnabled = true;
            }
            else
                WatchVideo[i].SetActive(false);

            if (ModesUnlocked[i]/*i == GunUnlocked*/)
            {
                Hover[i].SetActive(false);
                locks[i].SetActive(false);
                Modebtn[i].GetComponent<UIAnimator>().enabled = true;
               
            }
            //else if (i <= GunUnlocked)
            //{
            //    Hover[i].SetActive(false);
            //    locks[i].SetActive(false);
            //    Modebtn[i].GetComponent<UIAnimator>().enabled = false;
            //}
            else
            {
                Hover[i].SetActive(false);
                locks[i].SetActive(true);
                Modebtn[i].GetComponent<UIAnimator>().enabled = false;
            }
        }
        //for (int i = 0; i < lvlUnlocked; i++)
        //{

        //    btnListner[i].Lock_Status(false);
        //}
    }
    public void ModesUnlockstatus()
    {

        if (Constants.Getprefs(Constants.lastselectedMode) == 0 && (Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)) >= 4 && Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode))<14) && Constants.Getprefs(Constants.Mode2Unlock) == 0)
        {
           
            locks[1].SetActive(false);
            ModesUnlocked[1] = true;
            Constants.SetPref(Constants.lastselectedMode, Get_LastUnlockedMode());
            PlayerPrefsX.SetBoolArray("ModesUnlocked", ModesUnlocked);
            print("Mode Unlock Second");
            //Updatestats();
            Constants.SetPref(Constants.Mode2Unlock, 1);
            messagePanel.SetActive(true);
            messagePanel.GetComponent<MessageListner>().UpdateTxt("Congratulations your Second Mode Unlock Enjoy with This Fantasic Mode ", "Congratulations");
            messagePanel.GetComponent<MessageListner>().set_statuspanel();

        }
        else if (Constants.Getprefs(Constants.lastselectedMode) == 1 && Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)) >= 4 && Constants.Getprefs(Constants.Mode3Unlock) == 0)
        {
            
            locks[2].SetActive(false);
            ModesUnlocked[2/*Get_LastlockedMode()*/] = true;
            Constants.SetPref(Constants.lastselectedMode, Get_LastUnlockedMode());
            PlayerPrefsX.SetBoolArray("ModesUnlocked", ModesUnlocked);
            print("Mode Unlock Third");
           // Updatestats();
            Constants.SetPref(Constants.Mode2Unlock, 1);
            Constants.SetPref(Constants.Mode3Unlock, 1);
            messagePanel.SetActive(true);
            messagePanel.GetComponent<MessageListner>().UpdateTxt("Congratulations your Third Mode Unlock Enjoy with This Fantasic Mode ", "Congratulations");
            messagePanel.GetComponent<MessageListner>().set_statuspanel();
        }

         else if (Constants.Getprefs(Constants.lastselectedMode) == 1 && (Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)) >= 9 && Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)) < 19) && Constants.Getprefs(Constants.Mode4Unlock) == 0)
        {
           
            locks[3/*Get_LastlockedMode()*/].SetActive(false);
            ModesUnlocked[3/*Get_LastlockedMode()*/] = true;
            Constants.SetPref(Constants.lastselectedMode, Get_LastUnlockedMode());
            PlayerPrefsX.SetBoolArray("ModesUnlocked", ModesUnlocked);
            print("Mode Unlock Fourth");
           // Updatestats();
            //Constants.SetPref(Constants.Mode2Unlock, 1);
            //Constants.SetPref(Constants.Mode3Unlock, 1);
            Constants.SetPref(Constants.Mode4Unlock, 1);
            messagePanel.SetActive(true);
            messagePanel.GetComponent<MessageListner>().UpdateTxt("Congratulations your Fourth Mode Unlock Enjoy with This Fantasic Mode ", "Congratulations");
            messagePanel.GetComponent<MessageListner>().set_statuspanel();
        }
         else if (Constants.Getprefs(Constants.lastselectedMode) == 3 && Constants.Getprefs(Constants.lastUnlockedLevel + Constants.Getprefs(Constants.lastselectedMode)) >= 4 && Constants.Getprefs(Constants.Mode5Unlock) == 0)
        {
            locks[1].SetActive(false);
            ModesUnlocked[1] = true;
            locks[3/*Get_LastlockedMode()*/].SetActive(false);
            ModesUnlocked[3/*Get_LastlockedMode()*/] = true;
            locks[4].SetActive(false);
            ModesUnlocked[4] = true;
            Constants.SetPref(Constants.lastselectedMode, Get_LastUnlockedMode());
            PlayerPrefsX.SetBoolArray("ModesUnlocked", ModesUnlocked);
            print("Mode Unlock Fifth");
           // Updatestats();
            //Constants.SetPref(Constants.Mode2Unlock, 1);
            //Constants.SetPref(Constants.Mode3Unlock, 1);
            Constants.SetPref(Constants.Mode4Unlock, 1);
            Constants.SetPref(Constants.Mode5Unlock, 1);

            messagePanel.SetActive(true);
            messagePanel.GetComponent<MessageListner>().UpdateTxt("Congratulations your Fifth Mode Unlock Enjoy with This Fantasic Mode ", "Congratulations");
            messagePanel.GetComponent<MessageListner>().set_statuspanel();
        }

        if (Constants.Getprefs(Constants.Mode2Unlock) == 1)
        {
            locks[1].SetActive(false);
        }
        if (Constants.Getprefs(Constants.Mode3Unlock) == 1)
        {
            locks[2].SetActive(false);
        }
        if (Constants.Getprefs(Constants.Mode4Unlock) == 1)
        {
            locks[3].SetActive(false);
        }
        if (Constants.Getprefs(Constants.Mode5Unlock) == 1)
        {
            print("Mode Unlock Fifth");
            locks[4].SetActive(false);
        }
        Updatestats();
    }

    public bool AreAllModesUnlocked()
    {
        for (int i = 0; i < ModesUnlocked.Length; i++)
        {
            if (!ModesUnlocked[i])
            {

                //Debug.LogError("All vehicles --NOT-- unlocked");
                return false;
            }

        }
        //Debug.LogError("All vehicles are unlocked");
        return true;
    }

    public int Get_LastUnlockedMode()
    {
        for (int i = 0; i < ModesUnlocked.Length; i++)
        {
            if (!ModesUnlocked[i])
            {
                return i-1 ;
            }
        }
        return ModesUnlocked.Length - 1;
    }

    public int Get_LastlockedMode()
    {
        for (int i = 0; i < ModesUnlocked.Length; i++)
        {
                //print("i" +i);
            if (!ModesUnlocked[i])
            {
                return i;
            }
        }
        return ModesUnlocked.Length - 1;
    }

    //Unlock By watch Videos
    private void Modesunlock()
    {
        Constants.SetPref(Constants.Totalvideoswatched, Constants.Getprefs(Constants.Totalvideoswatched) + 1);
        print("NoofwatchvideoforUnlockvideo :" + (NoofwatchvideoforUnlockvideo[Get_LastlockedMode()]) + " Totalvideoswatched :" + Constants.Getprefs(Constants.Totalvideoswatched));
        VideosText[Get_LastlockedMode()].text = "watch "+ (NoofwatchvideoforUnlockvideo[Get_LastlockedMode()]- Constants.Getprefs(Constants.Totalvideoswatched)) + " video to Unlock this MODE ";

        if (Constants.Getprefs(Constants.Totalvideoswatched) >= NoofwatchvideoforUnlockvideo[Get_LastlockedMode()])
        {
            print("UnlockModesAferwatchVideos");
            if (Get_LastlockedMode() == 1 && Constants.Getprefs(Constants.Mode2Unlock) == 0)
            {
                Constants.SetPref(Constants.Mode2Unlock, 1);
                messagePanel.SetActive(true);
                messagePanel.GetComponent<MessageListner>().UpdateTxt("Congratulations your Second Mode Unlock Enjoy with This Fantasic Mode ", "Congratulations");
                messagePanel.GetComponent<MessageListner>().set_statuspanel();
            }
            if (Get_LastlockedMode() == 2 && Constants.Getprefs(Constants.Mode3Unlock) == 0)
            {
                Constants.SetPref(Constants.Mode3Unlock, 1);
                messagePanel.SetActive(true);
                messagePanel.GetComponent<MessageListner>().UpdateTxt("Congratulations your Third Mode Unlock Enjoy with This Fantasic Mode ", "Congratulations");
                messagePanel.GetComponent<MessageListner>().set_statuspanel();
            }

            if (Get_LastlockedMode() == 3 && Constants.Getprefs(Constants.Mode4Unlock) == 0)
            {
                Constants.SetPref(Constants.Mode4Unlock, 1);
                messagePanel.SetActive(true);
                messagePanel.GetComponent<MessageListner>().UpdateTxt("Congratulations your Fourth Mode Unlock Enjoy with This Fantasic Mode ", "Congratulations");
                messagePanel.GetComponent<MessageListner>().set_statuspanel();
            }
            if (Get_LastlockedMode() == 4 && Constants.Getprefs(Constants.Mode5Unlock) == 0)
            {
                Constants.SetPref(Constants.Mode5Unlock, 1);
                messagePanel.SetActive(true);
                messagePanel.GetComponent<MessageListner>().UpdateTxt("Congratulations your Fifth Mode Unlock Enjoy with This Fantasic Mode ", "Congratulations");
                messagePanel.GetComponent<MessageListner>().set_statuspanel();
            }
            Constants.SetPref(Constants.Totalvideoswatched,0);
            locks[Get_LastlockedMode()].SetActive(false);
            ModesUnlocked[Get_LastlockedMode()] = true;
            Constants.SetPref(Constants.lastselectedMode, Get_LastUnlockedMode());
            PlayerPrefsX.SetBoolArray("ModesUnlocked", ModesUnlocked);
            Updatestats();
        }
        
    }
    #region button Press
    public void DisplayMsg(int Mode_)
    {
        if (Mode_ == 1)
        {
            messagePanel.SetActive(true);
            messagePanel.GetComponent<MessageListner>().UpdateTxt("Unlock After " + /*lvlNo*/ "5"+ " Levels of First Mode", "Message");
            messagePanel.GetComponent<MessageListner>().set_statuspanel();
        }
        else if (Mode_ == 2)
        {
            messagePanel.SetActive(true);
            messagePanel.GetComponent<MessageListner>().UpdateTxt("Unlock After " + /*lvlNo*/ "5" + " Levels of Second Mode", "Message");
            messagePanel.GetComponent<MessageListner>().set_statuspanel();
        }
        else if (Mode_ == 3)
        {
            messagePanel.SetActive(true);
            messagePanel.GetComponent<MessageListner>().UpdateTxt("Unlock After " + /*lvlNo*/ "10" + " Levels of Second Mode", "Message");
            messagePanel.GetComponent<MessageListner>().set_statuspanel();
        }
        else if (Mode_ == 4)
        {
            messagePanel.SetActive(true);
            messagePanel.GetComponent<MessageListner>().UpdateTxt("Unlock After " + /*lvlNo*/ "5" + " Levels of Fourth Mode", "Message");
            messagePanel.GetComponent<MessageListner>().set_statuspanel();
        }
        //messagePanel.SetActive(true);
        //messagePanel.GetComponent<MessageListner>().UpdateTxt("Unlock After " + lvlNo + " Levels of First Mode", "Message");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }

    public void Selected_Mode(int index)
    {
        Constants.SetPref(Constants.lastselectedMode, index);
        for (int i = 0; i < Modebtn.Length; i++)
        {
            Modebtn[i].GetComponent<UIAnimator>().enabled = false;
            Hover[i].gameObject.SetActive(false);
        }
        Modebtn[index].GetComponent<UIAnimator>().enabled = true;
        Hover[index].gameObject.SetActive(true);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        
       
        if (index == 2)
        {
            // Invoke(nameof(Loadscene), 1f);
            Envselection.SetActive(true);
            Modeselection.SetActive(false);
        }
        else
        {
         Invoke(nameof(Level_selection),5.5f);
         Loading.SetActive(true);
        }
        IAD();
        Constants.FBAnalytic_EventDesign("Selected_Mode_" + Constants.GetCurGameModeName(Constants.Getprefs(Constants.lastselectedMode)).ToString());
    }
    private void Level_selection()
    {
        print("Level_selection");
        Levelselection.SetActive(true);
        Modeselection.SetActive(false);
    }
    public void Loadscene()
    {
        SceneManager.LoadScene(2);
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

    public void On_presswatchvideoModesUnlock()
    {

        try
        {
            if (FindObjectOfType<MediationHandler>())
                FindObjectOfType<MediationHandler>().ShowRewardedVideo(Modesunlock);
        }
        catch (Exception e)
        {
        }
    }

    public void UnlockAllModes()
    {
        InAppHandler.Instance.Buy_AllModes();
    }
    public void Mega_offer()
    {
        InAppHandler.Instance.Buy_MegaOffer();
    }

    #endregion

}
