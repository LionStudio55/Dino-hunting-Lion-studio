using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash_Screen : MonoBehaviour
{
    
    // Start is called before the first frame update
    public GameObject Splaah_screen, Privcy_Screen;
    void Start()
    {
        
        if (PlayerPrefs.GetInt("privcy") == 1)
        {
            Splaah_screen.SetActive(true);
            Privcy_Screen.SetActive(false);
            Invoke("wait", 7f);
    

        }
        else
        {
            Privcy_Screen.SetActive(true);
            Splaah_screen.SetActive(false);

        }
        
    }

    // Update is called once per frame
    void wait()
    {

        SceneManager.LoadScene(1);
      
    }

    public void ok()
    {
        PlayerPrefs.SetInt("privcy", 1);
        Splaah_screen.SetActive(true);
        Privcy_Screen.SetActive(false);
        
        Invoke("wait", 6f);

     

    }

    public void privcy_link()
    {
        Application.OpenURL("https://theplayright.blogspot.com/2019/06/play-right-background-we-will-strictly.html");
    }

    private void OnDisable()
    {
       
    }

}
