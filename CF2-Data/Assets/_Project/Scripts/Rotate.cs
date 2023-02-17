using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour
{
    public float zRot;

    private void Start()
    {
        InvokeRepeating("RotateObject", 0.05f, 0.05f);
    }

    public void RotateObject()
    {
        GetComponent<RectTransform>().Rotate(0f, 0f, zRot);
    }
}
