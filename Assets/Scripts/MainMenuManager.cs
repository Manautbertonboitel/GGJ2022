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
        SceneManager.LoadScene(mainScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
