using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winLossScript : MonoBehaviour {

    [SerializeField] Text winText;
    [SerializeField] Text tieText;
    [SerializeField] GameObject winLossPanel;

    public void gameWon()
    {
        winLossPanel.SetActive(true);

        winText.text += ticTacManager.currentPlayer + " wins!";


    }


}
