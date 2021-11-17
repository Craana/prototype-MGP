using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gyrorotation2 : MonoBehaviour
{
    Quaternion offset;

    void Awake()
    {
        Input.gyro.enabled = true;
    }

    void Start()
    {
        //Subtract Quaternion
        offset = transform.rotation * Quaternion.Inverse(GyroToUnity(Input.gyro.attitude));
    }

    void Update()
    {
        GyroModifyCamera();
    }

    void GyroModifyCamera()
    {
        //Apply offset
        transform.rotation = offset * GyroToUnity(Input.gyro.attitude);
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
