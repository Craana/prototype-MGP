using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
	public Text text;
	
	private void Start() 
	{
		
	}
	
	public void GameScene()
	{
		SceneManager.LoadScene(1);
	}	
	
	public void SoundOffOrOn()
	{
		
	}
}
