using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class events_off : MonoBehaviour
{
    public void Call_event()
    {
        this.gameObject.GetComponent<Animator>().enabled = false;
    }
}
