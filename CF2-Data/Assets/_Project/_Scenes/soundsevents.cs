using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundsevents : MonoBehaviour
{
    public AudioSource playsound_bg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playsound()
    {
        playsound_bg.Play();
    }
}
