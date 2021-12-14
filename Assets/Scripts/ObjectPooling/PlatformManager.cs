using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
	[SerializeField] GameObject[] _platformPrefabs;
	[SerializeField] int platformLength; 
	[SerializeField] 
	private int zOffset;
	
		[SerializeField] public Transform playerTransform;
 		
	// Start is called before the first frame update
	void Start()
	{
		for (int i = 0; i < _platformPrefabs.Length; i++)
		{
			Instantiate(_platformPrefabs[i], new Vector3(0,0, i * platformLength), Quaternion.identity);
			zOffset += platformLength;
		}
	}

	
	public void RecyclePlatform( GameObject platform)
	{
		platform.transform.position = new Vector3(0,0, zOffset);
		zOffset += platformLength;
	}
}
