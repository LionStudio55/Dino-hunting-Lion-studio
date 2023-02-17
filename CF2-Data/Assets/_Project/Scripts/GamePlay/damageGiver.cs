using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageGiver : MonoBehaviour {
	public int DamageToGive;
	public GameObject DamageImage;
	public GameObject HitFx;
    public int DamageHealth=10;
	// Use this for initialization
	void Start () {
		
        DamageImage=GameObject.FindGameObjectWithTag("GameController").GetComponent<UI_Manager>().BloodImage;
    }
//	
//	// Update is called once per frame
//	void Update () {
//		
//	}

	void OnCollisionEnter(Collision collision)
	{
//		Debug.Log ("Collide "+collision.gameObject.tag);
	}

	void OnTriggerEnter(Collider other)
	{
		
		Debug.Log ("Trigger "+other.gameObject.tag);
		if (other.gameObject.CompareTag ("Player")) {
			DamageImage.SetActive (true);
			Invoke ("HideImage",1f);
			other.gameObject.GetComponent<DamageCharacter> ().ApplyDamage (DamageHealth);


		}
	}


	void OnDestroy() {
		print("Script was destroyed");
		//DamageImage.SetActive (false);
	}

	public void HideImage(){
		DamageImage.SetActive (false);
	}
}
