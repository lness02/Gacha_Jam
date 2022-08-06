using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreens : MonoBehaviour
{
    public int TestScene;
    public GameObject TitleScreen, CreditScreen, BackButton, PlayButton;
    public GameObject SettingsButton, SettingsScreen, pauseScreen, resumeButton;

    public void Credit()
    {
        TitleScreen.SetActive(false);
        SettingsScreen.SetActive(false);
        CreditScreen.SetActive(true);
        BackButton.SetActive(true);
    }

    public void Back()
    {
        TitleScreen.SetActive(true);
        BackButton.SetActive(false);
        CreditScreen.SetActive(false);
        SettingsScreen.SetActive(false);
        pauseScreen.SetActive(false);
        //PauseButton.SetActive(false);

    }

    public void Settings()
    {
        SettingsScreen.SetActive(true);
        BackButton.SetActive(true);
        TitleScreen.SetActive(false);
        CreditScreen.SetActive(false);
        pauseScreen.SetActive(false);
        //PauseButton.SetActive(false);

    }

    public void Play()
    {
        // also buttons stop working when loaded in opposite direction
        SceneManager.LoadScene(TestScene);
    }

    //public void Pause()
    //{
    //    pauseScreen.SetActive(true);
    //    PauseButton.SetActive(false);
    //    TitleScreen.SetActive(false);
    //    BackButton.SetActive(false);
    //    CreditScreen.SetActive(false);
    //    SettingsScreen.SetActive(false);
    //}

    public void Resume()
    {
        TitleScreen.SetActive(false);
        BackButton.SetActive(false);
        CreditScreen.SetActive(false);
        SettingsScreen.SetActive(false);
        pauseScreen.SetActive(false);
       // PauseButton.SetActive(true);
    }


    //public void Menu()
    //{
    //    TitleScreen.SetActive(true);
    //    BackButton.SetActive(false);
    //    CreditScreen.SetActive(false);
    //    SettingsScreen.SetActive(false);
    //    pauseScreen.SetActive(false);
    //    PauseButton.SetActive(false);
    //    Time.timeScale = 0;
    //}

}