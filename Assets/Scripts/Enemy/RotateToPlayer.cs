using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    private EnemyManager enemyManager;
    private Transform playerTransform;

    private void Start()
    {
        enemyManager = GetComponent<EnemyManager>();
        if (enemyManager == null)
        {
            enemyManager = GetComponentInParent<EnemyManager>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        RotateEnemy();
    }

    public void RotateEnemy()
    {

        Vector3 direction = playerTransform.position - transform.position;
        if(direction.magnitude < enemyManager.enemyInfor.GetRangeAttack())
        {
            transform.LookAt(playerTransform.position);
        }
    }
}
