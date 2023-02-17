using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gunstry_handler : MonoBehaviour
{
    public Image gunImage_Icon;
    public Sprite[] guns_images;
    public string[] GunNames;
    public Text gun_names;
    private void OnEnable()
    {

        SetImage();
    }

    void SetImage()
    {
        if (Constants.Getprefs(Constants.lastselectedLevel) == 0)
        {
            gunImage_Icon.sprite = guns_images[7];
            //gunImage_Icon.SetNativeSize();
            gun_names.text = GunNames[7];
        }
        else if (Constants.Getprefs(Constants.lastselectedLevel) == 1)
        {
            gunImage_Icon.sprite = guns_images[8];
           // gunImage_Icon.SetNativeSize();
            gun_names.text = GunNames[8];
        }
        else if (Constants.Getprefs(Constants.lastselectedLevel) == 2)
        {
            gunImage_Icon.sprite = guns_images[6];
           // gunImage_Icon.SetNativeSize();
            gun_names.text = GunNames[6];
        }
        else if (Constants.Getprefs(Constants.lastselectedLevel) == 3)
        {
            gunImage_Icon.sprite = guns_images[9];
            //gunImage_Icon.SetNativeSize();
            gun_names.text = GunNames[9];
        }
        else if (Constants.Getprefs(Constants.lastselectedLevel) == 4)
        {
            gunImage_Icon.sprite = guns_images[2];
           // gunImage_Icon.SetNativeSize();
            gun_names.text = GunNames[2];
        }


        PlayerPrefs.SetInt("trail", 1);
    }
}
