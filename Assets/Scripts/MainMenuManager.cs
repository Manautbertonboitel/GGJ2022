using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string mainScene;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("ambiance");    
    }

    public void Play()
    {
        FindObjectOfType<AudioManager>().Play("button");
        SceneManager.LoadScene(mainScene);
    }

    public void Quit()
    {
        FindObjectOfType<AudioManager>().Play("button");
        Application.Quit();
    }

    public void PlaySound()
    {
        FindObjectOfType<AudioManager>().Play("button");
    }
}
