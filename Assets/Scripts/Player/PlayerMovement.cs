using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float Speed;
    [SerializeField] private float SpeedRotate;
    private PlayerManager playerManager;
    private Rigidbody rb;

    private Vector3 anglePlayer;

    float horizontal, vertical;

    // Start is called before the first frame update
    void Start()
    {
        Speed = 3f;
       
        rb = GetComponent<Rigidbody>();
        playerManager = GetComponentInChildren<PlayerManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw(Axis.HORIZONTAL_AXIS);
        vertical = Input.GetAxisRaw(Axis.VERTICAL_AXIS);

        if (!playerManager.GetPlayerDie() && !GameManager.Instance.isWin)
        {
            PlayerMove();
            RotateAnglePlayer();
        }

    }

    public void PlayerMove()
    {
        if (Input.GetKey(KeyCode.Q) && Speed < playerManager.playerInfor.GetMaxSpeed())
        {
            Speed += Time.deltaTime*4f;
        }
        if (Input.GetKey(KeyCode.E) && Speed >5f)
        {
            Speed -= Time.deltaTime * 4f;
        }

        if (Speed != 0)
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
        }
    }

    public void RotateAnglePlayer()
    {
        anglePlayer = transform.eulerAngles;
        // quay player theo horizontal
        if (horizontal != 0)
        {
            // Chuyển đổi giá trị góc về khoảng -180 đến 180 độ
            anglePlayer.z = (anglePlayer.z > 180) ? anglePlayer.z - 360 : anglePlayer.z;
            if (anglePlayer.z >= -70f && anglePlayer.z <= 70f )
            {
                anglePlayer.z -= horizontal * SpeedRotate * Time.deltaTime;
            }
            else if (anglePlayer.z < -70f)
            {
                anglePlayer.z = -70f;
            } 
            else if (anglePlayer.z > 70f)     
            {
                anglePlayer.z = 70f;
            }

            //quay trục y player
            anglePlayer.y += horizontal * SpeedRotate * Time.deltaTime;
            transform.rotation = Quaternion.Euler(anglePlayer);

        }

        if (vertical != 0)
        {
            anglePlayer.x -= vertical * SpeedRotate * Time.deltaTime;
            transform.rotation = Quaternion.Euler(anglePlayer);
        }
    }
    public float GetSpeed()
    {
        return this.Speed;
    }

}
