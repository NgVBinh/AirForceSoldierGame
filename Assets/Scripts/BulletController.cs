using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Vector3 direction= Vector3.forward;

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction* Time.deltaTime* speed);
        
    }
}
