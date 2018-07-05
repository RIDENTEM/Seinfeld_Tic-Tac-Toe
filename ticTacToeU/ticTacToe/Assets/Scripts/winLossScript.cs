using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winLossScript : MonoBehaviour
{

    [SerializeField] Text winText;
    [SerializeField] Text tieText;
    [SerializeField] Text playerTurnText;
    [SerializeField] GameObject winLossPanel;


    public void gameWon()
    {
		ticTacManager.overallTurnNumber = 0;
        ticTacManager.gameWon = true;
        winLossPanel.SetActive(true);
        playerTurnText.gameObject.SetActive(false);
        tieText.gameObject.SetActive(false);
        winText.gameObject.SetActive(true);
        winText.text =  ticTacManager.currentPlayer.playerCharacter + " wins!";
    }
    public void gameTied()
    {
		ticTacManager.overallTurnNumber = 0;

        playerTurnText.gameObject.SetActive(false);
        tieText.gameObject.SetActive(true);
        tieText.text = "Nobody won!";
        winText.gameObject.SetActive(false);
        winLossPanel.SetActive(true);
    }


}
