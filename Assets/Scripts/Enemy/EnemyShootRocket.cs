using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootRocket : MonoBehaviour
{
    public EnemyManager enemyManager;
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] Transform attackPoint;
    [SerializeField] private Transform attackDirection;

    [SerializeField] public float timeBetweenShoot;
    private GameObject holderBulletEnemy;
    private Transform playerTransform;

    private float timer;

    private float maxTimeToDestroy = 20f;

    private void Start()
    {
        holderBulletEnemy = GameObject.Find("BulletEnemy");
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
        if (timer >= timeBetweenShoot && playerDirection.magnitude < enemyManager.enemyInfor.GetRangeAttack())
        {
            GameObject rocket = Instantiate(rocketPrefab, attackPoint.position, attackDirection.rotation);
            RocketController rocketController = rocket.GetComponentInChildren<RocketController>();
            rocketController.SetDamageRocket(enemyManager.enemyInfor.GetDamageRocket());
            rocketController.setTargetTransform(playerTransform.position);
            rocket.transform.parent = holderBulletEnemy.transform;
            timer = 0;
            Destroy(rocket, maxTimeToDestroy);
        }
    }
}
