using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public GameObject WhiteWalls, BlackWalls;

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("interrupteur");
        if(WhiteWalls.GetComponent<Wall>().status)
        {
            LowerWall(WhiteWalls);
            WhiteWalls.GetComponent<Wall>().status = false;
        } else
        {
            AscendWall(WhiteWalls);
            WhiteWalls.GetComponent<Wall>().status = true;
        }

        if (BlackWalls.GetComponent<Wall>().status)
        {
            LowerWall(BlackWalls);
            BlackWalls.GetComponent<Wall>().status = false;
        }
        else
        {
            AscendWall(BlackWalls);
            BlackWalls.GetComponent<Wall>().status = true;
        }
    }

    void LowerWall(GameObject wall)
    {
        wall.GetComponent<Animator>().Play("LowerWall");
    }

    void AscendWall(GameObject wall)
    {
        wall.GetComponent<Animator>().Play("AscendWall");
    }
}
