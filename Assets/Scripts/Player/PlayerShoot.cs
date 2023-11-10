using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    //bullet
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] Transform attackPoint;
    [SerializeField] Transform attackDirection;

    [SerializeField] public float timeBetweenShoot;
    private float timer;

    private float maxTimeToDestroy = 10f;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        shoot();

    }

    public void shoot()
    {
        if (Input.GetButton("Fire1") && timer>=timeBetweenShoot)
        {
            GameObject bullet = Instantiate(bulletPrefab, attackPoint.position,attackDirection.rotation);
            bullet.transform.parent = transform;
            timer = 0;
            Destroy(bullet,maxTimeToDestroy);
        }
    }


}
