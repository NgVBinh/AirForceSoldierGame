using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
     public EnemyManager enemyManager;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] Transform attackPoint;
    [SerializeField] private Transform attackDirection;

    [SerializeField] public float timeBetweenShoot;
    [SerializeField] GameObject holderBulletEnemy;
    private Transform playerTransform;

    private float timer;

    private float maxTimeToDestroy = 10f;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        shoot();

    }

    public void shoot()
    {
        Vector3 playerDirection = transform.position - playerTransform.position;
        if (timer >= timeBetweenShoot && playerDirection.magnitude <enemyManager.enemyInfor.rangeBullet)
        {
            GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, attackDirection.rotation);
            BulletController bulletController = bullet.GetComponent<BulletController>();
            bulletController.SetDamageBullet(enemyManager.enemyInfor.damageBullet);
            bullet.transform.parent = holderBulletEnemy.transform;
            timer = 0;
            Destroy(bullet, maxTimeToDestroy);
        }
    }
}
