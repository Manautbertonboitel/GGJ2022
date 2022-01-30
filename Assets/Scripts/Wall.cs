using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool status;

    public Vector3 upPosition;
    public Vector3 downPosition;

    public float heightTarget = 1f;

    public bool moveUp;

    private void Start()
    {
        upPosition = new Vector3(transform.position.x, transform.position.y + heightTarget, transform.position.z);
        downPosition = transform.position;
    }

    private void Update()
    {
        if(moveUp)
        {
            Vector3 interpolatedPosition = Vector3.Lerp(transform.position, upPosition, 0.01f);
            transform.position = interpolatedPosition;
        } else
        {
            Vector3 interpolatedPosition = Vector3.Lerp(transform.position, downPosition, 0.01f);
            transform.position = interpolatedPosition;
        }
    }
}
