using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCameraPriority : MonoBehaviour
{
    public CinemachineVirtualCamera cameraToActivate;
    public CinemachineVirtualCamera[] virtualCameras;

    public Orientation controlsOrientation;

    private void Awake()
    {
        virtualCameras = GameObject.FindObjectsOfType<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter(Collider other)
    {
        /*for (int i = 0; i < virtualCameras.Length; i++)
        {
            if(virtualCameras[i].Priority != 10 && virtualCameras[i] != cameraToActivate)
            {

            }
            virtualCameras[i].Priority = 1;
        }*/

        for (int i = 0; i < virtualCameras.Length; i++)
        {
            virtualCameras[i].Priority = 1;
        }
        cameraToActivate.Priority = 10;

        StartCoroutine("ChangeControlsOrientation");
    }

    public IEnumerator ChangeControlsOrientation()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<CharacterController>().controlsOrientation = this.controlsOrientation;
    }
}
