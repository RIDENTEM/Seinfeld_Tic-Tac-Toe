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
    private LineRenderer winningLine;

    private void Start()
    {
        winningLine = GetComponent<LineRenderer>();
    }

    public void gameWon(List<int> rowIndexes, List<int> columnIndexes, GameObject[,] arrayOfTiles)
    {
        Vector3 firstVertex = arrayOfTiles[rowIndexes[0], columnIndexes[0]].gameObject.transform.position;
        firstVertex.z = 90.0f;
        Vector3 lastVertex = arrayOfTiles[rowIndexes[rowIndexes.Count - 1], columnIndexes[columnIndexes.Count - 1]].transform.position;
        lastVertex.z = 90.0f;

        Debug.Log(rowIndexes.Count);
        Debug.Log(columnIndexes.Count);
        winningLine.enabled = true;
        winningLine.SetPosition(0, firstVertex);
        winningLine.SetPosition(1, lastVertex);
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
