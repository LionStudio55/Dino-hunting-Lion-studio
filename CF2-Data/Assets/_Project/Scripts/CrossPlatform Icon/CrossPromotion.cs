using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossPromotion : MonoBehaviour
{
    public float changeTime = 2.5f;

    private void OnEnable()
    {
        StartCoroutine(CrossPromotionThumb());
    }

    //private void Start()
    //{
    //    StartCoroutine(CrossPromotionThumb());
    //}


    IEnumerator CrossPromotionThumb()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(changeTime);
            gameObject.transform.GetChild(i).gameObject.SetActive(false);
            if (i == gameObject.transform.childCount-1)
            {
                i = -1;
            }
        }
    }
    public void OpenGameURL(string s)
    {
        Application.OpenURL(s);
    }
}
