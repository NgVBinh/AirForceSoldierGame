using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaFollow : MonoBehaviour
{

    [SerializeField] private Transform transformTarget;
    // Update is called once per frame
    private void FixedUpdate()
    {
        SeaMove();
    }

    private void SeaMove()
    {
        transform.position = new Vector3(transformTarget.position.x,transform.position.y,transformTarget.position.z);
    }
}
