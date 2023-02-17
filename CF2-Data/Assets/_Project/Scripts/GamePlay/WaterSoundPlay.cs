using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSoundPlay : MonoBehaviour
{
    public AudioSource watersound;
    public static bool soundon = false;
    bool playsound;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            playsound = true;
            CharacterMotor.FindObjectOfType<CharacterMotor>().walk.clip = CharacterMotor.FindObjectOfType<CharacterMotor>().soundsclips[1];
            CharacterMotor.FindObjectOfType<CharacterMotor>().walk.Play();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playsound = false;
            CharacterMotor.FindObjectOfType<CharacterMotor>().walk.clip = CharacterMotor.FindObjectOfType<CharacterMotor>().soundsclips[0];
            CharacterMotor.FindObjectOfType<CharacterMotor>().walk.Play();
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
