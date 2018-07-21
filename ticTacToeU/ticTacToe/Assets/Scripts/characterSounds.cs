using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSounds : MonoBehaviour
{

    [SerializeField] private AudioClip[] jerrySounds;
    [SerializeField] private AudioClip[] georgeSounds;
    [SerializeField] private AudioClip[] elaineSounds;
    [SerializeField] private AudioClip[] kramerSounds;
    [SerializeField] private AudioClip[] newmanSounds;
    [SerializeField] private AudioSource globalAudioSource;
    private List<AudioClip> jerryListOfRemoveableClips;
    private List<AudioClip> georgeListOfRemoveableClips;
    private List<AudioClip> elaineListOfRemoveableClips;
    private List<AudioClip> kramerListOfRemoveableClips;
    private List<AudioClip> newmanListOfRemoveableClips;


    private void Awake()
    {
        for (int j = 0; j < jerrySounds.Length; j++)
        {
            jerryListOfRemoveableClips.Add(jerrySounds[j]);
        }
        for (int g = 0; g < georgeSounds.Length; g++)
        {
            georgeListOfRemoveableClips.Add(georgeSounds[g]);
        }
        for (int e = 0; e < elaineSounds.Length; e++)
        {
            elaineListOfRemoveableClips.Add(elaineSounds[e]);
        }
        for (int k = 0; k < kramerSounds.Length; k++)
        {
            kramerListOfRemoveableClips.Add(kramerSounds[k]);
        }
        for (int n = 0; n < newmanSounds.Length; n++)
        {
            newmanListOfRemoveableClips.Add(newmanSounds[n]);
        }
    }

    public void playCharacterSound(ticTacManager.Players chosenPlayer)
    {
        switch (chosenPlayer)
        {

            case (ticTacManager.Players.Jerry):
                {

                    int jerryRandNum = Random.Range(0, jerryListOfRemoveableClips.Count);
                    globalAudioSource.PlayOneShot(jerryListOfRemoveableClips[jerryRandNum]);
                    jerryListOfRemoveableClips.Remove(jerryListOfRemoveableClips[jerryRandNum]);
                    if (jerryListOfRemoveableClips.Count == 0)
                    {
                        for (int j = 0; j < jerrySounds.Length; j++)
                        {
                            jerryListOfRemoveableClips.Add(jerrySounds[j]);
                        }
                    }
                    break;
                }
            case (ticTacManager.Players.George):
                {
                    int georgeRandNum = Random.Range(0, georgeListOfRemoveableClips.Count);

                    globalAudioSource.PlayOneShot(georgeListOfRemoveableClips[georgeRandNum]);
                    georgeListOfRemoveableClips.Remove(georgeListOfRemoveableClips[georgeRandNum]);
                    if (georgeListOfRemoveableClips.Count == 0)
                    {
                        for (int g = 0; g < georgeSounds.Length; g++)
                        {
                            georgeListOfRemoveableClips.Add(georgeSounds[g]);
                        }
                    }

                    break;
                }
            case (ticTacManager.Players.Elaine):
                {
                    int elaineRandNum = Random.Range(0, elaineListOfRemoveableClips.Count);

                    globalAudioSource.PlayOneShot(elaineListOfRemoveableClips[elaineRandNum]);
                    elaineListOfRemoveableClips.Remove(elaineListOfRemoveableClips[elaineRandNum]);
                    if (elaineListOfRemoveableClips.Count == 0)
                    {
                        for (int e = 0; e < elaineSounds.Length; e++)
                        {
                            elaineListOfRemoveableClips.Add(elaineSounds[e]);
                        }
                    }
                    break;
                }
            case (ticTacManager.Players.Kramer):
                {

                    int kramerRandNum = Random.Range(0, kramerListOfRemoveableClips.Count);
                    globalAudioSource.PlayOneShot(kramerListOfRemoveableClips[kramerRandNum]);
                    kramerListOfRemoveableClips.Remove(kramerListOfRemoveableClips[kramerRandNum]);
                    if (kramerListOfRemoveableClips.Count == 0)
                    {
                        for (int k = 0; k < kramerSounds.Length; k++)
                        {
                            kramerListOfRemoveableClips.Add(kramerSounds[k]);
                        }
                    }
                    break;
                }
            case (ticTacManager.Players.Newman):
                {
                    int newmanRandNum = Random.Range(0, newmanListOfRemoveableClips.Count);
                    globalAudioSource.PlayOneShot(newmanListOfRemoveableClips[newmanRandNum]);
                    newmanListOfRemoveableClips.Remove(newmanListOfRemoveableClips[newmanRandNum]);
                    if(newmanListOfRemoveableClips.Count == 0)
                    {
                        for(int n = 0; n < newmanSounds.Length; n++)
                        {
                            newmanListOfRemoveableClips.Add(newmanSounds[n]);
                        }
                    }

                    break;
                }
        }
    }

};