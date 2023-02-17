using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBanner : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        Smallbanner();
    }

    //private void Mediumbanner()
    //{
    //    try
    //    {
    //        if (FindObjectOfType<MediationHandler>())
    //        {
    //            FindObjectOfType<MediationHandler>().ShowMediumBanner(GoogleMobileAds.Api.AdPosition.BottomLeft);
    //            FindObjectOfType<MediationHandler>().hideSmallBanner();
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //    }
    //}
    private void Smallbanner()
    {
        try
        {
            if (FindObjectOfType<MediationHandler>())
            {
                FindObjectOfType<MediationHandler>().ShowSmallBanner(GoogleMobileAds.Api.AdPosition.TopRight);
                FindObjectOfType<MediationHandler>().hideMediumBanner();
            }
        }
        catch (Exception e)
        {
        }
    }
}
