using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class START : MonoBehaviour
{
    public void gotoscene()
    {
        SceneManager.LoadScene("Menu_Handler_UZ");
    }
}
