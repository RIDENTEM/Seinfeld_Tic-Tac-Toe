using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
public class entryAnimation : MonoBehaviour
{


    [SerializeField] private RawImage playerImage;
    [SerializeField] private RawImage player2Image; 
    private Animation player1Anim;
    private Animation player2Anim;
    private ticTacTileScript[] tileList;

    void Start()
    {
        tileList = (ticTacTileScript[])FindObjectsOfType(typeof(ticTacTileScript));



        playerImage.texture = ticTacManager.player1.playerCharacterTexture;
        player2Image.texture = ticTacManager.player2.playerCharacterTexture;

        player1Anim = playerImage.GetComponent<Animation>();
        player2Anim = player2Image.GetComponent<Animation>();

        player1Anim.Play();
        player2Anim.Play();
        
    }

    void animationCheck()
    {
        foreach(ticTacTileScript tile in tileList)
        {
           // if(tile.gameObject.GetComponent<Animator>().GetBool("introDone") == false)
           // {
           //     tile.GetComponent<Animator>().Play("fallDownAnimation");
           //    // tile.gameObject.GetComponent<Animator>().SetBool("introDone", true);
           // }
           // else
           // {
           //     tile.GetComponent<Animator>().Play("Idle");
           // }

            if (tile.GetComponent<Animator>().GetBool("clicked") == true)
            {
                tile.GetComponent<Animator>().Play("clickAnimation");
                tile.GetComponent<Animator>().SetBool("clicked", false);
            }
           
        }
    }

    // Update is called once per frame
    void Update()
    {
       // animationCheck();
        if (player1Anim && player2Anim)
            if (!player1Anim.isPlaying && !player2Anim.isPlaying)
            {
                Destroy(playerImage.gameObject);
                Destroy(player2Image.gameObject);
                Destroy(this);
            }
    }
}
