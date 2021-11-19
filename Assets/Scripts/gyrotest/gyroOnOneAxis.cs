using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gyroOnOneAxis : MonoBehaviour
{
    private void Start()
    {
        Input.gyro.enabled = true;
    }

    private void Update()
    {
        Vector3 previousEulerAngles = transform.eulerAngles;
        Vector3 gyroInput = -Input.gyro.rotationRateUnbiased;

        Vector3 targetEulerAngles = previousEulerAngles + gyroInput * Time.deltaTime * Mathf.Rad2Deg;
        targetEulerAngles.x = 0.0f; // Only this line has been added
        targetEulerAngles.z = 0.0f;

        transform.eulerAngles = targetEulerAngles;

        //You should also be able do it in one line if you want:
        //transform.eulerAngles = new Vector3(0.0f, transform.eulerAngles.y - Input.gyro.rotationRateUnbiased.y * Time.deltaTime * Mathf.Rad2Deg, 0.0f);
    }
}
