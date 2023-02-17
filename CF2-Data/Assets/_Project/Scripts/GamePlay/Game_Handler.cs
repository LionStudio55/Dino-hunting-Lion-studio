using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Handler : MonoBehaviour
{


    public static bool Snow = false;
   

    [HideInInspector]
    [Header("Animal Meshes")]
    public GameObject AnimalsParent;

    [HideInInspector]
    [Header("Animal Standard Material")]
    public Material StagMaterial;
    [HideInInspector]
    public Material BearMaterial, DeerMaterial, ElephantMaterial, BoarMaterial, HippoMaterial, LionMaterial, RhinoMaterial, ZebraMaterial, WolfMaterial;

    [HideInInspector]
    [Header("Animal Transparent Material")]
    public Material StagTransparent;
    [HideInInspector]
    public Material BearTransparent, DeerTransparent, ElephantTransparent, BoarTransparent, HippoTransparent, LionTransparent, RhinoTransparent, ZebraTransparent, WolfTransparent;



   

    [Header("Scope Material")]
    public Material ScopeMaterial;

    [Header("Scope CubeMap")]
    public Texture[] ScopeCupemap;

    public GameObject ForestTree;

    public GameObject InfraredBtn;

    public static Game_Handler instance;
    private void Awake()
    {
        instance = this;
        AudioListener.pause = false;
   
    }

    private void Start()
    {
      
        InfraredBtn.SetActive(true);//Inam
       
    }

    private void Update()
    {
       
    }


   
}
