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
        for (int i = 0; i < virtualCameras.Length; i++)
        {
            virtualCameras[i].Priority = 1;
        }
        cameraToActivate.Priority = 10;

        FindObjectOfType<CharacterController>().controlsOrientation = this.controlsOrientation;
    }
}
