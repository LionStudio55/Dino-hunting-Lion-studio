using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ram_checker : MonoBehaviour
{
    public static ram_checker instanceeed;
    public int ram_index;
    public GameObject[] Obbjects_on, Obbjects_off;
    private void Awake()
    {
        instanceeed = this;
    }
    private void OnEnable()
    {
        if(GPULevelChecker.graphicLevelGPUBased == GPULevelChecker.GraphicLevelGPUBased.Low)
        {
            for (int ob_off = 0; ob_off < Obbjects_off.Length; ob_off++)
            {
                Obbjects_off[ob_off].SetActive(false);
            }
            for (int ob_on=0; ob_on < Obbjects_on.Length; ob_on++)
            {
                Obbjects_on[ob_on].SetActive(true);
            }
        }
        else
        {
            for (int ob_off = 0; ob_off < Obbjects_off.Length; ob_off++)
            {
                Obbjects_off[ob_off].SetActive(true);
            }
            for (int ob_on = 0; ob_on < Obbjects_on.Length; ob_on++)
            {
                Obbjects_on[ob_on].SetActive(false);
            }
        }
    }

    public GameObject Trees_Parent, Trees_desert;
    
}
