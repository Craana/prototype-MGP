using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{

    [SerializeField] GameObject[] platforms;

    
    void Start()
    {
        Vector3 pos = new Vector3(0, 0, 0);

        

        for (int i = 0; i < 15; i++)
        {
            int platformNumber = Random.Range(0, platforms.Length);
            Instantiate(platforms[platformNumber], pos, Quaternion.identity);
            pos.z += 20;
        }
    }
}
