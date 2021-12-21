using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

	public LifeCounter lifeCounter;

	private void Start() 
	{
		
	}


	// Update is called once per frame
	void Update()
	{
		LifeInspector();
	}

	void LifeInspector()
	{
		if (lifeCounter.life == 0 )
		{
			SceneManager.LoadScene(0);
		}
	}

}
