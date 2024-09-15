using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class quit : MonoBehaviour
{
    //quit to main menu
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                SceneManager.LoadScene(0);
        }
    }
}
