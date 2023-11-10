using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRocket : MonoBehaviour
{
    [SerializeField] GameObject rocketPrefabs;
    public float speed;
    //rocket
    Ray shootRay;
    RaycastHit shootHit;
    private int shootableLayerMask;
    private float range = 700f;

    private Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        shootableLayerMask = LayerMask.GetMask("Shootable");
    }

    // Update is called once per frame
    void Update()
    {
        ShootRockets();
    }

    public void ShootRockets()
    {
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        if (Physics.Raycast(shootRay, out shootHit, range, shootableLayerMask))
        {
            
            Debug.DrawLine(transform.position, shootHit.point, Color.red);
            Vector3 target = shootHit.collider.transform.position;
            Debug.Log(target);

            targetPos = target;
            shoot();
        }
    }

    public void shoot()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject newRock= Instantiate(rocketPrefabs,transform.position,transform.rotation);
            RocketController rocketController = newRock.GetComponent<RocketController>();
            rocketController.setTargetTransform(targetPos);

        }
    }
}
