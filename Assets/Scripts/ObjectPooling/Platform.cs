using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
	private PlatformManager _platformManager;
	[SerializeField] float zSpawn = 0;
	
	
	[SerializeField] float backdistanceofPlayer = -35f;


	private void OnEnable() {
		_platformManager = GameObject.FindObjectOfType<PlatformManager>();
	}
	
	private void Update() {
		if (_platformManager.playerTransform.position.z + backdistanceofPlayer > this.gameObject.transform.position.z)
		{
			_platformManager.RecyclePlatform(this.gameObject);
		}
	}
	
  private void OnBecameInvisible() 
  {
	  
  }
}
