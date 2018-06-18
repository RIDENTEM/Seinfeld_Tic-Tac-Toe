using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class entryAnimation : MonoBehaviour {


    Image player1Image;
    Image player2Image;

	// Use this for initialization
	void Start () {
        player1Image.material.mainTexture = ticTacManager.player1.playerCharacterTexture;
        player2Image.material.mainTexture = ticTacManager.player2.playerCharacterTexture;

       

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
