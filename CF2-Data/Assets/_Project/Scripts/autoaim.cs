using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoaim : MonoBehaviour
{
    public Transform target;
    void Update()
    {
      transform.LookAt(GameObject.FindWithTag("Flesh").transform);

    }
}
