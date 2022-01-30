using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Canvas winGameCanvas;
    public Image winImage;
    public bool winLevel = false;

    public float endValue, duration;

    private void Awake()
    {
        winGameCanvas.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        winLevel = true;
        StartCoroutine("StopPlayer");
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
}
