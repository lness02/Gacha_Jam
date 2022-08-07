using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Passcode : MonoBehaviour
{

    public GameObject KeyPad, BackButton;
    public string Code = "123";
    string Nr = null;
    int NrIndex = 0;
    string alpha;
    public Text UiText = null;

    public void CodeFuction(string Numbers)
    {
        NrIndex++;
        Nr = Nr + Numbers;
        UiText.text = Nr;
    }

    public void Enter()
    {
        if (Nr == Code)
        {
            Debug.Log("Works");

        }
    }

    public void Clear()
    {
        NrIndex++;
        Nr = null;
        UiText.text = Nr;

    }
   
    public void Back()
    {
        KeyPad.SetActive(false);
        BackButton.SetActive(false);
    }


}
