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
        offset = transform.rotation;// * Quaternion.Inverse(GyroToUnity(Input.gyro.attitude));
    }

    void FixedUpdate()
    {
        GyroManipulation();
    }

    void GyroManipulation()
    {
        //Apply offset
        transform.rotation = Input.gyro.attitude; //offset * GyroToUnity(Input.gyro.attitude); //* Quaternion.Euler(0,0,90);
    }

    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
