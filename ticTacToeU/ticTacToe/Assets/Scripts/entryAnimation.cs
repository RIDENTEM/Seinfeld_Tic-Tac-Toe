using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
public class entryAnimation : MonoBehaviour
{


    [SerializeField] private GameObject player1Image;
    [SerializeField] private GameObject player2Image;
    [SerializeField] private AudioSource globalAudioSource;
    private ticTacTileScript[] tileList;
     
    

    void Start()
    {
        tileList = (ticTacTileScript[])FindObjectsOfType(typeof(ticTacTileScript));

        
        player1Image.GetComponent<RawImage>().texture = ticTacManager.player1.playerCharacterTexture;
        player2Image.GetComponent<RawImage>().texture = ticTacManager.player2.playerCharacterTexture;

        player1Image.GetComponent<Animation>().Play();
        player2Image.GetComponent<Animation>().Play();


        //Decided to put the code for intros here, since it is pretty much happening at the same time as the intro animation too
        globalAudioSource.PlayOneShot(ticTacManager.player1.playerIntro);
        //if the first intro is done play the second one
        if(!globalAudioSource.isPlaying)
        globalAudioSource.PlayOneShot(ticTacManager.player2.playerIntro);




    }

    // AudioClip checkClipToPlay()
    // {
    //   my goal here is to create a system that will determine which audio clip to play first from each character chosen, but right now I don't have enough clips to make or test this, so i am going to proceed
    // as if they were all general
    // }

        
    void Update()
    {
        if (player1Image.GetComponent<Animation>() && player2Image.GetComponent<Animation>())
            if (!player1Image.GetComponent<Animation>().isPlaying && !player2Image.GetComponent<Animation>().isPlaying)
            {
                Destroy(player1Image.gameObject);
                Destroy(player2Image.gameObject);
                Destroy(this);
            }
    }
}
