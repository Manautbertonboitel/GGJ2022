using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTrigger : MonoBehaviour
{
    public Scene scene;
    public string sceneName;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneName);
    }
}
