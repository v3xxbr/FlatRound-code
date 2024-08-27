using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class gameOver : MonoBehaviour
{
    private AudioSource aud;
    public AudioClip audiogameOver;

    public void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    //sound
    public void playAudio()
    {
        if(Eyestomb.defeated)
        {
            aud.clip = audiogameOver;
            aud.loop = true;
            aud.Play();
        }
    }

    //restart
    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
        Eyestomb.defeated = false;
        Eyestomb.entering = true;
        MrAllflet.defeated = false;
    }

    //back to main menu
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
