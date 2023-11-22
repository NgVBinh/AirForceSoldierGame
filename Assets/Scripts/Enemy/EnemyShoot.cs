using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public EnemyManager enemyManager;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] Transform attackPoint;
    [SerializeField] private Transform attackDirection;

    public float timeBetweenShoot;
    [SerializeField] private ParticleSystem attackPS;
    private GameObject holderBulletEnemy;
    private Transform playerTransform;

    private float timer;

    private float maxTimeToDestroy = 10f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
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
        //bắn khi player trong phạm vi và đủ timer
        if ( playerDirection.magnitude < enemyManager.enemyInfor.GetRangeAttack())
        {
            animator.enabled = true;

            if (timer >= timeBetweenShoot)
            {
                attackPS.Stop();
                attackPS.Play(); 
                GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, attackDirection.rotation);
                BulletController bulletController = bullet.GetComponent<BulletController>();
                bulletController.SetDamageBullet(enemyManager.enemyInfor.damageBullet);
                bullet.transform.parent = holderBulletEnemy.transform;
                timer = 0;
                Destroy(bullet, maxTimeToDestroy);
            }
        }
        else 
        {
            animator.enabled = false;
        }
    }
}
