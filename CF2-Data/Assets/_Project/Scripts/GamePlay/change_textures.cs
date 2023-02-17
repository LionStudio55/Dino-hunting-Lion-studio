using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_textures : MonoBehaviour
{

    public Material Snow_material, Desert_material, Jungle_Material;
    public MeshRenderer Env_render;
    public int level_perfom,select_No;

    //[Header("Skyboxes_Data")]
    //public Material[] Skyboxes_Materails;



    
    public bool cutscenes;
    private void OnEnable()
    {
       
       // Env_render = GameObject.Find("Terrain_Mesh").GetComponent<MeshRenderer>();
        changetextures(level_perfom);
        Change_Skyboxes(select_No);
    }

    private void OnDisable()
    {
        //if(cutscenes == false)
        //{
        //    changetextures(0);
        //}
       
    }


    // Change Textures
    void changetextures(int No)
    {
        switch (No)
        {
            case 0:
                for (int f = 0; f < data_get.inst.Layer_arrangement.Length; f++)
                {
                    data_get.inst.Layer_arrangement[f].diffuseTexture = data_get.inst.All_texturess_Forset[f];
                }
                data_get.inst.Tree_material.mainTexture = data_get.inst.tree_textures[0];
                break;
            case 1:
                for (int s = 0; s < data_get.inst.Layer_arrangement.Length; s++)
                {
                    data_get.inst.Layer_arrangement[s].diffuseTexture = data_get.inst.All_texturess_Snow[s];
                }
                data_get.inst.Tree_material.mainTexture = data_get.inst.tree_textures[1];

                break;
            case 2:
                for (int d = 0; d < data_get.inst.Layer_arrangement.Length; d++)
                {
                    data_get.inst.Layer_arrangement[d].diffuseTexture = data_get.inst.All_texturess_Desert[d];
                }
                data_get.inst.Tree_material.mainTexture = data_get.inst.tree_textures[2];

                break;
        }

        }

    // Change SkyBoxes

    void Change_Skyboxes(int selected)
    {
        switch(selected)
        {
            case 0:
                RenderSettings.skybox = data_get.inst.Skyboxes_Materails[selected];
                //if (Constants.Getprefs(Constants.lastselectedMode) == 3)
                //{

                //    RenderSettings.ambientIntensity = 0.45f;
                //    data_get.inst.Night_light.SetActive(true);
                //    RenderSettings.skybox = data_get.inst.Skyboxes_Materails[6];
                //}
                //else
                //{
                //    RenderSettings.ambientIntensity = 1.5f;
                //    data_get.inst.Lights_objs[selected].SetActive(true);

                //}
                RenderSettings.ambientIntensity = 1.5f;
                data_get.inst.Lights_objs[selected].SetActive(true);
                if (GPULevelChecker.graphicLevelGPUBased == GPULevelChecker.GraphicLevelGPUBased.Low)
                {
                    data_get.inst.particles_objs[selected].SetActive(false);
                }
                
                break;

            case 1:
                RenderSettings.skybox = data_get.inst.Skyboxes_Materails[selected];
                //if (Constants.Getprefs(Constants.lastselectedMode) == 3)
                //{

                //    RenderSettings.ambientIntensity = 0.45f;
                //    data_get.inst.Night_light.SetActive(false);
                //    RenderSettings.skybox = data_get.inst.Skyboxes_Materails[6];
                //}
                //else
                //{
                //    RenderSettings.ambientIntensity = 0.8f;
                //    data_get.inst.Night_light.SetActive(true);
                //    data_get.inst.Lights_objs[selected].SetActive(false);

                //}
                RenderSettings.ambientIntensity = 0.8f;
                data_get.inst.Night_light.SetActive(true);
                data_get.inst.Lights_objs[selected].SetActive(false);
                if (GPULevelChecker.graphicLevelGPUBased != GPULevelChecker.GraphicLevelGPUBased.Low)
                {
                    data_get.inst.particles_objs[selected].SetActive(true);
                }
               
                break;

            case 2:
                RenderSettings.skybox = data_get.inst.Skyboxes_Materails[selected];
                //if (Constants.Getprefs(Constants.lastselectedMode) == 3)
                //{

                //    RenderSettings.ambientIntensity = 0.45f;
                //    data_get.inst.Night_light.SetActive(true);
                //    RenderSettings.skybox = data_get.inst.Skyboxes_Materails[6];

                //}
                //else
                //{
                //    RenderSettings.ambientIntensity = 1.5f;
                //    data_get.inst.Lights_objs[selected].SetActive(true);
                //}
                RenderSettings.ambientIntensity = 1.5f;
                data_get.inst.Lights_objs[selected].SetActive(true);
                if (GPULevelChecker.graphicLevelGPUBased != GPULevelChecker.GraphicLevelGPUBased.Low)
                {
                    data_get.inst.particles_objs[selected].SetActive(false);
                }
                ram_checker.instanceeed.Trees_Parent.SetActive(false);
                ram_checker.instanceeed.Trees_desert.SetActive(true);
                

                break;

            case 3:
                RenderSettings.skybox = data_get.inst.Skyboxes_Materails[selected];
                //if (Constants.Getprefs(Constants.lastselectedMode) == 3)
                //{

                //    RenderSettings.ambientIntensity = 0.45f;
                //    data_get.inst.Night_light.SetActive(true);
                //    RenderSettings.skybox = data_get.inst.Skyboxes_Materails[6];
                //}
                //else
                //{
                //    RenderSettings.ambientIntensity = 1.2f;
                //    data_get.inst.Lights_objs[selected].SetActive(true);

                //}
                RenderSettings.ambientIntensity = 1.2f;
                data_get.inst.Lights_objs[selected].SetActive(true);
                if (GPULevelChecker.graphicLevelGPUBased != GPULevelChecker.GraphicLevelGPUBased.Low)
                {
                    data_get.inst.particles_objs[selected].SetActive(true);
                }

                ram_checker.instanceeed.Trees_Parent.SetActive(false);
                ram_checker.instanceeed.Trees_desert.SetActive(true);
                break;

            case 4:
                RenderSettings.skybox = data_get.inst.Skyboxes_Materails[selected];
                //if (Constants.Getprefs(Constants.lastselectedMode) == 3)
                //{

                //     RenderSettings.ambientIntensity = 0.45f;
                //    data_get.inst.Night_light.SetActive(true);
                //    RenderSettings.skybox = data_get.inst.Skyboxes_Materails[6];
                //}
                //else
                //{
                //    RenderSettings.ambientIntensity = 1.2f;
                //    data_get.inst.Lights_objs[selected].SetActive(true);

                //}
                RenderSettings.ambientIntensity = 1.2f;
                data_get.inst.Lights_objs[selected].SetActive(true);
                if (GPULevelChecker.graphicLevelGPUBased != GPULevelChecker.GraphicLevelGPUBased.Low)
                {
                    data_get.inst.particles_objs[selected].SetActive(true);
                }
                break;

            case 5:
                RenderSettings.skybox = data_get.inst.Skyboxes_Materails[selected];
                //if (Constants.Getprefs(Constants.lastselectedMode) == 3)
                //{

                //    RenderSettings.ambientIntensity = 0.45f;
                //    data_get.inst.Night_light.SetActive(true);
                //    RenderSettings.skybox = data_get.inst.Skyboxes_Materails[6];
                //}
                //else
                //{
                //    RenderSettings.ambientIntensity = 1.2f;
                //    data_get.inst.Lights_objs[selected].SetActive(true);

                //}
                RenderSettings.ambientIntensity = 1.2f;
                data_get.inst.Lights_objs[selected].SetActive(true);
                if (GPULevelChecker.graphicLevelGPUBased != GPULevelChecker.GraphicLevelGPUBased.Low)
                {
                    data_get.inst.particles_objs[selected].SetActive(true);
                }
                break;

        }
    }

    void call_light()
    {
        
    }
  

}



   
