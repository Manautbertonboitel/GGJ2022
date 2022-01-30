using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    public Canvas winGameCanvas;
    public Image winImage;
    public bool winLevel = false;

    public float endValue, duration;
    public string nextLevel;

    private void Awake()
    {
        winGameCanvas.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<MeshCollider>().isTrigger = false;
        winLevel = true;
        StartCoroutine("StopPlayer");
        StartCoroutine("NextLevel");
    }

    private void Update()
    {
        if (winLevel)
        {
            winGameCanvas.gameObject.SetActive(true);
            StartCoroutine("FadeBackground");
            winLevel = false;
        }
    }

    public IEnumerator StopPlayer()
    {
        yield return new WaitForSeconds(0.1f);
        FindObjectOfType<CharacterController>().controlsOrientation = Orientation.None;
    }

    public IEnumerator FadeBackground()
    {
        float elapsedTime = 0;
        float startValue = winImage.color.a;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            winImage.color = new Color(winImage.color.r, winImage.color.g, winImage.color.b, newAlpha);
            yield return null;
        }
    }

    public IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(nextLevel);
    }
}
