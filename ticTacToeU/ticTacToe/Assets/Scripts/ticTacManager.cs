using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ticTacManager : MonoBehaviour
{



    public delegate void onGameStartup();
    public static event onGameStartup startupDel;
    public static bool gameWon;

    class PlayerMoves
    {
        public Players savedPlayer;
        public int[,] tileHit;
        private int turnNumber = overallTurnNumber;
    }

  public  class Player
    {
        public Players playerCharacter;
        public Texture playerCharacterTexture;
        public Text playerTurnText;
        public bool isPlayer1 = false;
        public Player()
        {

            isPlayer1 = !isPlayer1;
        }
    }

    

    public static bool isNormalGame;
    static public int overallTurnNumber = 1;

    private GameObject[,] gridTiles3x3 = new GameObject[3, 3];
    private GameObject[,] gridTiles4x4 = new GameObject[4, 4];




    public enum Players { Heart, Chip, None, Jerry, Kramer, George, Elaine, Newman };
    public static Player currentPlayer;
    public static Player player1;
    public static Player player2;
    //public static Players player1;
    //public static Players player2;

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
		populateTilesArray ();
		typeOfGrid (); 
        if (startupDel != null)
            startupDel();
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

    public string displayPlayerTurn(Player currPlayer)
    {
        return currPlayer.playerTurnText.text;
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


    public void checkForWin()
    {

        if (isNormalGame)
        {
            #region tile[0,0]

            //Possible win situations for tile [0,0]
            if (gridTiles3x3[0, 0].GetComponent<ticTacTileScript>().playerSide ==
                gridTiles3x3[1, 0].GetComponent<ticTacTileScript>().playerSide
                && gridTiles3x3[1, 0].GetComponent<ticTacTileScript>().playerSide
                == gridTiles3x3[2, 0].GetComponent<ticTacTileScript>().playerSide

                && gridTiles3x3[0, 0].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles3x3[1, 0].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles3x3[2, 0].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {
                   winLossObject.gameWon();
                  
                Debug.Log("This is a win for the top row straight across");
                //go to win condition screen or something
            }
            if (gridTiles3x3[0, 0].GetComponent<ticTacTileScript>().playerSide ==
                gridTiles3x3[0, 1].GetComponent<ticTacTileScript>().playerSide
                && gridTiles3x3[0, 1].GetComponent<ticTacTileScript>().playerSide
                == gridTiles3x3[0, 2].GetComponent<ticTacTileScript>().playerSide

              && gridTiles3x3[0, 0].GetComponent<ticTacTileScript>().playerSide != Players.None
               && gridTiles3x3[0, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
               && gridTiles3x3[0, 2].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {
                   winLossObject.gameWon();
                  
                Debug.Log("This is a win for the left column");
            }
            if (gridTiles3x3[0, 0].GetComponent<ticTacTileScript>().playerSide ==
                 gridTiles3x3[1, 1].GetComponent<ticTacTileScript>().playerSide
               && gridTiles3x3[1, 1].GetComponent<ticTacTileScript>().playerSide ==
               gridTiles3x3[2, 2].GetComponent<ticTacTileScript>().playerSide

                   && gridTiles3x3[0, 0].GetComponent<ticTacTileScript>().playerSide != Players.None
                   && gridTiles3x3[1, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                  && gridTiles3x3[2, 2].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {

                  winLossObject.gameWon();
                   
                Debug.Log("This is a win for diagonal from tile [0,0]");
            }
            #endregion

            #region tile[1,1]
            if (gridTiles3x3[1, 1].GetComponent<ticTacTileScript>().playerSide == gridTiles3x3[0, 1].GetComponent<ticTacTileScript>().playerSide && gridTiles3x3[0, 1].GetComponent<ticTacTileScript>().playerSide == gridTiles3x3[2, 1].GetComponent<ticTacTileScript>().playerSide
                      && gridTiles3x3[1, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                    && gridTiles3x3[0, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                    && gridTiles3x3[2, 1].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {

                   winLossObject.gameWon();
                 
                Debug.Log("This is a win for the middle row straight across");
            }
            if (gridTiles3x3[1, 1].GetComponent<ticTacTileScript>().playerSide == gridTiles3x3[1, 0].GetComponent<ticTacTileScript>().playerSide && gridTiles3x3[1, 0].GetComponent<ticTacTileScript>().playerSide == gridTiles3x3[1, 2].GetComponent<ticTacTileScript>().playerSide
               && gridTiles3x3[1, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                   && gridTiles3x3[1, 0].GetComponent<ticTacTileScript>().playerSide != Players.None
                   && gridTiles3x3[1, 2].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {

                   winLossObject.gameWon();
                  
                Debug.Log("This is a win for middle column");
            }
            if (gridTiles3x3[1, 1].GetComponent<ticTacTileScript>().playerSide == gridTiles3x3[0, 2].GetComponent<ticTacTileScript>().playerSide && gridTiles3x3[0, 2].GetComponent<ticTacTileScript>().playerSide == gridTiles3x3[2, 0].GetComponent<ticTacTileScript>().playerSide
               && gridTiles3x3[1, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                   && gridTiles3x3[0, 2].GetComponent<ticTacTileScript>().playerSide != Players.None
                   && gridTiles3x3[2, 0].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {

                  winLossObject.gameWon();
                  
                Debug.Log("This is a win for diagonal from [0,2]");
            }

            #endregion

            #region tile[2,2]

            if (gridTiles3x3[2, 2].GetComponent<ticTacTileScript>().playerSide == gridTiles3x3[2, 1].GetComponent<ticTacTileScript>().playerSide && gridTiles3x3[2, 1].GetComponent<ticTacTileScript>().playerSide == gridTiles3x3[2, 0].GetComponent<ticTacTileScript>().playerSide
               && gridTiles3x3[2, 2].GetComponent<ticTacTileScript>().playerSide != Players.None
                    && gridTiles3x3[2, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                    && gridTiles3x3[2, 0].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {


                   winLossObject.gameWon();
                  
                Debug.Log("This is a win for the far right column");


            }
            if (gridTiles3x3[2, 2].GetComponent<ticTacTileScript>().playerSide == gridTiles3x3[1, 2].GetComponent<ticTacTileScript>().playerSide
               && gridTiles3x3[1, 2].GetComponent<ticTacTileScript>().playerSide == gridTiles3x3[0, 2].GetComponent<ticTacTileScript>().playerSide
               && gridTiles3x3[2, 2].GetComponent<ticTacTileScript>().playerSide != Players.None
                   && gridTiles3x3[1, 2].GetComponent<ticTacTileScript>().playerSide != Players.None
                   && gridTiles3x3[0, 2].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {
                   winLossObject.gameWon();
                   
                Debug.Log("This is a win for bottom row straight across");
            }

            #endregion



            if (overallTurnNumber >= 9 && gameWon == false)
                winLossObject.gameTied();

        }

        else if (!isNormalGame)
        {
            #region tile[0,0]

            if (gridTiles4x4[0, 0].GetComponent<ticTacTileScript>().playerSide == gridTiles4x4[1, 0].GetComponent<ticTacTileScript>().playerSide
                && gridTiles4x4[1, 0].GetComponent<ticTacTileScript>().playerSide
                == gridTiles4x4[2, 0].GetComponent<ticTacTileScript>().playerSide
                && gridTiles4x4[2, 0].GetComponent<ticTacTileScript>().playerSide
                == gridTiles4x4[3, 0].GetComponent<ticTacTileScript>().playerSide

                && gridTiles4x4[0, 0].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[1, 0].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[2, 0].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[3, 0].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {
                winLossObject.gameWon();
                Debug.Log("This is a win for the top row straight across");
            }
            else if (gridTiles4x4[0, 0].GetComponent<ticTacTileScript>().playerSide == gridTiles4x4[0, 1].GetComponent<ticTacTileScript>().playerSide
                && gridTiles4x4[0, 1].GetComponent<ticTacTileScript>().playerSide
                == gridTiles4x4[0, 2].GetComponent<ticTacTileScript>().playerSide
                && gridTiles4x4[0, 2].GetComponent<ticTacTileScript>().playerSide
                == gridTiles4x4[0, 3].GetComponent<ticTacTileScript>().playerSide

                && gridTiles4x4[0, 0].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[0, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[0, 2].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[0, 3].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {
                winLossObject.gameWon();
                Debug.Log("This is a win for the leftmost column");
            }
            else if (gridTiles4x4[0, 0].GetComponent<ticTacTileScript>().playerSide == gridTiles4x4[1, 1].GetComponent<ticTacTileScript>().playerSide
                && gridTiles4x4[1, 1].GetComponent<ticTacTileScript>().playerSide
                == gridTiles4x4[2, 2].GetComponent<ticTacTileScript>().playerSide
                && gridTiles4x4[2, 2].GetComponent<ticTacTileScript>().playerSide
                == gridTiles4x4[3, 3].GetComponent<ticTacTileScript>().playerSide

                && gridTiles4x4[0, 0].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[1, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[2, 2].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[3, 3].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {
                winLossObject.gameWon();
                Debug.Log("This is a win for the diagonal from [0,0]");
            }

            #endregion

            #region tile[1,1]

            if (gridTiles4x4[1, 1].GetComponent<ticTacTileScript>().playerSide == gridTiles4x4[1, 0].GetComponent<ticTacTileScript>().playerSide
                && gridTiles4x4[1, 0].GetComponent<ticTacTileScript>().playerSide
                == gridTiles4x4[1, 2].GetComponent<ticTacTileScript>().playerSide
                && gridTiles4x4[1, 2].GetComponent<ticTacTileScript>().playerSide
                == gridTiles4x4[1, 3].GetComponent<ticTacTileScript>().playerSide

                && gridTiles4x4[1, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[1, 0].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[1, 2].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[1, 3].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {
                winLossObject.gameWon();
                Debug.Log("Win for the second column from the left");
            }
            else if (gridTiles4x4[1, 1].GetComponent<ticTacTileScript>().playerSide == gridTiles4x4[0, 1].GetComponent<ticTacTileScript>().playerSide
                && gridTiles4x4[0, 1].GetComponent<ticTacTileScript>().playerSide
                == gridTiles4x4[2, 1].GetComponent<ticTacTileScript>().playerSide
                && gridTiles4x4[2, 1].GetComponent<ticTacTileScript>().playerSide
                == gridTiles4x4[3, 1].GetComponent<ticTacTileScript>().playerSide

            && gridTiles4x4[1, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[0, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[2, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[3, 1].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {
                winLossObject.gameWon();
                Debug.Log("Win for the second row from the top");
            }
            #endregion

            #region tile[2,2]

            if (gridTiles4x4[2, 1].GetComponent<ticTacTileScript>().playerSide == gridTiles4x4[1, 2].GetComponent<ticTacTileScript>().playerSide
                && gridTiles4x4[1, 2].GetComponent<ticTacTileScript>().playerSide
                == gridTiles4x4[0, 2].GetComponent<ticTacTileScript>().playerSide
                && gridTiles4x4[0, 2].GetComponent<ticTacTileScript>().playerSide
                == gridTiles4x4[3, 2].GetComponent<ticTacTileScript>().playerSide

                   && gridTiles4x4[2, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[1, 2].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[0, 2].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[3, 2].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {
                winLossObject.gameWon();
                Debug.Log("Win for third row down");
            }
            else if (gridTiles4x4[2, 2].GetComponent<ticTacTileScript>().playerSide == gridTiles4x4[2, 1].GetComponent<ticTacTileScript>().playerSide
                && gridTiles4x4[2, 1].GetComponent<ticTacTileScript>().playerSide
                == gridTiles4x4[2, 0].GetComponent<ticTacTileScript>().playerSide
                && gridTiles4x4[2, 0].GetComponent<ticTacTileScript>().playerSide
                == gridTiles4x4[2, 3].GetComponent<ticTacTileScript>().playerSide

                   && gridTiles4x4[2, 2].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[2, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[2, 0].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[2, 3].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {
                winLossObject.gameWon();
                Debug.Log("Win for third column from left");
            }
            #endregion

            #region tile[3,3]

            if (gridTiles4x4[3, 3].GetComponent<ticTacTileScript>().playerSide == gridTiles4x4[2, 3].GetComponent<ticTacTileScript>().playerSide
                && gridTiles4x4[2, 3].GetComponent<ticTacTileScript>().playerSide
                == gridTiles4x4[1, 3].GetComponent<ticTacTileScript>().playerSide
                && gridTiles4x4[1, 3].GetComponent<ticTacTileScript>().playerSide
                == gridTiles4x4[0, 3].GetComponent<ticTacTileScript>().playerSide

               && gridTiles4x4[3, 3].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[2, 3].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[1, 3].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[0, 3].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {
                winLossObject.gameWon();
                Debug.Log("This is a win for the bottom row");
            }
            else if (gridTiles4x4[3, 3].GetComponent<ticTacTileScript>().playerSide == gridTiles4x4[3, 2].GetComponent<ticTacTileScript>().playerSide
                && gridTiles4x4[3, 2].GetComponent<ticTacTileScript>().playerSide
                == gridTiles4x4[3, 1].GetComponent<ticTacTileScript>().playerSide
                && gridTiles4x4[3, 1].GetComponent<ticTacTileScript>().playerSide
                == gridTiles4x4[3, 0].GetComponent<ticTacTileScript>().playerSide

                && gridTiles4x4[3, 3].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[3, 2].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[3, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[3, 0].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {
                winLossObject.gameWon();
                Debug.Log("This is a win for the far right column");
            }

            #endregion

            #region tile[3,0]
            else if (gridTiles4x4[3, 0].GetComponent<ticTacTileScript>().playerSide == gridTiles4x4[2, 1].GetComponent<ticTacTileScript>().playerSide
                && gridTiles4x4[2, 1].GetComponent<ticTacTileScript>().playerSide
                == gridTiles4x4[1, 2].GetComponent<ticTacTileScript>().playerSide
                && gridTiles4x4[1, 2].GetComponent<ticTacTileScript>().playerSide
                == gridTiles4x4[0, 3].GetComponent<ticTacTileScript>().playerSide

                    && gridTiles4x4[3, 0].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[2, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[1, 2].GetComponent<ticTacTileScript>().playerSide != Players.None
                && gridTiles4x4[0, 3].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {
                winLossObject.gameWon();
                Debug.Log("Win for the diagonal starting from [3,0]");
            }
            #endregion

			if (overallTurnNumber >= 16 && gameWon == false)
				winLossObject.gameTied();
        }

    }

    private void Update()
    {
        Debug.Log(overallTurnNumber);
        Debug.Log(gameWon);
       
    }

    private void OnDisable()
    {  
    }

    public Texture getHeartImage()
    {
        return heartImage;
    }
    public Texture getChipImage()
    {
        return chipImage;
    }







}
