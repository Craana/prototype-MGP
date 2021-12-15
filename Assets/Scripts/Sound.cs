using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class Sound : MonoBehaviour
{
	public string Name;
   public AudioClip clip;
   [Range(0f, 1f)]
   public float volume;
	[Range(0f, 0.5f)]
	public float pitch;
	public bool loop;
	
	[HideInInspector]
	public AudioSource source;
}
