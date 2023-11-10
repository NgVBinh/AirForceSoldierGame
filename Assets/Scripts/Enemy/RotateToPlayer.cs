using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float inRange;
    [SerializeField] private float SpeedRotate;

    // Update is called once per frame
    void Update()
    {
        RotateEnemy();
    }

    public void RotateEnemy()
    {

        Vector3 direction = playerTransform.position - transform.position;
        if(direction.magnitude < inRange)
        {
            transform.LookAt(playerTransform.position);
        }
    }
}
