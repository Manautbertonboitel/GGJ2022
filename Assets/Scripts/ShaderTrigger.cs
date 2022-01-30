using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTrigger : MonoBehaviour
{
    public Material wallsMaterial;
    public Material sphereMaterial;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(wallsMaterial.HasProperty("IsWhite"));
		Debug.Log(wallsMaterial.HasProperty("IsSphere"));
		Debug.Log(wallsMaterial.HasProperty("Emission"));
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
		{
            wallsMaterial.SetInt("IsWhite", 1 - wallsMaterial.GetInt("IsWhite"));
            sphereMaterial.SetInt("IsWhite", 1 - sphereMaterial.GetInt("IsWhite"));
		}
    }
}
