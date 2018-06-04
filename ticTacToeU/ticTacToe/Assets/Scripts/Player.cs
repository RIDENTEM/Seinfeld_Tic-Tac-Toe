using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player {
	 
		public ticTacManager.Players playerCharacter;
		public Texture playerCharacterTexture;
		public string playerTurnText;
		public bool isPlayer1 = false;
		public Player()
		{

			isPlayer1 = !isPlayer1;
		}
	 
}
