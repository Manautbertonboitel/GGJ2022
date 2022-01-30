using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWallSingle : MonoBehaviour
{
    public GameObject Wall;

    private void OnTriggerEnter(Collider other)
    {
        if (FindObjectOfType<AudioManager>())
        {
            FindObjectOfType<AudioManager>().Play("interrupteur");
        }

        if (!Wall.GetComponent<Wall>().moveUp)
        {
            /*LowerWall(Wall);
            Wall.GetComponent<Wall>().status = false;*/
            Wall.GetComponent<Wall>().moveUp = true;
        }
        else if (Wall.GetComponent<Wall>().moveUp)
        {
            /*AscendWall(Wall);
            Wall.GetComponent<Wall>().status = true;*/
            Wall.GetComponent<Wall>().moveUp = false;
        }
    }

    /*void LowerWall(GameObject wall)
    {
        wall.GetComponent<Animator>().Play("LowerWall");
    }

    void AscendWall(GameObject wall)
    {
        wall.GetComponent<Animator>().Play("AscendWall");
    }*/
}
