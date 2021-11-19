using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{

    [SerializeField] GameObject[] platforms;
    [SerializeField] float offset = 2f;
    private int offsetCounter = 0;
    [SerializeField] private float platformlength;
    [SerializeField] Transform playerTransform;

    void Start()    
    {
        Vector3 pos = new Vector3(0, 0, 0);
        for (int i = 0; i < 3; i++)
        {
            int platformNumber = Random.Range(0, platforms.Length);
            Instantiate(platforms[platformNumber], pos, Quaternion.identity);
            pos.z += 20;
        }
    }


    private void Update()
    {
        float camerapos = Camera.main.transform.position.z;
       // Debug.Log(camerapos);
        for (int i = 0; i < platforms.Length; i++)
        {
           float platformposition = platforms[0].transform.position.z;

            if (platformposition < playerTransform.position.z)
            {
                Debug.Log("Am I doing something?");
                // For this which ever platform is behind sets to the front of character
                offsetCounter++;
                platforms[0].transform.position = new Vector3(platforms[i].transform.position.x , platforms[i].transform.position.y, platforms[i].transform.position.z + platformposition);
            }
        }
    }


}