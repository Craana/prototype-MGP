using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{

	[SerializeField] GameObject[] _hazardPrefabs;
	[SerializeField] int hazardRange; 
	[SerializeField] 
	private int zOffset;
	
		[SerializeField] public Transform playerTransform;
 		
	// Start is called before the first frame update
	void Start()
	{
		for (int i = 0; i < _hazardPrefabs.Length; i++)
		{
			Instantiate(_hazardPrefabs[i], new Vector3(0,0, i * hazardRange), Quaternion.identity);
			zOffset += hazardRange;
		}
	
	}

	
	public void RecyclePlatform(GameObject platform)
	{
		platform.transform.position = new Vector3(0,0, zOffset);
		zOffset += hazardRange;
	}
}
