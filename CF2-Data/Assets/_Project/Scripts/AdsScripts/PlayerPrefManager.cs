using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerPrefManager : MonoBehaviour {

	public static PlayerPrefManager _instance;

	private void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
		}
		else if (_instance != this)
		{
			Destroy(gameObject);
		}
	}

	public static PlayerPrefManager Instance
	{

		get
		{

			if (_instance == null)
			{

				try
				{
					_instance = GameObject.FindObjectOfType<PlayerPrefManager>();
				}
				catch (Exception e)
				{
					Debug.Log(e.Message);
					_instance = new PlayerPrefManager();
				}

			}

			return _instance;

		}

	}

    public void RemoveAds()
    {
		try
		{
			if (FindObjectOfType<MediationHandler>())
			{
				FindObjectOfType<MediationHandler>().hideMediumBanner();
				FindObjectOfType<MediationHandler>().hideSmallBanner();
			}

		}
		catch (Exception e)
        {

        }
        PlayerPrefs.SetInt("RemoveAds", 1);
    }
	public void unlocklevels()
	{
		Constants.SetPref(Constants.Mode2Unlock,1);
		Constants.SetPref(Constants.Mode3Unlock, 1);
		Constants.SetPref(Constants.Mode4Unlock, 1);
		Constants.SetPref(Constants.Mode5Unlock, 1);
		//PlayerPrefs.SetInt("Unlocked", 59);
		//PlayerPrefs.SetInt("Unlocked1", 19);
		//PlayerPrefs.SetInt("Unlocked2", 19);
		//PlayerPrefs.SetInt("Unlocked3", 19);
	}
    public void unlockguns()
	{
	
	}
    public void UnLocKAllGame()
    {
		RemoveAds();
		unlocklevels();
		unlockguns();
	}
	 void OnDisable()
	{
		_instance = null;
	}



}
