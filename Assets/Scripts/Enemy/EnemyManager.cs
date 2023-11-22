using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject gameObjectParent;
    [SerializeField] private ParticleSystem destroyPS;
    public EnemySO enemyInfor;
    private float currentHpEnemy;
    void Awake()
    {
        
        destroyPS.GetComponent<AudioSource>().enabled = false;
        destroyPS.Pause();
        currentHpEnemy = enemyInfor.hp;
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }
    public void Die()
    {
        if (currentHpEnemy <= 0)
        {
            destroyPS.Stop();
            destroyPS.Play();
            destroyPS.GetComponent<AudioSource>().enabled = true;
            StartCoroutine(WaitToDie());
        }
    }

    public void TakeDamage(float damage)
    {
        currentHpEnemy -= damage;
        //Debug.Log("Enemy hp: "+currentHpEnemy);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet")) {
            BulletController bulletController = other.GetComponent<BulletController>();
            if (bulletController != null)
            {
                TakeDamage(bulletController.GetDamageBullet());
            }
        }

        if (other.gameObject.CompareTag("Rocket"))
        {
            RocketController rocketController = other.GetComponent<RocketController>();
            if(rocketController != null)
            {
                TakeDamage(rocketController.GetDamageRocket());
            }
        }
    }

    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObjectParent);

    }
}
