using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        nextPos= playerTransform.position;
        transform.position = new Vector3(nextPos.x, nextPos.y +50f, nextPos.z);
    }
}
