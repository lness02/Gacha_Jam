using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public void Quit()
    {
        Debug.Log("APPLICATION QUIT.");
        // Load Title Screen
        SceneManager.LoadScene("MenuScreens");
    }

    public void Retry()
    {
        Debug.Log("APPLICATION RETRY.");
        //Load first/starting scene
        SceneManager.LoadScene("TestScene");
    }
}