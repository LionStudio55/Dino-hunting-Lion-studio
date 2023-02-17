using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FPSCSHARP : MonoBehaviour {


	public float updateInterval = 0.5f;

	private float accum = 0.0f; // FPS accumulated over the interval
	private float frames = 0.0f; // Frames drawn over the interval
	private float timeleft;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		    timeleft -= Time.deltaTime;
		    accum += Time.timeScale/Time.deltaTime;
		    ++frames;
		   
		    // Interval ended - update GUI text and start new interval
		    if( timeleft <= 0.0f )
		    {
		        // display two fractional digits (f2 format)
			GetComponent<Text>().text = "Q" + QualitySettings.GetQualityLevel() +"FPS = " + (accum/frames).ToString("f2");
		        timeleft = updateInterval;
		        accum = 0.0f;
		        frames = 0.0f;
		    }
	}
}
