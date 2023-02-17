using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutsceen_Menu : MonoBehaviour
{
    public GameObject[] objects_arr;
    public Animator[] Doors;
    public GameObject Props;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playscene());
    }

   IEnumerator playscene()
    {
        yield return new WaitForSeconds(6f);
        objects_arr[0].SetActive(false);
        objects_arr[1].SetActive(true);
        //Props.SetActive(false);
        yield return new WaitForSeconds(2f);

        Doors[0].enabled = true;
        Doors[1].enabled = true;
       // Props.SetActive(false);
       // yield return new WaitForSeconds(0.5f);
      //  Props.SetActive(true);


    }
}
