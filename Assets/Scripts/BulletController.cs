using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
   
    [SerializeField] private float speed;
    private float damageBullet;
    private Vector3 direction= Vector3.forward;

    public void SetDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    public float GetDamageBullet()
    {
        return damageBullet;
    }
    public void SetDamageBullet(float damage)
    {
        this.damageBullet = damage;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction* Time.deltaTime* speed);
    }

    
}
