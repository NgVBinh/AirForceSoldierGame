using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRocket : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefabs;
    [SerializeField] private Transform attackPoint;

    private PlayerManager playerManager;
    private Transform playerDirection;
    private float timeToShoot;
    private float timer;
    private Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        timeToShoot = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().playerInfor.GetTimeRocket();
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        playerDirection = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }


    public void shoot()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire2") &&  timer>= timeToShoot)
        {
            GameObject newRock= Instantiate(rocketPrefabs,attackPoint.position,playerDirection.rotation);
            RocketController rocketController = newRock.GetComponentInChildren<RocketController>();
            rocketController.SetDamageRocket(playerManager.playerInfor.GetDamageRocket());
            rocketController.setTargetTransform(targetPos);

            timer = 0f;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            //Debug.Log(other.gameObject.name + "trong pham vi ban ten lua");
            targetPos = other.transform.position;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            targetPos = Vector3.zero;
        }
    }
}
