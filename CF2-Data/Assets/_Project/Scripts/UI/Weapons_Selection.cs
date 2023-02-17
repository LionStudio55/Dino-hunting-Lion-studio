using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

[Serializable]
public class Spec
{
    [Range(0, 1)]
    public float Damage = 1;
    [Range(0, 1)]
    public float zoom = 1;
    [Range(0, 1)]
    public float Reload = 1;
    [Range(0, 1)]
    public float Firerayt=1;
}
public class Weapons_Selection : MonoBehaviour
{
    public static Weapons_Selection instance;
   // public GameObject gunsInappbutton;

    //public Text loadingText;
    public GameObject loadingBar;
    public GameObject loading;

    public GameObject GunsPrefebs, unlock_reference;
    public GameObject GunsBuy, Rotationfix;
    public Spec[] specification;
    public GameObject[] Gun_Button;
    public GameObject[] Gun_Model;
    public Image[] Gun_Specification;
    public string[] guns_names;
    public int[] total_videos;
    public static int g_no = 0;

    public GameObject Selectbtn, PurchasedText, LowCashText, LockImage/*, InAppGuns*//*, Trial_button*/;

    private int ModleNum;
    public static bool isnextClick = false;
    public Text cash, CashRequired;

    public Text Gun_name_txt;
    public Text msg_total, total_bt, total_watch;

    private int Damage = 0;
    private int Zoom = 0;
    private int Reload = 0;
    private int FireRate = 0;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        PlayerPrefs.SetInt("Gun1", 1);

        GunCheck();
        if (PlayerPrefs.GetInt("Gun1") == 1 && PlayerPrefs.GetInt("Gun2") == 1
            && PlayerPrefs.GetInt("Gun3") == 1 && PlayerPrefs.GetInt("Gun4") == 1
            && PlayerPrefs.GetInt("Gun5") == 1 && PlayerPrefs.GetInt("Gun6") == 1
            && PlayerPrefs.GetInt("Gun7") == 1 && PlayerPrefs.GetInt("Gun8") == 1
            && PlayerPrefs.GetInt("Gun9") == 1)
        {
            //gunsInappbutton.SetActive(false);
        }

        //PlayerPrefs.DeleteAll();
        if (PlayerPrefs.GetInt("Reward") == 0)
        {

            //  PlayerPrefs.SetInt("Coins", 400000);
            PlayerPrefs.SetInt("Reward", 1);
        }
        GunsPrefebs.SetActive(true);
        // GunsButtons.SetActive(true);
        //  cash.text = ("$ " + PlayerPrefs.GetInt("cashin"));
        cash.text = ("$ " + PlayerPrefs.GetInt("Coins"));

        for (int g = 0; g < Gun_Model.Length; g++)
        {
            Gun_Model[g].SetActive(false);
            //   Gun_Specification[g].SetActive(false);
        }
        Gun_Model[g_no].SetActive(true);
        //  Gun_Specification[g_no].SetActive(true);

        if (PlayerPrefs.GetInt("isGuns") == 1)
        {
          //  InAppGuns.SetActive(false);
        }

        for (int i = 0; i < Gun_Button.Length; i++)
        {
           
            CarSelection(i);
        }


        //Ads calling 
        Smallbanner();
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
    private void OnEnable()
    {
        Menu_Manager.rewarded_type = 2;
    }



    private void Update()
    {
        if (Gun_Specification[0]) Gun_Specification[0].fillAmount = Mathf.Lerp(Gun_Specification[0].fillAmount, (specification[g_no].Damage), Time.deltaTime * 5.0f);
        if (Gun_Specification[1]) Gun_Specification[1].fillAmount = Mathf.Lerp(Gun_Specification[1].fillAmount, (specification[g_no].zoom), Time.deltaTime * 5.0f);
        if (Gun_Specification[2]) Gun_Specification[2].fillAmount = Mathf.Lerp(Gun_Specification[2].fillAmount, (specification[g_no].Reload), Time.deltaTime * 5.0f);
        if (Gun_Specification[3]) Gun_Specification[3].fillAmount = Mathf.Lerp(Gun_Specification[3].fillAmount, (specification[g_no].Firerayt), Time.deltaTime * 5.0f);
    }
    //------------------------------------------Select Any Weapons(Pistols\Guns\Rifle)-----------------------------------------


    public void Guns_Selected()
    {

        GunsPrefebs.SetActive(true);
        // GunsButtons.SetActive(true);
        if (g_no == 0)
        {
            GunsBuy.SetActive(false);
            Selectbtn.SetActive(true);
            LockImage.SetActive(false);
            CashRequired.text = ("");
        }
        else if (g_no == 1 && PlayerPrefs.GetInt("Gun1") == 0)
        {
            GunsBuy.SetActive(true);
            Selectbtn.SetActive(false);
            LockImage.SetActive(true);
            CashRequired.text = ("$15,000");
        }
        else if (g_no == 2 && PlayerPrefs.GetInt("Gun2") == 0)
        {
            GunsBuy.SetActive(true);
            Selectbtn.SetActive(false);
            LockImage.SetActive(true);
            CashRequired.text = ("$20,000");
        }
        else if (g_no == 3 && PlayerPrefs.GetInt("Gun3") == 0)
        {
            GunsBuy.SetActive(true);
            Selectbtn.SetActive(false);
            LockImage.SetActive(true);
            CashRequired.text = ("$25,000");
        }
        else if (g_no == 4 && PlayerPrefs.GetInt("Gun4") == 0)
        {
            GunsBuy.SetActive(true);
            Selectbtn.SetActive(false);
            LockImage.SetActive(true);
            CashRequired.text = ("$30,000");
        }
        else if (g_no == 5 && PlayerPrefs.GetInt("Gun5") == 0)
        {
            GunsBuy.SetActive(true);
            Selectbtn.SetActive(false);
            LockImage.SetActive(true);
            CashRequired.text = ("$50,000");
        }
        else if (g_no == 6 && PlayerPrefs.GetInt("Gun6") == 0)
        {
            GunsBuy.SetActive(true);
            Selectbtn.SetActive(false);
            LockImage.SetActive(true);
            CashRequired.text = ("$60,000");
        }
        else if (g_no == 7 && PlayerPrefs.GetInt("Gun7") == 0)
        {
            GunsBuy.SetActive(true);
            Selectbtn.SetActive(false);
            LockImage.SetActive(true);
            CashRequired.text = ("$70,000");
        }
        else if (g_no == 8 && PlayerPrefs.GetInt("Gun8") == 0)
        {
            GunsBuy.SetActive(true);
            Selectbtn.SetActive(false);
            LockImage.SetActive(true);
            CashRequired.text = ("$80,000");
        }
        else if (g_no == 8 && PlayerPrefs.GetInt("Gun9") == 0)
        {
            GunsBuy.SetActive(true);
            Selectbtn.SetActive(false);
            LockImage.SetActive(true);
            CashRequired.text = ("$90,000");
        }
        else if (g_no == 9 && PlayerPrefs.GetInt("Gun10") == 0)
        {
            GunsBuy.SetActive(true);
            Selectbtn.SetActive(false);
            LockImage.SetActive(true);
            CashRequired.text = ("$100,000");
        }
        else
        {
            GunsBuy.SetActive(false);
            Selectbtn.SetActive(true);
            LockImage.SetActive(false);
            CashRequired.text = ("");
        }
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }
    public void NextModleBtn()
    {
        if (PurchasedText.activeInHierarchy)
            PurchasedText.SetActive(false);
        //g_no 
        if (g_no < Gun_Model.Length - 1)
        {
            // StartCoroutine("NextGun");
            NextGun();
        }

        else
        {
            for (int k = 0; k < Gun_Model.Length; k++)
            {
                Gun_Model[k].SetActive(false);
                //  Gun_Specification[k].SetActive(false);
            }
            Gun_Model[0].SetActive(true);
            //  Gun_Specification[0].SetActive(true);
            g_no = 0;
            if (g_no == 0)
            {
                GunsBuy.SetActive(false);
                Selectbtn.SetActive(true);
                // LockImage.SetActive(false);
                // Trial_button.SetActive(false);
                CashRequired.text = ("");
            }

            //g_no = 0;
            //Debug.Log("Next Gun no" + g_no);
            GunCheck();
        }
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
        //SoundsManager.Instance.PlayMusic_Menu();
    }
    public void PreviousModleBtn()
    {
        if (PurchasedText.activeInHierarchy)
            PurchasedText.SetActive(false);
        // ModelNum
        if (g_no > 0)
        {
            // StartCoroutine("PreviousGun");
            PreviousGun();
        }
        else
        {
            for (int k = 0; k < Gun_Model.Length; k++)
            {
                Gun_Model[k].SetActive(false);
                // Gun_Specification[k].SetActive(false);
            }
            Gun_Model[9].SetActive(true);
            //  Gun_Specification[9].SetActive(true);

            g_no = 9;

            GunCheck();


        }
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }

    public void PreviousGun()
    {

        Gun_Model[g_no].SetActive(false);
        //Gun_Specification[g_no].SetActive(false);
        // yield return new WaitForSeconds(0.001f);
        g_no--;

        Gun_Model[g_no].SetActive(true);
        // Gun_Specification[g_no].SetActive(true);

        GunCheck();
        if (g_no == 0)
        {
            GunsBuy.SetActive(false);
            Selectbtn.SetActive(true);
            // LockImage.SetActive(false);
            //Trial_button.SetActive(false);

            CashRequired.text = ("");
        }
        //Debug.Log("Prev Gun no IEnumerator" + g_no);

    }
    public void NextGun()
    {
        Gun_Model[g_no].SetActive(false);
        //Gun_Specification[g_no].SetActive(false);
        g_no++;
        Gun_Model[g_no].SetActive(true);



        GunCheck();

    }
    private void GunCheck()
    {
       

        //msg_total.text = total_videos[g_no].ToString();
        //total_bt.text = total_videos[g_no].ToString();
        //total_watch.text = PlayerPrefs.GetInt("video_ads" + g_no).ToString();
        //Gun_Specification[g_no].SetActive(true);
        Gun_name_txt.text = guns_names[g_no].ToString();
      //  Gun_name_txt.transform.parent.GetComponent<Animator>().Play("slide");
        unlock_reference.SetActive(false);
        //print ("GunChecked");
        if (g_no == 0)
        {
            GunsBuy.SetActive(false);
            // Trial_button.SetActive(false);
            Gun_Button[g_no].transform.GetChild(2).gameObject.SetActive(false);
            Selectbtn.SetActive(true);
            //LockImage.SetActive(false);
            PlayerPrefs.SetInt("selected_gun", g_no);

            CashRequired.text = ("");
        }
        else if (g_no == 1 && PlayerPrefs.GetInt("Gun1") == 1)
        {
            GunsBuy.SetActive(false);
            Selectbtn.SetActive(true);
            // Trial_button.SetActive(false);
            Gun_Button[g_no].transform.GetChild(2).gameObject.SetActive(false);
            // LockImage.SetActive(false);
            PlayerPrefs.SetInt("selected_gun", g_no);
            CashRequired.text = ("");
        }
        else if (g_no == 2 && PlayerPrefs.GetInt("Gun2") == 1)
        {
            GunsBuy.SetActive(false);
            Selectbtn.SetActive(true);
            // Trial_button.SetActive(false);
            Gun_Button[g_no].transform.GetChild(2).gameObject.SetActive(false);
            // LockImage.SetActive(false);
            PlayerPrefs.SetInt("selected_gun", g_no);
            CashRequired.text = ("");
            unlock_reference.SetActive(false);
        }
        else if (g_no == 3 && PlayerPrefs.GetInt("Gun3") == 1)
        {
            GunsBuy.SetActive(false);
            Selectbtn.SetActive(true);
            // Trial_button.SetActive(false);
            Gun_Button[g_no].transform.GetChild(2).gameObject.SetActive(false);
            //LockImage.SetActive(false);
            PlayerPrefs.SetInt("selected_gun", g_no);
            CashRequired.text = ("");
        }
        else if (g_no == 4 && PlayerPrefs.GetInt("Gun4") == 1)
        {
            GunsBuy.SetActive(false);
            Selectbtn.SetActive(true);
            // Trial_button.SetActive(false);
            Gun_Button[g_no].transform.GetChild(2).gameObject.SetActive(false);
            //LockImage.SetActive(false);
            PlayerPrefs.SetInt("selected_gun", g_no);
            CashRequired.text = ("");
        }
        else if (g_no == 5 && PlayerPrefs.GetInt("Gun5") == 1)
        {
            GunsBuy.SetActive(false);
            Selectbtn.SetActive(true);
            // Trial_button.SetActive(false);
            Gun_Button[g_no].transform.GetChild(2).gameObject.SetActive(false);
            //LockImage.SetActive(false);
            PlayerPrefs.SetInt("selected_gun", g_no);
            CashRequired.text = ("");
        }
        else if (g_no == 6 && PlayerPrefs.GetInt("Gun6") == 1)
        {
            GunsBuy.SetActive(false);
            Selectbtn.SetActive(true);
            // Trial_button.SetActive(false);
            Gun_Button[g_no].transform.GetChild(2).gameObject.SetActive(false);
            //LockImage.SetActive(false);
            PlayerPrefs.SetInt("selected_gun", g_no);
            CashRequired.text = ("");
        }
        else if (g_no == 7 && PlayerPrefs.GetInt("Gun7") == 1)
        {
            GunsBuy.SetActive(false);
            Selectbtn.SetActive(true);
            // Trial_button.SetActive(false);
            Gun_Button[g_no].transform.GetChild(2).gameObject.SetActive(false);
            //LockImage.SetActive(false);
            PlayerPrefs.SetInt("selected_gun", g_no);
            CashRequired.text = ("");
        }
        else if (g_no == 8 && PlayerPrefs.GetInt("Gun8") == 1)
        {
            GunsBuy.SetActive(false);
            Selectbtn.SetActive(true);
            // Trial_button.SetActive(false);
            Gun_Button[g_no].transform.GetChild(2).gameObject.SetActive(false);
            //LockImage.SetActive(false);
            PlayerPrefs.SetInt("selected_gun", g_no);
            CashRequired.text = ("");
        }
        else if (g_no == 9 && PlayerPrefs.GetInt("Gun9") == 1)
        {
            GunsBuy.SetActive(false);
            Selectbtn.SetActive(true);
            //Trial_button.SetActive(false);
            Gun_Button[g_no].transform.GetChild(2).gameObject.SetActive(false);
            //LockImage.SetActive(false);
            PlayerPrefs.SetInt("selected_gun", g_no);
            CashRequired.text = ("");
        }
        else if (g_no == 10 && PlayerPrefs.GetInt("Gun10") == 1)
        {
            GunsBuy.SetActive(false);
            Selectbtn.SetActive(true);
            //Trial_button.SetActive(false);
            Gun_Button[g_no].transform.GetChild(2).gameObject.SetActive(false);
            //LockImage.SetActive(false);
            PlayerPrefs.SetInt("selected_gun", g_no);
            CashRequired.text = ("");
        }
        else
        {
            GunsBuy.SetActive(true);
            // Trial_button.SetActive(true);

            Selectbtn.SetActive(false);
            //LockImage.SetActive(true);
            if (g_no == 1)
            {
                CashRequired.text = ("$10,000");
                unlock_reference.SetActive(false);
                Gun_Button[g_no].transform.GetChild(2).gameObject.SetActive(true);
            }
            else if (g_no == 2)
            {
                CashRequired.text = ("$20,000");
                unlock_reference.SetActive(true);
                GunsBuy.SetActive(false);
                Gun_Button[g_no].transform.GetChild(2).gameObject.SetActive(true);
            }
            else if (g_no == 3)
            {
                CashRequired.text = ("$60,000");
                unlock_reference.SetActive(false);
                Gun_Button[g_no].transform.GetChild(2).gameObject.SetActive(true);

            }
            else if (g_no == 4)
            {
                CashRequired.text = ("$90,000");
                unlock_reference.SetActive(false);
                Gun_Button[g_no].transform.GetChild(2).gameObject.SetActive(true);

            }
            else if (g_no == 5)
            {
                CashRequired.text = ("$110,000");
                unlock_reference.SetActive(false);      
                Gun_Button[g_no].transform.GetChild(2).gameObject.SetActive(true);

            }
            else if (g_no == 6)
            {
                CashRequired.text = ("$130,000");
                unlock_reference.SetActive(false);
                Gun_Button[g_no].transform.GetChild(2).gameObject.SetActive(true);

            }
            else if (g_no == 7)
            {
                CashRequired.text = ("$150,000");
                unlock_reference.SetActive(false);
                Gun_Button[g_no].transform.GetChild(2).gameObject.SetActive(true);

            }
            else if (g_no == 8)
            {
                CashRequired.text = ("$170,000");
                unlock_reference.SetActive(false);
                Gun_Button[g_no].transform.GetChild(2).gameObject.SetActive(true);

            }
            else if (g_no == 9)
            {
                CashRequired.text = ("$200,000");
                unlock_reference.SetActive(false);
                Gun_Button[g_no].transform.GetChild(2).gameObject.SetActive(true);

            }


        }
    }

    //------------------------------------------Select Pistols, Guns, Rifle Models -----------------------------------------

    public void Select_Gun(int Gun)
    {
        g_no = Gun;
        //print("g_no " + g_no);
        for (int i = 0; i < Gun_Specification.Length; i++)
        {
            // Gun_Specification[i].SetActive(false);
        }
        if (g_no == 0)
        {
            GunsBuy.SetActive(false);
            //  Trial_button.SetActive(false);
            Selectbtn.SetActive(true);
            //LockImage.SetActive(false);
            CashRequired.text = ("");
            //   Gun_Specification[g_no].SetActive(true);
        }
        else if (g_no == 1 && PlayerPrefs.GetInt("Gun1") == 0)
        {
            GunsBuy.SetActive(true);
            // Trial_button.SetActive(true);
            Selectbtn.SetActive(false);
            //LockImage.SetActive(true);
            CashRequired.text = ("$15,000");
            // Gun_Specification[g_no].SetActive(true);
        }
        else if (g_no == 2 && PlayerPrefs.GetInt("Gun2") == 0)
        {
            GunsBuy.SetActive(true);
            // Trial_button.SetActive(true);

            Selectbtn.SetActive(false);
            //LockImage.SetActive(true);
            CashRequired.text = ("$20,000");
            // Gun_Specification[g_no].SetActive(true);
        }
        else if (g_no == 3 && PlayerPrefs.GetInt("Gun3") == 0)
        {
            GunsBuy.SetActive(true);
            // Trial_button.SetActive(true);

            Selectbtn.SetActive(false);
            //LockImage.SetActive(true);
            CashRequired.text = ("$25,000");
            //  Gun_Specification[g_no].SetActive(true);
        }
        else if (g_no == 4 && PlayerPrefs.GetInt("Gun4") == 0)
        {
            GunsBuy.SetActive(true);
            // Trial_button.SetActive(true);

            Selectbtn.SetActive(false);
            //LockImage.SetActive(true);
            CashRequired.text = ("$30,000");
            // Gun_Specification[g_no].SetActive(true);
        }
        else if (g_no == 5 && PlayerPrefs.GetInt("Gun5") == 0)
        {
            GunsBuy.SetActive(true);
            Selectbtn.SetActive(false);
            //LockImage.SetActive(true);
            CashRequired.text = ("$50,000");
            //  Gun_Specification[g_no].SetActive(true);
        }
        else
        {
            if (g_no == 0)
            {
                GunsBuy.SetActive(false);
                Selectbtn.SetActive(true);
                //LockImage.SetActive(false);
                CashRequired.text = ("");
                //   Gun_Specification[g_no].SetActive(true);
            }
            else if (g_no == 1)
            {
                GunsBuy.SetActive(false);
                Selectbtn.SetActive(true);
                //LockImage.SetActive(false);
                CashRequired.text = ("");
                //  Gun_Specification[g_no].SetActive(true);
            }
            else if (g_no == 2)
            {
                GunsBuy.SetActive(false);
                Selectbtn.SetActive(true);
                // LockImage.SetActive(false);
                CashRequired.text = ("");
                //  Gun_Specification[g_no].SetActive(true);
            }
            else if (g_no == 3)
            {
                GunsBuy.SetActive(false);
                Selectbtn.SetActive(true);
                //LockImage.SetActive(false);
                CashRequired.text = ("");
                //  Gun_Specification[g_no].SetActive(true);
            }
            else if (g_no == 4)
            {
                GunsBuy.SetActive(false);
                Selectbtn.SetActive(true);
                //LockImage.SetActive(false);
                CashRequired.text = ("");
                //  Gun_Specification[g_no].SetActive(true);
            }
            //GunsBuy.SetActive(false);
            //Selectbtn.SetActive(true);
            //LockImage.SetActive(false);
            //CashRequired.text = ("");
        }
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }

    public void CarSelection(int Click)
    {
        for (int i = 0; i < Gun_Model.Length; i++)
        {
            Gun_Model[i].SetActive(false);
        }
        Gun_Model[Click].SetActive(true);
        //  Gun_Specification[Click].SetActive(true);
        g_no = Click;

        for (int i = 0; i < Gun_Button.Length; i++)
        {
            if (g_no == i && PlayerPrefs.GetInt("Gun" + i) == 1)
            {
                Gun_Button[g_no].transform.GetChild(3).gameObject.SetActive(true);
            }
            else
            {
                Gun_Button[g_no].transform.GetChild(3).gameObject.SetActive(false);
            }
           
        }
        GunCheck();

    }


    public void buy_Guns()
    {
        if (g_no == 1 && PlayerPrefs.GetInt("Coins") >= 10000)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 10000);
            PlayerPrefs.SetInt("Gun1", 1);
            cash.text = ("$ " + PlayerPrefs.GetInt("Coins"));
            GunsBuy.SetActive(false);
            PurchasedText.SetActive(true);
            Selectbtn.SetActive(true);
            //Trial_button.SetActive(false);

            //LockImage.SetActive(false);
            CashRequired.text = "";
            Invoke("textoff", 3f);

            PlayerPrefs.SetInt("selected_gun", g_no);
        }

        else if (g_no == 2 && PlayerPrefs.GetInt("Coins") >= 60000)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 60000);
            PlayerPrefs.SetInt("Gun2", 1);
            cash.text = ("$ " + PlayerPrefs.GetInt("Coins"));
            GunsBuy.SetActive(false);
            PurchasedText.SetActive(true);
            Selectbtn.SetActive(true);
            // Trial_button.SetActive(false);
            //LockImage.SetActive(false);
            CashRequired.text = "";
            PlayerPrefs.SetInt("selected_gun", g_no);
            Invoke("textoff", 3f);
        }
        else if (g_no == 3 && PlayerPrefs.GetInt("Coins") >= 60000)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 60000);
            PlayerPrefs.SetInt("Gun3", 1);
            cash.text = ("$ " + PlayerPrefs.GetInt("Coins"));
            GunsBuy.SetActive(false);
            PurchasedText.SetActive(true);
            Selectbtn.SetActive(true);
            //  Trial_button.SetActive(false);
            //LockImage.SetActive(false);
            CashRequired.text = "";
            PlayerPrefs.SetInt("selected_gun", g_no);
            Invoke("textoff", 3f);
        }
        else if (g_no == 4 && PlayerPrefs.GetInt("Coins") >= 90000)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 90000);
            PlayerPrefs.SetInt("Gun4", 1);
            cash.text = ("$ " + PlayerPrefs.GetInt("Coins"));
            GunsBuy.SetActive(false);
            PurchasedText.SetActive(true);
            Selectbtn.SetActive(true);
            // Trial_button.SetActive(false);
            //LockImage.SetActive(false);
            CashRequired.text = "";
            PlayerPrefs.SetInt("selected_gun", g_no);
            Invoke("textoff", 3f);
        }
        else if (g_no == 5 && PlayerPrefs.GetInt("Coins") >= 110000)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 110000);
            PlayerPrefs.SetInt("Gun5", 1);
            cash.text = ("$ " + PlayerPrefs.GetInt("Coins"));
            GunsBuy.SetActive(false);
            PurchasedText.SetActive(true);
            Selectbtn.SetActive(true);
            //  Trial_button.SetActive(false);
            // LockImage.SetActive(false);
            CashRequired.text = "";
            PlayerPrefs.SetInt("selected_gun", g_no);
            Invoke("textoff", 3f);
        }
        else if (g_no == 6 && PlayerPrefs.GetInt("Coins") >= 130000)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 130000);
            PlayerPrefs.SetInt("Gun6", 1);
            cash.text = ("$ " + PlayerPrefs.GetInt("Coins"));
            GunsBuy.SetActive(false);
            PurchasedText.SetActive(true);
            Selectbtn.SetActive(true);
            // Trial_button.SetActive(false);
            //LockImage.SetActive(false);
            CashRequired.text = "";
            PlayerPrefs.SetInt("selected_gun", g_no);
            Invoke("textoff", 3f);
        }
        else if (g_no == 7 && PlayerPrefs.GetInt("Coins") >= 150000)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 150000);
            PlayerPrefs.SetInt("Gun7", 1);
            cash.text = ("$ " + PlayerPrefs.GetInt("Coins"));
            GunsBuy.SetActive(false);
            PurchasedText.SetActive(true);
            Selectbtn.SetActive(true);
            //  Trial_button.SetActive(false);
            // LockImage.SetActive(false);
            CashRequired.text = "";
            PlayerPrefs.SetInt("selected_gun", g_no);
            Invoke("textoff", 3f);
        }
        else if (g_no == 8 && PlayerPrefs.GetInt("Coins") >= 170000)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 170000);
            PlayerPrefs.SetInt("Gun8", 1);
            cash.text = ("$ " + PlayerPrefs.GetInt("Coins"));
            GunsBuy.SetActive(false);
            PurchasedText.SetActive(true);
            Selectbtn.SetActive(true);
            //  Trial_button.SetActive(false);
            //LockImage.SetActive(false);
            CashRequired.text = "";
            PlayerPrefs.SetInt("selected_gun", g_no);
            Invoke("textoff", 3f);
        }
        else if (g_no == 9 && PlayerPrefs.GetInt("Coins") >= 200000)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 200000);
            PlayerPrefs.SetInt("Gun9", 1);
            cash.text = ("$ " + PlayerPrefs.GetInt("Coins"));
            GunsBuy.SetActive(false);
            PurchasedText.SetActive(true);
            Selectbtn.SetActive(true);
            //  Trial_button.SetActive(false);
            // LockImage.SetActive(false);
            CashRequired.text = "";
            PlayerPrefs.SetInt("selected_gun", g_no);
            Invoke("textoff", 3f);
        }
        else if (g_no == 10 && PlayerPrefs.GetInt("Coins") >= 100000)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 100000);
            PlayerPrefs.SetInt("Gun10", 1);
            cash.text = ("$ " + PlayerPrefs.GetInt("Coins"));
            GunsBuy.SetActive(false);
            PurchasedText.SetActive(true);
            Selectbtn.SetActive(true);
            // Trial_button.SetActive(false);
            //LockImage.SetActive(false);
            CashRequired.text = "";
            PlayerPrefs.SetInt("selected_gun", g_no);
            Invoke("textoff", 3f);
        }
        else
        {
            LowCashText.SetActive(true);
            //LowCashText.transform.GetChild(1).gameObject.SetActive(true);
            //LowCashText.transform.GetChild(2).gameObject.SetActive(false);
            Menu_Manager.rewarded_type = 3;
            Invoke("textoff", 3f);
        }
        SoundsManager.Instance.PlaySound(SoundsManager.Instance.buttonPress);
    }

    IEnumerator LoadScene()
    {
        yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("GP_Handler_UZ");
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        //Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            loadingBar.GetComponent<Slider>().value += 0.005f;
            string percent = (loadingBar.GetComponent<Slider>().value * 100).ToString("F0");
            // loadingText.text = string.Format("<size=35>{0}%</size>", percent);
            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f && loadingBar.GetComponent<Slider>().value == 1.0f)
            {
                //Change the Text to show the Scene is ready
                asyncOperation.allowSceneActivation = true;

            }

            yield return null;
        }
    }

    public void onSelect()
    {
        PlayerPrefs.SetInt("curr_lvl", 1);
        if (loading)
            loading.SetActive(true);
        IAD();
        MediumBanner();
        StartCoroutine(LoadScene());

    }

    private void textoff()
    {
        PurchasedText.SetActive(false);
        //LowCashText.SetActive(false);
    }

    public void backButton()
    {
        Menu_Manager.NextLevel = true;

        Application.LoadLevel(Application.loadedLevel - 1);

    }

    public void unlockallguns()
    {

        //InApp_Manager.instance.Buy_UnlockAll_Guns();//Inam
    }
    public void Unlock_gun_video()
    {
        int count = PlayerPrefs.GetInt("video_ads" + g_no) + 1;
        PlayerPrefs.SetInt("video_ads" + g_no, count);
        total_watch.text = PlayerPrefs.GetInt("video_ads" + g_no).ToString();
        Debug.Log(PlayerPrefs.GetInt("video_ads" + g_no));
        if (PlayerPrefs.GetInt("video_ads" + g_no) == total_videos[g_no])
        {
            Weapons_Selection.instance.LowCashText.transform.GetChild(1).gameObject.SetActive(false);
            Weapons_Selection.instance.LowCashText.transform.GetChild(2).gameObject.SetActive(true);
            GunsBuy.SetActive(false);
            //  Trial_button.SetActive(false);
            Selectbtn.SetActive(true);
            //LockImage.SetActive(false);
            switch (g_no)
            {
                case 1:
                    PlayerPrefs.SetInt("Gun1", 1);
                    break;
                case 2:
                    PlayerPrefs.SetInt("Gun2", 1);
                    break;
                case 3:
                    PlayerPrefs.SetInt("Gun3", 1);
                    break;
                case 4:
                    PlayerPrefs.SetInt("Gun4", 1);
                    break;
                case 5:
                    PlayerPrefs.SetInt("Gun5", 1);
                    break;
                case 6:
                    PlayerPrefs.SetInt("Gun6", 1);
                    break;
                case 7:
                    PlayerPrefs.SetInt("Gun7", 1);
                    break;
                case 8:
                    PlayerPrefs.SetInt("Gun8", 1);
                    break;
                case 9:
                    PlayerPrefs.SetInt("Gun9", 1);
                    break;
                case 10:
                    PlayerPrefs.SetInt("Gun10", 1);
                    break;
            }
        }
        else
        {
            Weapons_Selection.instance.LowCashText.transform.GetChild(1).gameObject.SetActive(true);
            Weapons_Selection.instance.LowCashText.transform.GetChild(2).gameObject.SetActive(false);

        }

    }
    public void no_video()
    {
        Menu_Manager.rewarded_type = 2;
    }
    public void rewarded_video()
    {

        //GRS_Ads.Instance.ShowRewardedVideo();

    }
    public GameObject Rewarded_coins;
    public void coins_get()
    {
        Rewarded_coins.SetActive(true);
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 200);
        cash.text = ("" + PlayerPrefs.GetInt("Coins"));
        Invoke("waited", 2f);
    }
    void waited()
    {
        Rewarded_coins.SetActive(false);

    }

    /// Trial
    public GameObject Unlock_gun_trail;
    public void Unlock_gun_Trial()
    {
        Weapons_Selection.instance.Unlock_gun_trail.transform.GetChild(1).gameObject.SetActive(false);
        Weapons_Selection.instance.Unlock_gun_trail.transform.GetChild(2).gameObject.SetActive(true);
        GunsBuy.SetActive(false);
        Selectbtn.SetActive(true);
        //LockImage.SetActive(false);
        // Trial_button.SetActive(false);

    }
    public void onclick_Trial()
    {
        Unlock_gun_trail.SetActive(true);
        Menu_Manager.rewarded_type = 1;
    }
    public void no_video_trail()
    {
        Menu_Manager.rewarded_type = 2;
        Weapons_Selection.instance.Unlock_gun_trail.transform.GetChild(1).gameObject.SetActive(true);
        Weapons_Selection.instance.Unlock_gun_trail.transform.GetChild(2).gameObject.SetActive(false);
    }






    // Weapons_Rotations

    public Animator MainCamera_Anim;
    public GameObject[] UI_all;
    public void Rotate_gun_Down()
    {
        MainCamera_Anim.Play("zoom");
        for (int a = 0; a < UI_all.Length; a++)
        {
            UI_all[a].SetActive(false);
        }
        Gun_Model[g_no].GetComponent<CapsuleCollider>().enabled = true;
    }
    public void Rotate_gun_Up()
    {
        MainCamera_Anim.Play("zoomout");
        for (int a = 0; a < UI_all.Length; a++)
        {
            UI_all[a].SetActive(true);
        }
        Gun_Model[g_no].transform.rotation = Rotationfix.transform.rotation;
        Gun_Model[g_no].GetComponent<CapsuleCollider>().enabled = false;

    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("backmode", 0);
    }
    public void maincam()
    {
        if (camoff.instance)
        {
            camoff.instance.cam.SetActive(true);
        }
    }

    public void OnMoreButtonClicked()
    {
        Application.OpenURL("https://play.google.com/store/apps/dev?id=8343798540401422884");
    }
}