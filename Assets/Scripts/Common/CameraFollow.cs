using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetObject;
    public float smooth = 2f;
    public Vector3 cameraOffset= new Vector3(0, 10, -20);

    Vector3 newCameraPosition;

    void LateUpdate()
    {
        CameraMove();
        
    }

    private void CameraMove()
    {
        newCameraPosition = targetObject.position + targetObject.forward * cameraOffset.z + targetObject.up * cameraOffset.y;
        Vector3 cameraPosition = Vector3.Lerp(transform.position, newCameraPosition, smooth * Time.deltaTime);
        transform.position = cameraPosition;

        transform.LookAt(targetObject);
    }
}
