using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameOver : MonoBehaviour
{
    public GameObject score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void homeBtnClicked()
    {
        SceneManager.LoadScene(0);
    }
    public void restartBtnClicked()
    {
        SceneManager.LoadScene(1);
    }


}
