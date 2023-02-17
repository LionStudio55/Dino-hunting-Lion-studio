using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdsConsentFirstController : MonoBehaviour
{


    public GameObject Privacypanel, UserSplash;
    public string PrivacyLink;
    public static int firstcount = 0;
 
    void Start()
    {

        if (PlayerPrefs.GetInt("ConsentAd", 0) == 0)
        {
            Privacypanel.SetActive(true);
            UserSplash.SetActive(false);
        }
        else
        {
            Privacypanel.SetActive(false);
            UserSplash.SetActive(true);
            StartCoroutine(WaitForMainMenu());
        }
        Time.timeScale = 1f;
    }

   
    void Consent1Load()
    {
        UserSplash.SetActive(false);

    }

  
    public void MoreApps()
    {

        if (!(Application.internetReachability == NetworkReachability.NotReachable))
        {
            Application.OpenURL("https://play.google.com/store/apps/developer?id=MegaGamez");
        }

    }
   

    public void Okbutton()
    {
        UserSplash.SetActive(true);
        Privacypanel.SetActive(false);

        PlayerPrefs.SetInt("ConsentAd", 1);
        StartCoroutine(WaitForMainMenu());


    }
    public void On_withdraw()
    {
        PlayerPrefs.SetInt("ConsentAd", 0);

    }

    public void On_consentokMainbutton()
    {

        PlayerPrefs.SetInt("ConsentAd", 1);

    }
    IEnumerator WaitForMainMenu()
    {

        yield return new WaitForSeconds(3f);
        //if (AdsManager.Instance)
        //    AdsManager.Instance.ShowInterstitialAd();
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(1);

    }


    public void PrivacyOpen()
    {
        Application.OpenURL(PrivacyLink);
    }
}
