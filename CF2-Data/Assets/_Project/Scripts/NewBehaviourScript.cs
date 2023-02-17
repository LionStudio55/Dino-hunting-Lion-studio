using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public void Start()
    {
       StartCoroutine("go2");
    }
    IEnumerator go2()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        this.gameObject.SetActive(false);
    }
}
