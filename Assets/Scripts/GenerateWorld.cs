using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{

    [SerializeField] GameObject[] platforms;
    //[SerializeField] float offset = 2f;
    private int offsetCounter = 0;
    [SerializeField] private float platformlength;
    [SerializeField] Transform playerTransform;
    [SerializeField] int numberOfPlatforms;
    private List<GameObject> ActiveTiles = new List<GameObject>();

    void Start()    
    {
        Vector3 pos = new Vector3(0, 0, 0);
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            Instantiate(platforms[i], pos, Quaternion.identity);
            pos.z += platformlength;
        }
    }

    private void Update()
    {
     
    }

    void addtile()
    {

    }
}