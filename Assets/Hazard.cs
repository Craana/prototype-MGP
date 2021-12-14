using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
		private HazardManager hazardManager;
	[SerializeField] float zSpawn = 0;
	
	
	[SerializeField] float backdistanceofPlayer = -35f;


	private void OnEnable() {
		hazardManager = GameObject.FindObjectOfType<HazardManager>();
	}
	
	private void Update() {
		if (hazardManager.playerTransform.position.z + backdistanceofPlayer > this.gameObject.transform.position.z)
		{
			hazardManager.RecyclePlatform(this.gameObject);
		}
	}
}
