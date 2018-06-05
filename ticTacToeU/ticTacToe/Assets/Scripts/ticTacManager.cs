using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ticTacManager : MonoBehaviour
{

    public static bool gameWon;

    class PlayerMoves
    {
        public Players savedPlayer;
        public int[,] tileHit;
        private int turnNumber = overallTurnNumber;
    }





    public static bool isNormalGame;
    static public int overallTurnNumber = 1;

    private GameObject[,] gridTiles3x3 = new GameObject[3, 3];
    private GameObject[,] gridTiles4x4 = new GameObject[4, 4];




    public enum Players { Heart, Chip, None, Jerry, Kramer, George, Elaine, Newman };
    public static Player currentPlayer;
    public static Player player1;
    public static Player player2;

    [SerializeField] private GameObject panel3x3;
    [SerializeField] private GameObject panel4x4;
    [SerializeField] private Texture heartImage;
    [SerializeField] private Texture chipImage;
    public Text playerTurnText;
    public Button[] gridButtons3x3;
    public Button[] gridButtons4x4;

    private List<PlayerMoves> playerMovesToSave;
    private winLossScript winLossObject;

    private void Start()
    {

        gameWon = false;
        winLossObject = FindObjectOfType<winLossScript>();
        playerMovesToSave = new List<PlayerMoves>();
        playerMovesToSave.Capacity = 3;
        currentPlayer = player1;
        populateTilesArray();
        typeOfGrid();
    }



    void typeOfGrid()
    {
        if (isNormalGame)
        {
            panel3x3.SetActive(true);
            panel4x4.SetActive(false);
        }
        else if (!isNormalGame)
        {
            panel3x3.SetActive(false);
            panel4x4.SetActive(true);
        }
    }

    public void displayPlayerTurn(Player currPlayer)
    {
        playerTurnText.text = currPlayer.playerTurnText;
    }

    public void genericWinCheck(int rowSize)
    {
        int totalRowSize = rowSize;
        int columnSize = rowSize;
        int totalColumnSize = rowSize;
        GameObject[,] tileArray;
        if (isNormalGame)
            tileArray = gridTiles3x3;
        else
            tileArray = gridTiles4x4;

        bool checkedRow = false;
        bool rowsChecked = false;
        bool checkedDiagonal = false;
        for (int columns = 0; columns < columnSize; columns++)
        {

            for (int rows = 0; rows < rowSize; rows++)
            {
                if (rows == rowSize - 1)
                {
                    if (rows == rowSize - 1 && tileArray[columns, rows - 1].GetComponent<ticTacTileScript>().playerSide == tileArray[columns, rows].GetComponent<ticTacTileScript>().playerSide &&
                        tileArray[columns, rows - 1].GetComponent<ticTacTileScript>().playerSide != Players.None && tileArray[columns, rows].GetComponent<ticTacTileScript>().playerSide != Players.None)
                    {
                        //gameWon!
                        Debug.Log("Win for one of the rows");
                        winLossObject.gameWon();
                    }
                    else if (rows == rowSize - 1 && tileArray[rows - 1, columns].GetComponent<ticTacTileScript>().playerSide == tileArray[rows, columns].GetComponent<ticTacTileScript>().playerSide &&
                        tileArray[rows - 1, columns].GetComponent<ticTacTileScript>().playerSide != Players.None && tileArray[rows, columns].GetComponent<ticTacTileScript>().playerSide != Players.None)
                    {
                        //gameWon!
                        Debug.Log("Win for one of the columns");
                        winLossObject.gameWon();
                    }
                    //if the last tile in the diagonal from the left is the same as the one before it in the diagonal, you win
                    else if (columns == rowSize - 1 && rows == rowSize - 1 && tileArray[columns, rows].GetComponent<ticTacTileScript>().playerSide == tileArray[columns - 1, rows - 1].GetComponent<ticTacTileScript>().playerSide
                        && tileArray[columns, rows].GetComponent<ticTacTileScript>().playerSide != Players.None && tileArray[columns - 1, rows - 1].GetComponent<ticTacTileScript>().playerSide != Players.None)
                    {
                        //gameWon!
                        Debug.Log("Win for the diagonal starting from the left");

                        winLossObject.gameWon();

                    }
                    //if the last tile in the diagonal from the right is the same as the one before it in the diagonal
                    else if (columns + rows == rowSize && rows == rowSize - 1 && tileArray[columns, rows].GetComponent<ticTacTileScript>().playerSide == tileArray[columns + 1, rows - 1].GetComponent<ticTacTileScript>().playerSide
                        && rows == rowSize - 1 && tileArray[columns, rows].GetComponent<ticTacTileScript>().playerSide != Players.None && tileArray[columns + 1, rows - 1].GetComponent<ticTacTileScript>().playerSide != Players.None)
                    {
                        //gameWon!
                        Debug.Log("Win for the diagonal starting from the right");
                        winLossObject.gameWon();

                    }
                }

                //if all the rows have not been checked yet
                if (rowsChecked == false)
                {
                    //as long as one of the rows hasn't been checked or one of them can't be a winner
                    if (checkedRow == false)
                    {
                        //as long as tile counter isn't on the last tile in the sequence, compare all the tiles it is currently on to the next one up
                        if (rows != totalRowSize - 1)
                        {

                            if (tileArray[rows, columns].GetComponent<ticTacTileScript>().playerSide == tileArray[rows + 1, columns].GetComponent<ticTacTileScript>().playerSide)
                                continue;
                            else
                            {
                                checkedRow = true;
                                rows = 0;
                            }
                        }
                    }
                    //if the rows have been checked
                    else if (checkedRow == true)
                    {
                        //it is time to move on to the columns
                        if (rows != totalRowSize - 1)
                            //I need to decide what I actually want here, I might need to make separate for loops for each one(row,column, diagonal)
                        {
                            if (tileArray[columns, rows].GetComponent<ticTacTileScript>().playerSide == tileArray[rows + 1, columns].GetComponent<ticTacTileScript>().playerSide)
                                continue;
                            else
                            {
                                rowsChecked = true;
                                rows = 0;
                            }
                        }
                    }
                }

                if (checkedDiagonal == false && checkedRow == false)
                {

                    if (columns + rows == rowSize)
                        continue;
                    else
                    {
                        checkedDiagonal = true;
                        break;
                    }

                }

                else if (checkedDiagonal == true && rowsChecked == true)
                {
                    if (rows == columns)
                        continue;
                    else
                        break;



                }

            }
            if (overallTurnNumber == rowSize * rowSize && gameWon == false)
            {
                winLossObject.gameTied();
            }
        }
    }

    void populateTilesArray()
    {
        if (isNormalGame)
        {
            for (int i = 0; i < 9; i++)
            {
                gridButtons3x3[i].GetComponent<ticTacTileScript>().playerSide = Players.None;
            }
            int gridButtonCounter3x3 = 0;
            //use the 3x3
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //pretty sure I have to switch these because I check the positions of the array by x,y ([0,1],[0,2],[0,3]) / not y,x
                    gridTiles3x3[j, i] = gridButtons3x3[gridButtonCounter3x3].gameObject;

                    gridButtonCounter3x3++;
                }
            }
        }
        else
        {
            for (int i = 0; i < 16; i++)
            {
                gridButtons4x4[i].GetComponent<ticTacTileScript>().playerSide = Players.None;
            }
            int gridButtonCounter4x4 = 0;
            //use the 4x4
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    gridTiles4x4[j, i] = gridButtons4x4[gridButtonCounter4x4].gameObject;
                    gridButtonCounter4x4++;
                }
            }
        }



    }


    public void storeMoves(int tileIndex)
    {
        PlayerMoves newPlayerMove = new PlayerMoves();
        newPlayerMove.savedPlayer = currentPlayer.playerCharacter;
        if (isNormalGame)
            switch (tileIndex)
            {
                case 0:
                    newPlayerMove.tileHit = new int[0, 0];
                    break;
                case 1:
                    newPlayerMove.tileHit = new int[1, 0];
                    break;
                case 2:
                    newPlayerMove.tileHit = new int[2, 0];
                    break;
                case 3:
                    newPlayerMove.tileHit = new int[0, 1];
                    break;
                case 4:
                    newPlayerMove.tileHit = new int[1, 1];
                    break;
                case 5:
                    newPlayerMove.tileHit = new int[2, 1];
                    break;
                case 6:
                    newPlayerMove.tileHit = new int[0, 2];
                    break;
                case 7:
                    newPlayerMove.tileHit = new int[1, 2];
                    break;
                case 8:
                    newPlayerMove.tileHit = new int[2, 2];
                    break;
            }
        else if (!isNormalGame)
            switch (tileIndex)
            {
                case 0:
                    newPlayerMove.tileHit = new int[0, 0];
                    break;
                case 1:
                    newPlayerMove.tileHit = new int[1, 0];
                    break;
                case 2:
                    newPlayerMove.tileHit = new int[2, 0];
                    break;
                case 3:
                    newPlayerMove.tileHit = new int[3, 0];
                    break;
                case 4:
                    newPlayerMove.tileHit = new int[0, 1];
                    break;
                case 5:
                    newPlayerMove.tileHit = new int[1, 1];
                    break;
                case 6:
                    newPlayerMove.tileHit = new int[2, 1];
                    break;
                case 7:
                    newPlayerMove.tileHit = new int[3, 1];
                    break;
                case 8:
                    newPlayerMove.tileHit = new int[0, 2];
                    break;
                case 9:
                    newPlayerMove.tileHit = new int[1, 2];
                    break;
                case 10:
                    newPlayerMove.tileHit = new int[2, 2];
                    break;
                case 11:
                    newPlayerMove.tileHit = new int[3, 2];
                    break;
                case 12:
                    newPlayerMove.tileHit = new int[3, 0];
                    break;
                case 13:
                    newPlayerMove.tileHit = new int[3, 1];
                    break;
                case 14:
                    newPlayerMove.tileHit = new int[3, 2];
                    break;
                case 15:
                    newPlayerMove.tileHit = new int[3, 3];
                    break;

            }

        playerMovesToSave.Add(newPlayerMove);
    }










}
