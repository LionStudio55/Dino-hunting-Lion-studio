using System;
using UnityEngine;
using UnityEngine.UI;

public class StoreListner : MonoBehaviour
{
    public Text coinsTxt;
    public Text daimondTxt;
    //public GameObject allVehiclesUnlockButton;

    public GameObject Guns;
    public GameObject Advertisement;
    public GameObject Cash;
    public GameObject Ads;

    private void OnEnable()
    {
    }

    private void OnDisable()
    {

        //if (FindObjectOfType<MainMenuListner>())
        //    FindObjectOfType<MainMenuListner>().ShowBannner();
    }
    private void Start()
    {
        UpdateTxts();
        //UnlockAllCarsButtonHandling();
    }
    private void Update()
    {
        UpdateTxts();
    }


    //public void UnlockAllCarsButtonHandling()
    //{
    //    if (Toolbox.DB.Prefs.GetLockedItemIndex(1) == -1)
    //        allVehiclesUnlockButton.SetActive(false);
    //}

    public void UpdateTxts()
    {
        coinsTxt.text = Constants.Getprefs(Constants.Totalreward).ToString();
        //daimondTxt.text = Toolbox.DB.Prefs.Daimond.ToString();

    }

    #region Cash Packs 

    public void OnPress_Close()
    {

        Constants.FBAnalytic_EventDesign("Store_Press_Close");
        //Toolbox.GameManager.Analytics_DesignEvent("Store_Press_Close");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        this.gameObject.SetActive(false);
        //    Destroy(this.gameObject);
    }

    public void OnPress_Pack1()
    {
        Constants.FBAnalytic_EventDesign("Store_Press_Pack1");
        //Toolbox.GameManager.Analytics_DesignEvent("Store_Press_Pack1");

        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        InAppHandler.Instance.Buy_Coinspackone();
    }

    public void OnPress_Pack2()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        Constants.FBAnalytic_EventDesign("Store_Press_Pack2");
        //Toolbox.GameManager.Analytics_DesignEvent("Store_Press_Pack2");

        InAppHandler.Instance.Buy_Coinspacktwo();
    }

    public void OnPress_Pack3()
    {
        //Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPress);
        //Toolbox.GameManager.Analytics_DesignEvent("Store_Press_Pack3");
        Constants.FBAnalytic_EventDesign("Store_Press_Pack3");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        InAppHandler.Instance.Buy_Coinspackthree();
    }

    public void OnPress_Pack4()
    {
        //Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPress);
        //Toolbox.GameManager.Analytics_DesignEvent("Store_Press_Pack4");

        Constants.FBAnalytic_EventDesign("Store_Press_Pack4");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        InAppHandler.Instance.Buy_Coinspackfour();
    }

    public void OnPress_Pack5()
    {
        //Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPress);
        //Toolbox.GameManager.Analytics_DesignEvent("Store_Press_Pack4");

        Constants.FBAnalytic_EventDesign("Store_Press_Pack4");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        InAppHandler.Instance.Buy_Coinspackfive();
    }
    public void OnPress_Pack6()
    {
        //Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPress);
        //Toolbox.GameManager.Analytics_DesignEvent("Store_Press_Pack4");

        Constants.FBAnalytic_EventDesign("Store_Press_Pack4");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        InAppHandler.Instance.Buy_Coinspacksix();
    }

    #endregion

    #region Cash Packs 
    public void OnPress_GunPack1()
    {
        Constants.FBAnalytic_EventDesign("Store_Press_Pack1");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        InAppHandler.Instance.Buy_Gunpackone();
    }
    public void OnPress_GunPack2()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        Constants.FBAnalytic_EventDesign("Store_Press_Pack2");
        InAppHandler.Instance.Buy_Gunpacktwo();
    }
    public void OnPress_GunPack3()
    {
        Constants.FBAnalytic_EventDesign("Store_Press_Pack3");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        InAppHandler.Instance.Buy_Gunpackthree();
    }
    public void OnPress_GunPack4()
    {
        Constants.FBAnalytic_EventDesign("Store_Press_Pack4");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        InAppHandler.Instance.Buy_Gunpackfour();
    }
    public void OnPress_GunPack5()
    {
        Constants.FBAnalytic_EventDesign("Store_Press_Pack4");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        InAppHandler.Instance.Buy_Gunpackfive();
    }
    public void OnPress_GunPack6()
    {
        Constants.FBAnalytic_EventDesign("Store_Press_Pack4");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        InAppHandler.Instance.Buy_Gunpacksix();
    }
    public void OnPress_GunPack7()
    {
        Constants.FBAnalytic_EventDesign("Store_Press_Pack4");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        InAppHandler.Instance.Buy_GunpackSeven();
    }
    public void OnPress_GunPack8()
    {
        Constants.FBAnalytic_EventDesign("Store_Press_Pack4");
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        InAppHandler.Instance.Buy_GunpackEight();
    }
    #endregion

    #region Non Consumeable 
    public void OnPress_Removeads()
    {
        //Toolbox.GameManager.Analytics_DesignEvent("Store_Removeads");

        Constants.FBAnalytic_EventDesign("Store_Removeads");
        //Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPress);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        InAppHandler.Instance.Buy_NoAds();
    }
    public void OnPress_UnlockAllChapters()
    {
        //Toolbox.GameManager.Analytics_DesignEvent("Store_UnlockAllChapters");

        Constants.FBAnalytic_EventDesign("Store_UnlockAllChapters");
        //Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPress);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        InAppHandler.Instance.Buy_AllModes();
    }
    public void OnPress_UnlockAllLevels()
    {
        //Toolbox.GameManager.Analytics_DesignEvent("Store_UnlockAllLevels");
        //Toolbox.GameManager.FBAnalytic_EventDesign("Store_UnlockAllLevels");
        //Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPress);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        InAppHandler.Instance.Buy_AllLevels();
    }
    public void OnPress_UnlockAllGuns()
    {
        //Toolbox.GameManager.Analytics_DesignEvent("Store_UnlockAllGuns");
        //Toolbox.GameManager.FBAnalytic_EventDesign("Store_UnlockAllGuns");
        //Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPress);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        InAppHandler.Instance.Buy_AllVehicles();
    }
    public void OnPress_UnlockEveryThing()
    {
        //Toolbox.GameManager.Analytics_DesignEvent("Store_UnlockEveryThing");
        //Toolbox.GameManager.FBAnalytic_EventDesign("Store_UnlockEveryThing");
        //Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPress);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        InAppHandler.Instance.Buy_MegaOffer();
    }
    public void OnPress_RestorePurchase()
    {
        //Toolbox.GameManager.Analytics_DesignEvent("Store_RestorePurchase");
        //Toolbox.GameManager.FBAnalytic_EventDesign("Store_RestorePurchase");
        //Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPress);
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        InAppHandler.Instance.Buy_Coinspackone();
    }
    public void OnPress_WatchVideo()
    {
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        try
        {
            if (FindObjectOfType<MediationHandler>())
                FindObjectOfType<MediationHandler>().ShowRewardedVideo(addstorecoins);
        }
        catch (Exception e)
        {

        }
    }
    private void addstorecoins()
    {
        Constants.SetPref(Constants.Totalreward,Constants.Getprefs(Constants.Totalreward)+300);
    }
    #endregion
}
