using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSounds : MonoBehaviour {

	[SerializeField] private AudioClip[] jerrySounds;
	[SerializeField] private AudioClip[] georgeSounds;
	[SerializeField] private AudioClip[] elaineSounds;
	[SerializeField] private AudioClip[] kramerSounds;
	[SerializeField] private AudioClip[] newmanSounds;
	[SerializeField] private AudioSource globalAudioSource;
 
	public void playCharacterSound(ticTacManager.Players chosenPlayer)
	{
		switch (chosenPlayer) 
		{

		case(ticTacManager.Players.Jerry):
			{
				globalAudioSource.PlayOneShot(jerrySounds[Random.Range(0, jerrySounds.Length)]);
				break;
			}
		case(ticTacManager.Players.George):
			{
				globalAudioSource.PlayOneShot (georgeSounds [Random.Range (0, georgeSounds.Length)]);
				break;
			}
		case(ticTacManager.Players.Elaine):
			{
				globalAudioSource.PlayOneShot (elaineSounds [Random.Range (0, elaineSounds.Length)]);
				break;
			}
		case(ticTacManager.Players.Kramer):
			{
				globalAudioSource.PlayOneShot (kramerSounds [Random.Range (0, kramerSounds.Length)]);
				break;
			}
		case(ticTacManager.Players.Newman):
			{
				globalAudioSource.PlayOneShot (newmanSounds [Random.Range (0, newmanSounds.Length)]);
				break;			
			}
		}
	}

};