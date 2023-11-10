using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField] public float speed = 1.0f;
    private Vector3 targetPos = Vector3.forward;
    public void setTargetTransform(Vector3 position)
    {
        targetPos = position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed*Time.deltaTime);
    }
}
