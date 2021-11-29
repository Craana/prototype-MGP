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
    private List<GameObject> ActiveTiles = new List<GameObject>();

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
     
    }

    void addtile()
    {

    }
}