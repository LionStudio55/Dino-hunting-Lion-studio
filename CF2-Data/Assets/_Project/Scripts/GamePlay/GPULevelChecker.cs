using UnityEngine;
using System.IO;

public class GPULevelChecker : MonoBehaviour
{
    public enum GraphicLevelGPUBased
    {
        High,
        Standered,
        Low,
    }
    public float MaxAvrageValue = 4500;
    public float HighLevelAvrage = 55;
    public float StandardLevelAvrage = 35;
    public static GraphicLevelGPUBased graphicLevelGPUBased;

    public static GPULevelChecker Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Start()
    {
        //For Testing
        //Debug.Log("graphicsMemorySize" + SystemInfo.graphicsMemorySize);
        //Debug.Log("processorFrequency" + SystemInfo.processorFrequency);
        // main work
        int memory = SystemInfo.systemMemorySize;
        int gpuMemeory = SystemInfo.graphicsMemorySize;
        int processorCount = SystemInfo.processorCount;
        int processorFrequency = SystemInfo.processorFrequency;

        float total = memory + gpuMemeory + processorCount + processorFrequency;
        float avrage = total / 4;
        float percentage = (avrage * 100) / MaxAvrageValue;
        Debug.Log(percentage + " %");
        if(percentage >= HighLevelAvrage)
        {
            graphicLevelGPUBased = GraphicLevelGPUBased.High;
            QualitySettings.SetQualityLevel(2);
        }
        else if(percentage < HighLevelAvrage && percentage >= StandardLevelAvrage)
        {
            graphicLevelGPUBased = GraphicLevelGPUBased.Standered;
            QualitySettings.SetQualityLevel(1);
        }
        else
        {
            graphicLevelGPUBased = GraphicLevelGPUBased.Low;
            QualitySettings.SetQualityLevel(0);
        }
        Application.lowMemory += OnMemoryLow;
    }

    private void OnMemoryLow()
    {
        //Debug.Log("Memory Low");
        //Debug.Log("Quiting Application");
        Application.Quit();
    }
}
