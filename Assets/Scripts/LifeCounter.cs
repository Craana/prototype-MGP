using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
	public int life = 3;
	
	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}
	
	public int lifeStatus()
	{
		return life;
	} 
	
	public void decreaseLife()
	{
		life--;
	}
	
	
}
