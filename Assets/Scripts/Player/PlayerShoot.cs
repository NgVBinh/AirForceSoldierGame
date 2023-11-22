using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    private PlayerManager playerManager;
    //bullet
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] Transform attackPoint;
    private Transform attackDirection;
    private float timeBetweenShoot;
    private float timer;

    private float maxTimeToDestroy = 10f;

    private AudioSource audioSource;
    private void Start()
    {
        timeBetweenShoot = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().playerInfor.GetTimeBullet();

        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        attackDirection = GameObject.FindGameObjectWithTag("Player").transform;

        audioSource = GetComponentInParent<AudioSource>();
    }
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
            BulletController bulletController = bullet.GetComponent<BulletController>();
            bulletController.SetDamageBullet(playerManager.playerInfor.GetDamageBullet());
            bullet.transform.parent = transform;

            audioSource.Play();

            timer = 0;
            Destroy(bullet,maxTimeToDestroy);
        }
    }


}
