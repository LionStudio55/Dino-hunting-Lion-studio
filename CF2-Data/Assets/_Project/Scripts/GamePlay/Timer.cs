using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public Text timerText;
   
    public float time;
    public GameObject Timeup;
    public bool Timeclose = false;
	string minutes,seconds;
    // Use this for initialization
    public static Timer timemanager;

	void Awake () {
        time = 300f;
        timemanager = this;
        //GlobalScripts.GameStarted = true;
        //GlobalScripts.timeOver = false;
        Time.timeScale = 0.0000001f;
    }
	
	void Update () {
		
		if (Global_Scripts.timeOver == false && Global_Scripts.GameStarted == true && !Timeclose)
		{
			minutes = ((int)time / 60).ToString ();
			seconds = (time % 60).ToString ("f0");

			timerText.text = minutes + ":" + seconds;

			time -= Time.deltaTime;
//            BestTime.text = minutes + ":" + seconds;
            if (time<10f)
            {
                timerText.color = Color.red;
            }

			if (time <= 0  && Global_Scripts.timeOver == false)
			{
				Global_Scripts.timeOver = true;
                Timeup.SetActive(true);
				UI_Manager.instance.Level_Failed();

            }

//		
		}

	}
    public void stoptime()
    {
        Timeclose = true;
        timerText.gameObject.SetActive(false);
    }



}
