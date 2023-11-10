using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private float SpeedRotate;
    private Rigidbody rb;

    private Vector3 anglePlayer;
    private bool flyPlane;

    float horizontal, vertical;

    Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw(Axis.HORIZONTAL_AXIS);
        vertical = Input.GetAxisRaw(Axis.VERTICAL_AXIS);

       // anglePlayer = transform.eulerAngles;
        RotateAnglePlayer();
        
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }
    public void PlayerMove()
    {
        // di chuyển player
        if (Input.GetKey(KeyCode.P))
        {
            flyPlane = true;
        }

        if(flyPlane )
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
        }

    }

    public void RotateAnglePlayer()
    {
        rotation= transform.rotation;   
        anglePlayer = transform.eulerAngles;
        // quay player
        if (horizontal != 0 )
        {
            anglePlayer.z -=horizontal* SpeedRotate * Time.deltaTime;
            anglePlayer.y +=horizontal* SpeedRotate * Time.deltaTime;
            rotation = Quaternion.Euler(anglePlayer);
        }

        if (vertical != 0)
        {
            anglePlayer.x -=vertical* SpeedRotate * Time.deltaTime;
            rotation = Quaternion.Euler(anglePlayer);

        }
        transform.rotation = rotation;
    }

}
