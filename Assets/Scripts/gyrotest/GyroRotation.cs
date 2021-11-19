using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroRotation : MonoBehaviour
{
    private Gyroscope gyroscope;
    private bool isGyroAvailable;

    
    void Start()
    {
        isGyroAvailable = SystemInfo.supportsGyroscope;
        if (isGyroAvailable)
        {
            Input.gyro.enabled = true;
            gyroscope = Input.gyro;
        }
        transform.rotation = gyroRotation(Input.gyro.attitude);
        
    }

    
    void Update()
    {

        if (isGyroAvailable)
        {
            transform.rotation = gyroRotation(Input.gyro.attitude) ;
        }

    }


    Quaternion gyroRotation(Quaternion q)
    {
        return new Quaternion(q.x, q.y, q.z, q.w);
    }

}
