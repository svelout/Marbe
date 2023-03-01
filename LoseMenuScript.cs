using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource LoseSound;
    public void RepeatButton()
    {
        if(LoseSound.isPlaying != false)
        {
            LoseSound.Stop();
        }
        GameValues.restart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitInMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex);
        GameValues.restart = true;
    }
}
