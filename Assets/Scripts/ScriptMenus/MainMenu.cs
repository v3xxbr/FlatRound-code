using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    private void Update()
    {
        Play();
        Quit();
    }
    public void Play()
    { 
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene(1);
            Eyestomb.defeated = false;
            Eyestomb.entering = true;
        }
    }

    public void Quit()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
             Application.Quit();
        }
    }
}
