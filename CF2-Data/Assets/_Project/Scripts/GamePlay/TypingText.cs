using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TypingText : MonoBehaviour {

	// Use this for initialization

	public float TimePause = 0.0001f;
	string Complete_Text=null;
	char[] CharText=null;
    public GameObject Main_panel;
    public string[] Objective_str, Objective_str1, Objective_str2, Objective_str3, Objective_str4;
	public AudioClip _AudioClip;
	AudioSource _AudioSource;

	public Text DlgBar_Text;

    //public GameObject Joystick;

    private void OnEnable()
    {
		try
		{
			if (FindObjectOfType<MediationHandler>())
			{
				FindObjectOfType<MediationHandler>().ShowMediumBanner(GoogleMobileAds.Api.AdPosition.BottomLeft);
				//FindObjectOfType<MediationHandler>().hideSmallBanner();
			}
		}
		catch (Exception e)
		{
		}
	}
    private void OnDisable()
    {
		try
		{
			if (FindObjectOfType<MediationHandler>())
			{
				FindObjectOfType<MediationHandler>().hideMediumBanner();
			}
		}
		catch (Exception e)
		{
		}
	}
    void Start () {
		//ShowDlgBar ("Welcome commander !. it's me Grace in this mission you need to clear up the town from the Criminals... Be cautious commander..! We don't wanna lose our most skilled officer.");
		_AudioSource = DlgBar_Text.GetComponent<AudioSource>();

		if (Constants.Getprefs(Constants.lastselectedMode)== 0)
        {
			ShowDlgBar("Kill  " /*+ LevelsHandler.instance.Total_TargetCount + " " */+ Objective_str[Constants.Getprefs(Constants.lastselectedLevel)] + " " + LevelsHandler.instance.TimeCount[Constants.Getprefs(Constants.lastselectedLevel)] + " Seconds");

		}
		else if (Constants.Getprefs(Constants.lastselectedMode) == 1)
		{
			//ShowDlgBar("Kill  " + UI_Manager.instance.kills[Constants.Getprefs(Constants.lastselectedLevel)] + " " + Objective_str1[Constants.Getprefs(Constants.lastselectedLevel)] + " " + LevelsHandler.instance.TimeCount[Constants.Getprefs(Constants.lastselectedLevel)] + " Seconds");
			ShowDlgBar("Kill  " /*+ LevelsHandler.instance.Total_TargetCount + " "*/ + Objective_str1[Constants.Getprefs(Constants.lastselectedLevel)] + " " + LevelsHandler.instance.TimeCount[Constants.Getprefs(Constants.lastselectedLevel)] + " Seconds");

		}
		else if (Constants.Getprefs(Constants.lastselectedMode) == 2)
		{
			ShowDlgBar("Kill  " /*+ LevelsHandler.instance.Total_TargetCount + " "*/ + Objective_str2[Constants.Getprefs(Constants.lastselectedLevel)] + " " + LevelsHandler.instance.TimeCount[Constants.Getprefs(Constants.lastselectedLevel)] + " Seconds");

		}
		else if (Constants.Getprefs(Constants.lastselectedMode) == 3)
		{
			ShowDlgBar("Kill  " /*+ LevelsHandler.instance.Total_TargetCount + " "*/ + Objective_str3[Constants.Getprefs(Constants.lastselectedLevel)] + " " + LevelsHandler.instance.TimeCount[Constants.Getprefs(Constants.lastselectedLevel)] + " Seconds");

		}
		else if (Constants.Getprefs(Constants.lastselectedMode) == 4)
		{
			ShowDlgBar("Kill  " /*+ LevelsHandler.instance.Total_TargetCount + " "*/ + Objective_str4[Constants.Getprefs(Constants.lastselectedLevel)] + " " + LevelsHandler.instance.TimeCount[Constants.Getprefs(Constants.lastselectedLevel)] + " Seconds");

		}
	}
	public void ShowDlgBar(string messege)
	{
		
	
		CharText = messege.ToCharArray();
		Complete_Text = null;
		DlgBar_Text.text=null;
		DlgBar_Text.enabled = true;
		StartCoroutine (typeText());

		}

	IEnumerator typeText()
	{
		for (int i = 0; i <=CharText.Length; i++) {
			if (i!=CharText.Length) {
				Complete_Text += CharText [i].ToString();
				DlgBar_Text.text = Complete_Text;
				_AudioSource.clip = _AudioClip;
				_AudioSource.Play();
			} 
			yield return new WaitForSeconds (TimePause);
            LevelsHandler.instance.pause_con = true;
			_AudioSource.Stop();
		}
		LevelsHandler.instance.ins_data();
		yield return new WaitForSeconds(0.5f);
		Main_panel.SetActive(true);
		Time.timeScale = 0.0f;
	}

	


}
