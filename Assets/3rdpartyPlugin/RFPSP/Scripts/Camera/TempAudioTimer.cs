//TempAudioTimer.cs by Azuline Studios© All Rights Reserved
//deactivates temporary audio object after it finishes playing
using UnityEngine;
using System.Collections;

public class TempAudioTimer : MonoBehaviour {

	[HideInInspector]
	public AudioSource aSource;
	private GameObject obj;

	void Awake () {
		obj = transform.gameObject;
	}
	
	public IEnumerator DeactivateTimer(){
		if (GPULevelChecker.graphicLevelGPUBased != GPULevelChecker.GraphicLevelGPUBased.Low)
		{
			yield return new WaitForSeconds(aSource.clip.length);
			obj.SetActive(false);
		}
	}
}
