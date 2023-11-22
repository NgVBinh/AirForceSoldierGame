using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public Transform centerPoint;   // Tâm của đường tròn
    public float radius ;       // Bán kính của đường tròn
    public float speed;        // Tốc độ di chuyển

    private float angle = 0f;       // Góc hiện tại

    void Update()
    {
        float x = centerPoint.position.x + Mathf.Cos(angle) * radius;
        float z = centerPoint.position.z + Mathf.Sin(angle) * radius;

        transform.position = new Vector3(x, centerPoint.position.y, z);

        float rotationAngle = Mathf.Atan2(z - centerPoint.position.z, x - centerPoint.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, rotationAngle, 0f);

        angle += speed * Time.deltaTime;

        if (angle > 2 * Mathf.PI)
        {
            angle -= 2 * Mathf.PI;
        }
    }
}
