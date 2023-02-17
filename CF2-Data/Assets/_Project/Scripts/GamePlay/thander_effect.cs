using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thander_effect : MonoBehaviour
{
    public AudioSource thandersounds;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Lightning());
    }

    IEnumerator Lightning()
    {
        RenderSettings.skybox.SetFloat("_Exposure", 0.85f);
        yield return new WaitForSeconds(0.05f);
        RenderSettings.skybox.SetFloat("_Exposure", 0.5f);
        yield return new WaitForSeconds(0.1f);
        RenderSettings.skybox.SetFloat("_Exposure", 0.85f);
        yield return new WaitForSeconds(0.15f);
        Invoke("wait", 1f);
        RenderSettings.skybox.SetFloat("_Exposure", 0.5f);

        yield return new WaitForSeconds(2.75f);
        RenderSettings.skybox.SetFloat("_Exposure", 0.85f);
        yield return new WaitForSeconds(0.2f);
        RenderSettings.skybox.SetFloat("_Exposure", 0.5f);
        yield return new WaitForSeconds(0.2f);
        RenderSettings.skybox.SetFloat("_Exposure", 0.85f);
        yield return new WaitForSeconds(0.2f);
        RenderSettings.skybox.SetFloat("_Exposure", 0.5f);
        yield return new WaitForSeconds(0.3f);
        RenderSettings.skybox.SetFloat("_Exposure", 0.85f);
        yield return new WaitForSeconds(0.45f);
        RenderSettings.skybox.SetFloat("_Exposure", 0.5f);


        yield return new WaitForSeconds(4f);
        StartCoroutine(Lightning());
    }

    void wait()
    {
        thandersounds.Play();
    }
}
