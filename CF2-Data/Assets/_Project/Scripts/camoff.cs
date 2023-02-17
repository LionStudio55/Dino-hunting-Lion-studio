using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camoff : MonoBehaviour
{
    public static camoff instance;

    public GameObject cam;
    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        Invoke("camof", 5f);
    }
    // Start is called before the first frame update
    public void camof()
    {
        cam.SetActive(false);
    }
}
