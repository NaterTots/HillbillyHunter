using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour, IController
 {
	public AudioSource musicSource;
	public AudioSource effectsSource;

	//Used to play single sound clips.
	public void PlayClip(AudioClip clip)
	{
		//Set the clip of our efxSource audio source to the clip passed in as a parameter.
		effectsSource.clip = clip;

		//Play the clip.
		effectsSource.Play();
	}

	//Used to play single sound clips with PlayOneShot, which can't be paused
	public void PlayClipOneShot(AudioClip clip)
	{
		//Play the clip.
		effectsSource.PlayOneShot(clip);
	}

	//used to play background music
	public void PlayMusic(AudioClip clip)
	{
		musicSource.clip = clip;
		musicSource.Play();
	}


	#region IController

	public void Cleanup()
	{

	}

	#endregion IController

}
