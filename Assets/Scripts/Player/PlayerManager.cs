using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public PlayerSO playerInfor;
    public float currentHp;

    private void Start()
    {
        currentHp= playerInfor.hp;
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Bullet"))
        {
            BulletController bulletController = other.GetComponent<BulletController>();
            if (bulletController != null)
            {
                TakeDamage(bulletController.GetDamageBullet());

            }
        }
    }

}

