using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour 
{

	public static AudioManager Instance;

	public Sound[] Sounds;

	private void Start ()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
		} else
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in Sounds)
		{
			s.Source = gameObject.AddComponent<AudioSource>();
			s.Source.clip = s.Clip;
			s.Source.volume = s.Volume;
			s.Source.pitch = s.Pitch;
			s.Source.loop = s.loop;
		}
	}

	public void Play (string sound)
	{
		if (GameManager.Mute)
			return;

		Sound s = Array.Find(Sounds, item => item.Name == sound);
		s.Source.Play();
	}

}
