using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamepadMainMenu : MonoBehaviour
{
    //start game on gamepad
    void Play()
    {
        if(Input.GetButtonDown("MenuPlay"))
        {
            SceneManager.LoadScene("Game");
        }
    }

    //go to options on gamepad
    void Options()
    {
        if(Input.GetButtonDown("MenuOptions"))
        {
            Debug.Log("opzoes");
        }
    }

    //quit game on gamepad
    void Quit()
    {
        if (Input.GetButtonDown("MenuQuit"))
        {
            Application.Quit();
        }
    }
}
