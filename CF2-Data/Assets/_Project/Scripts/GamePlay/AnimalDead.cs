using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDead : MonoBehaviour
{
    public Animation anim;
    public string Animationname = "Steg|Die1";
    public float Animationstop ;
    // Start is called before the first frame update
    void Start()
    {
        anim.CrossFade(Animationname);
        Invoke(nameof(stopanimation),Animationstop);
    }

  private void stopanimation()
    {
        anim.Stop();
    }
}
