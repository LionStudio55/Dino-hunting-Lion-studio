using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class Pluginscreate : EditorWindow
{


    static GameObject Ads_Manager;

    [MenuItem("GoogleAdmob(v6.1.2)/Create Ads Manager")]
    public static void CreateAdsManager()
    {
        Ads_Manager = new GameObject("Ads Manager");
        Ads_Manager.AddComponent<AdmobAdsManager>();
         #if INAPP
         Ads_Manager.AddComponent<InApp_Manager>();
         #endif
        Ads_Manager.AddComponent<PlayerPrefManager>();
        Ads_Manager.AddComponent<FirebaseHandler>();
        //Ads_Manager.AddComponent<admo>();
        Selection.activeObject = Ads_Manager;

    }
  
}
