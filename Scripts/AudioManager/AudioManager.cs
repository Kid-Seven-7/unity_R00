using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour 
{
	public	Sound[]	sounds;

	// Use this for initialization
	void Awake () 
	{
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();

			s.source.clip = s.clip;
			s.source.volume = s.volume;
			s.source.pitch  = s.pitch;
		}	
	}
	
	// Update is called once per frame
	public	void Play(string name)
	{
		// Searching for the name in the Sounds[] array to play it
		Sound s = Array.Find(sounds, sounds => sounds.name == name);
		s.source.Play();

		//To play this
		//FindObjectOfType<AudioManager>().Play("SOUND NAME");
	}
}
