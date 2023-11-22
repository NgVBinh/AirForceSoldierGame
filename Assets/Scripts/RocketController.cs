using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public float speed = 1.0f;
    private Vector3 targetPos = Vector3.zero;
    private float damageRocket;

    [SerializeField] private ParticleSystem particleSys;

    private void Start()
    {
        particleSys.Pause();
    }
    public void setTargetTransform(Vector3 position)
    {
        targetPos = position;
    }

    public float GetDamageRocket()
    {
        return damageRocket;
    }
    public void SetDamageRocket(float damage)
    {
        this.damageRocket = damage;
    }
    // Update is called once per frame
    void Update()
    {
        if(targetPos != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                particleSys.transform.localScale = Vector3.one;
            }
            particleSys.transform.position = other.transform.position;
            particleSys.Stop();
            particleSys.Play();
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Terrain"))
        {
            Vector3 hitPoint = other.ClosestPointOnBounds(transform.position);
            if (hitPoint != Vector3.zero)
            {
                particleSys.transform.position = hitPoint;
                particleSys.Stop();
                particleSys.Play();
                gameObject.SetActive(false);
            }
        }
    }

}
