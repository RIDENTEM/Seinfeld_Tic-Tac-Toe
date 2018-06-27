using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
public class entryAnimation : MonoBehaviour
{


    [SerializeField] private RawImage playerImage;
    [SerializeField] private RawImage player2Image;
    [SerializeField] private GameObject[] tiles;

    private Animation player1Anim;
    private Animation player2Anim;



    void Start()
    {
        for(int i = 0; i < tiles.Length; i++)
        {
            tiles[i].GetComponent<Animation>().Play();
        }
        playerImage.texture = ticTacManager.player1.playerCharacterTexture;
        player2Image.texture = ticTacManager.player2.playerCharacterTexture;

        player1Anim = playerImage.GetComponent<Animation>();
        player2Anim = player2Image.GetComponent<Animation>();

        player1Anim.Play();
        player2Anim.Play();


        //   player1Animator.


    }

    // Update is called once per frame
    void Update()
    {
        if (player1Anim && player2Anim)
            if (!player1Anim.isPlaying && !player2Anim.isPlaying)
            {
                Destroy(playerImage.gameObject);
                Destroy(player2Image.gameObject);
                Destroy(this);
            }
    }
}
