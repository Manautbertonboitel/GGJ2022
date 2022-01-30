using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public GameObject WhiteWalls, BlackWalls;

    public static SOMaterials materials;

	private void Start()
	{
        if (materials == null)
        {
            materials = Resources.Load<SOMaterials>("SOMaterials");

			materials.wallsMaterialWhite.SetInt("IsWhite", 1);
			materials.wallsMaterialBlack.SetInt("IsWhite", 0);
			materials.sphereMaterial.SetInt("IsWhite", 1);
		}
	}

	private void OnTriggerEnter(Collider other)
    {
        if (FindObjectOfType<AudioManager>())
        {
            FindObjectOfType<AudioManager>().Play("interrupteur");
        }

        if (WhiteWalls.GetComponent<Wall>().status)
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

        materials.wallsMaterialWhite.SetInt("IsWhite", 0);
        materials.wallsMaterialBlack.SetInt("IsWhite", 1);
        materials.sphereMaterial.SetInt("IsWhite", 0);
	}

    void AscendWall(GameObject wall)
    {
        wall.GetComponent<Animator>().Play("AscendWall");

        materials.wallsMaterialWhite.SetInt("IsWhite", 1);
        materials.wallsMaterialBlack.SetInt("IsWhite", 0);
        materials.sphereMaterial.SetInt("IsWhite", 1);
	}

	private void OnApplicationQuit()
	{
		materials.wallsMaterialWhite.SetInt("IsWhite", 1);
		materials.wallsMaterialBlack.SetInt("IsWhite", 0);
		materials.sphereMaterial.SetInt("IsWhite", 1);
	}
}
