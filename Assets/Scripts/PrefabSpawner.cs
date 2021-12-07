using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] tilePrefabs;
    [SerializeField] float zSpawn = 0;
    [SerializeField] float tileLength = 30;
    [SerializeField] int numberOfTiles = 5;
   
    private List<GameObject> activeTiles = new List<GameObject>();

    [SerializeField] Transform playerTransform;
    [SerializeField] float backdistanceofPlayer = -35f;
  
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i==0)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(Random.Range(0, tilePrefabs.Length));
            }
        }
    }

    void Update()
    {
        if (playerTransform.position.z + backdistanceofPlayer > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0,tilePrefabs.Length));
            DeleteTile();
        }
    }
    


    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward*zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }



}
