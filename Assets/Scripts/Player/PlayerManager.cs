using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    public PlayerSO playerInfor;
    [HideInInspector]
    public float currentHp, maxHp;
    public bool isDie;

    [Header("Player infor")]
    [SerializeField] private Slider sliderHpPlayer;
    [SerializeField] private Text txtSpeedPlayer;
    [SerializeField] private Text txtHeightPlayer;

    [SerializeField] private ParticleSystem[] listPS;

    private void Awake()
    {
        for (int i = 0; i < listPS.Length; i++)
        {
            listPS[i].Pause();
        }
    }
    private void Start()
    {

        isDie = false;
        maxHp = playerInfor.GetHp();
        currentHp = playerInfor.hp;
    }
    private void Update()
    {
        if (!isDie)
        {
            DisplayInforPlayer();
            PlaneStatus();
            Die();
        }
    }
    public void TakeDamage(float damage)
    {
        currentHp -= damage;
    }

    public void PlaneStatus()
    {
        if (currentHp <= maxHp / 2)
        {
            listPS[2].Play();
        }
       
    }

    public void Die()
    {
        if (currentHp <= 0)
        {
            //Debug.Log("endgame");
            listPS[1].transform.position = transform.position;
            listPS[1].Stop();
            listPS[1].Play();
            listPS[1].GetComponent<AudioSource>().enabled = true;
            StartCoroutine(WaitToEnd());
        }
    }
    private void DisplayInforPlayer()
    {
        float speed = GetComponentInParent<PlayerMovement>().GetSpeed();

        sliderHpPlayer.maxValue = maxHp;
        sliderHpPlayer.value = currentHp;

        txtHeightPlayer.text = "Height: " + Convert.ToInt32(transform.position.y);
        txtSpeedPlayer.text = "Speed: " + Convert.ToInt32(speed);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Bullet"))
        {
            BulletController bulletController = other.GetComponent<BulletController>();
            if (bulletController != null)
            {
                listPS[0].transform.position = other.transform.position;
                listPS[0].Stop();
                listPS[0].Play();
                TakeDamage(bulletController.GetDamageBullet());
                Destroy(other.gameObject);

            }
        }

        if (other.gameObject.CompareTag("Rocket"))
        {
            RocketController rocketController = other.GetComponent<RocketController>();
            if (rocketController != null)
            {
                TakeDamage(rocketController.GetDamageRocket());
                Destroy(other.gameObject);
            }
        } 

        if (!(other.gameObject.CompareTag("Rocket")||other.gameObject.CompareTag("Bullet")))
        {
            currentHp = 0;
        }
    }

    IEnumerator WaitToEnd()
    {
        yield return new WaitForSeconds(0.8f);
        if (!isDie)
        {
            isDie = true;
            GameManager.Instance.endgame = true;
        }
    }

    public bool GetPlayerDie()
    {
        return this.isDie;

    }
}

