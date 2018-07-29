using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class entryAnimation : MonoBehaviour
{


    [SerializeField] private GameObject player1Image;
    [SerializeField] private GameObject player2Image;
    [SerializeField] private AudioSource globalAudioSource;

    void Start()
    {
        player1Image.GetComponent<RawImage>().texture = ticTacManager.player1.playerCharacterTexture;
        player2Image.GetComponent<RawImage>().texture = ticTacManager.player2.playerCharacterTexture;

        player1Image.GetComponent<Animation>().Play();
        player2Image.GetComponent<Animation>().Play();

        StartCoroutine(playIntros());
    }

    // AudioClip checkClipToPlay()
    // {
    //   my goal here is to create a system that will determine which audio clip to play first from each character chosen, but right now I don't have enough clips to make or test this, so i am going to proceed
    // as if they were all general
    // }

    IEnumerator playIntros()
    {
        globalAudioSource.PlayOneShot(ticTacManager.player1.playerIntro);
        yield return new WaitForSeconds(ticTacManager.player1.playerIntro.length);
        globalAudioSource.PlayOneShot(ticTacManager.player2.playerIntro);

    }


}
