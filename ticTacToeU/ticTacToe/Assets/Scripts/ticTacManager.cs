using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ticTacManager : MonoBehaviour
{
    public delegate void onGameStartup();
    public static event onGameStartup startupDel;


    public static bool isNormalGame;
    static public int overallTurnNumber = 1;

    private GameObject[,] gridTiles3x3 = new GameObject[3, 3];
    private GameObject[,] gridTiles4x4 = new GameObject[4, 4];

    class PlayerMoves
    {
       public Players savedPlayer;
       public  int[,] tileHit;
        private int turnNumber = overallTurnNumber;
    }


    public enum Players { Heart, Chip, None };
    public static Players currentPlayer;

    [SerializeField] private GameObject panel3x3;
    [SerializeField] private GameObject panel4x4;
    public Button[] gridButtons3x3;
    [SerializeField] List<Button> gridButtons4x4;
    [SerializeField] private Texture heartImage;
    [SerializeField] private Texture chipImage;
    [SerializeField] private Texture defaultImage;

    private List<PlayerMoves> playerMovesToSave;

    private void Awake()
    {
        playerMovesToSave = new List<PlayerMoves>();
        playerMovesToSave.Capacity = 3;
        currentPlayer = Players.Heart;
        startupDel += populateTilesArray;
        startupDel += typeOfGrid;
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


    void debugger()
    {
        Debug.LogFormat(currentPlayer.ToString());
    }

    void populateTilesArray()
    {
        if (isNormalGame)
        {
            for (int i = 0; i < 9; i++)
            {
                gridButtons3x3[i].GetComponent<RawImage>().texture = defaultImage;
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
            for (int i = 0; i < 15; i++)
            {
                gridButtons4x4[i].GetComponent<RawImage>().texture = defaultImage;
            }
            int gridButtonCounter4x4 = 0;
            //use the 4x4
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    gridTiles4x4[i, j] = gridButtons4x4[gridButtonCounter4x4].gameObject;
                    gridButtonCounter4x4++;
                }
            }
        }



    }
    

   public void storeMoves(int tileIndex)
    {
        PlayerMoves newPlayerMove = new PlayerMoves();
        newPlayerMove.savedPlayer = currentPlayer;
        switch(tileIndex)
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
        
        playerMovesToSave.Add(newPlayerMove);
    }

    public void checkForWin()
    {
        if (isNormalGame)
        {
            //I put minus signs instead of just the exact space of the tile to show that I am basing these off of the three points from the notebook 
            #region tile[0,0]
            
                //Possible win situations for tile [0,0]
                if (gridTiles3x3[0, 0].GetComponent<ticTacTileScript>().playerSide ==
                    gridTiles3x3[1, 0].GetComponent<ticTacTileScript>().playerSide 
                    &&  gridTiles3x3[1, 0].GetComponent<ticTacTileScript>().playerSide 
                    == gridTiles3x3[2, 0].GetComponent<ticTacTileScript>().playerSide

                    && gridTiles3x3[0, 0].GetComponent<ticTacTileScript>().playerSide != Players.None
                    && gridTiles3x3[1, 0].GetComponent<ticTacTileScript>().playerSide != Players.None
                    && gridTiles3x3[2, 0].GetComponent<ticTacTileScript>().playerSide != Players.None)
                {
                    Debug.Log(gridTiles3x3[0, 0].GetComponent<ticTacTileScript>().playerSide);
                    Debug.Log(gridTiles3x3[1, 0].GetComponent<ticTacTileScript>().playerSide);
                    Debug.Log(gridTiles3x3[2, 0].GetComponent<ticTacTileScript>().playerSide);



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
                Debug.Log("This is a win for the left column");
            }
            if (gridTiles3x3[0, 0].GetComponent<ticTacTileScript>().playerSide ==  
                 gridTiles3x3[1, 1].GetComponent<ticTacTileScript>().playerSide 
               && gridTiles3x3[1,1].GetComponent<ticTacTileScript>().playerSide ==
               gridTiles3x3[2, 2].GetComponent<ticTacTileScript>().playerSide 

                   && gridTiles3x3[0,0].GetComponent<ticTacTileScript>().playerSide != Players.None
                   && gridTiles3x3[1,1].GetComponent<ticTacTileScript>().playerSide != Players.None
                  && gridTiles3x3[2,2].GetComponent<ticTacTileScript>().playerSide != Players.None)
                {
                //all textures returning null
                Debug.Log("This is a win for diagonal from tile [0,0]");
            }
            #endregion

            #region tile[1,1]
            if (gridTiles3x3[1, 1].GetComponent<ticTacTileScript>().playerSide == gridTiles3x3[0, 1].GetComponent<ticTacTileScript>().playerSide && gridTiles3x3[0, 1].GetComponent<ticTacTileScript>().playerSide == gridTiles3x3[2, 1].GetComponent<ticTacTileScript>().playerSide
                      && gridTiles3x3[1, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                    && gridTiles3x3[0, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                    && gridTiles3x3[2, 1].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {
                Debug.Log("This is a win for the middle row straight across");
            }
            else if (gridTiles3x3[1, 1].GetComponent<ticTacTileScript>().playerSide == gridTiles3x3[1, 0].GetComponent<ticTacTileScript>().playerSide && gridTiles3x3[1, 0].GetComponent<ticTacTileScript>().playerSide == gridTiles3x3[1, 2].GetComponent<ticTacTileScript>().playerSide
                && gridTiles3x3[1, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                    && gridTiles3x3[1, 0].GetComponent<ticTacTileScript>().playerSide != Players.None
                    && gridTiles3x3[1, 2].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {
                Debug.Log("This is a win for middle column");
            }
            else if (gridTiles3x3[1, 1].GetComponent<ticTacTileScript>().playerSide == gridTiles3x3[0, 2].GetComponent<ticTacTileScript>().playerSide && gridTiles3x3[0, 2].GetComponent<ticTacTileScript>().playerSide == gridTiles3x3[2, 0].GetComponent<ticTacTileScript>().playerSide
                && gridTiles3x3[1, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                    && gridTiles3x3[0, 2].GetComponent<ticTacTileScript>().playerSide != Players.None
                    && gridTiles3x3[2, 0].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {
                Debug.Log("This is a win for diagonal from [0,2]");
            }

            #endregion

            #region tile[2,2]

            if (gridTiles3x3[2, 2].GetComponent<ticTacTileScript>().playerSide == gridTiles3x3[2, 1].GetComponent<ticTacTileScript>().playerSide && gridTiles3x3[2, 1].GetComponent<ticTacTileScript>().playerSide == gridTiles3x3[2, 0].GetComponent<ticTacTileScript>().playerSide
               && gridTiles3x3[2, 2].GetComponent<ticTacTileScript>().playerSide != Players.None
                    && gridTiles3x3[2, 1].GetComponent<ticTacTileScript>().playerSide != Players.None
                    && gridTiles3x3[2, 0].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {
                Debug.Log("This is a win for the far right column");
                Debug.Log(gridTiles3x3[2, 2].ToString());
                Debug.Log(gridTiles3x3[2, 1].ToString());
                Debug.Log(gridTiles3x3[2, 0].ToString());

            }
            else if (gridTiles3x3[2, 2].GetComponent<ticTacTileScript>().playerSide == gridTiles3x3[1, 2].GetComponent<ticTacTileScript>().playerSide && gridTiles3x3[1, 2].GetComponent<ticTacTileScript>().playerSide == gridTiles3x3[0, 2].GetComponent<ticTacTileScript>().playerSide
                && gridTiles3x3[2, 2].GetComponent<ticTacTileScript>().playerSide != Players.None
                    && gridTiles3x3[1, 2].GetComponent<ticTacTileScript>().playerSide != Players.None
                    && gridTiles3x3[0, 2].GetComponent<ticTacTileScript>().playerSide != Players.None)
            {
                Debug.Log("This is a win for bottom row straight across");
            }

            #endregion

        }
#if false
        else if (!isNormalGame)
        {
        #region tile[0,0]

            if (gridTiles4x4[0, 0].GetComponent<Texture>() == gridTiles4x4[0 + 1, 0].GetComponent<Texture>() == gridTiles4x4[0 + 2, 0].GetComponent<Texture>() == gridTiles4x4[0 + 3, 0].GetComponent<Texture>()
                && gridTiles4x4[0, 0].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[1, 0].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[2, 0].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[3, 0].GetComponent<Texture>() != defaultImage)
            {
                Debug.Log("This is a win for the top row straight across");
            }
            else if (gridTiles4x4[0, 0].GetComponent<Texture>() == gridTiles4x4[0, 0 + 1].GetComponent<Texture>() == gridTiles4x4[0, 0 + 2].GetComponent<Texture>() == gridTiles4x4[0, 0 + 3].GetComponent<Texture>()
                 && gridTiles4x4[0, 0].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[0, 1].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[0, 2].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[0, 3].GetComponent<Texture>() != defaultImage)
            {
                Debug.Log("This is a win for the leftmost column");
            }
            else if (gridTiles4x4[0, 0].GetComponent<Texture>() == gridTiles4x4[0 + 1, 0 + 1].GetComponent<Texture>() == gridTiles4x4[0 + 2, 0 + 2].GetComponent<Texture>() == gridTiles4x4[0 + 3, 0 + 3].GetComponent<Texture>()
                && gridTiles4x4[0, 0].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[1, 1].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[2, 2].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[3, 3].GetComponent<Texture>() != defaultImage)
            {
                Debug.Log("This is a win for the diagonal from [0,0]");
            }

        #endregion

        #region tile[1,1]

            if (gridTiles4x4[1, 1].GetComponent<Texture>() == gridTiles4x4[1, 1 - 1].GetComponent<Texture>() == gridTiles4x4[1, 1 + 1].GetComponent<Texture>() == gridTiles4x4[1, 1 + 2].GetComponent<Texture>()
                && gridTiles4x4[1, 1].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[1, 0].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[1, 2].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[1, 3].GetComponent<Texture>() != defaultImage)
            {
                Debug.Log("Win for the second column from the left");
            }
            else if (gridTiles4x4[1, 1].GetComponent<Texture>() == gridTiles4x4[1 - 1, 1].GetComponent<Texture>() == gridTiles4x4[1 + 1, 1].GetComponent<Texture>() == gridTiles4x4[1 + 2, 1].GetComponent<Texture>()
                && gridTiles4x4[1, 1].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[0, 1].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[2, 1].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[3, 1].GetComponent<Texture>() != defaultImage)
            {
                Debug.Log("Win for the second row from the top");
            }
        #endregion

        #region tile[2,2]

            if (gridTiles4x4[2, 2].GetComponent<Texture>() == gridTiles4x4[2 - 1, 2].GetComponent<Texture>() == gridTiles4x4[2 - 2, 2].GetComponent<Texture>() == gridTiles4x4[2 + 1, 2].GetComponent<Texture>()
                   && gridTiles4x4[2, 2].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[1, 2].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[0, 2].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[3, 2].GetComponent<Texture>() != defaultImage)
            {
                Debug.Log("Win for third row down");
            }
            else if (gridTiles4x4[2, 2].GetComponent<Texture>() == gridTiles4x4[2, 2 - 1].GetComponent<Texture>() == gridTiles4x4[2, 2 - 2].GetComponent<Texture>() == gridTiles4x4[2, 2 + 1].GetComponent<Texture>()
                && gridTiles4x4[2, 2].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[2, 1].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[2, 0].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[2, 3].GetComponent<Texture>() != defaultImage)
            {
                Debug.Log("Win for third column from left");
            }
        #endregion

        #region tile[3,3]

            if (gridTiles4x4[3, 3].GetComponent<Texture>() == gridTiles4x4[3 - 1, 3].GetComponent<Texture>() == gridTiles4x4[3 - 2, 3].GetComponent<Texture>() == gridTiles4x4[3 - 3, 3].GetComponent<Texture>()
                && gridTiles4x4[3, 3].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[2, 3].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[1, 3].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[0, 3].GetComponent<Texture>() != defaultImage)
            {
                Debug.Log("This is a win for the bottom row");
            }
            else if (gridTiles4x4[3, 3].GetComponent<Texture>() == gridTiles4x4[3, 3 - 1].GetComponent<Texture>() == gridTiles4x4[3, 3 - 2].GetComponent<Texture>() == gridTiles4x4[3, 3 - 3].GetComponent<Texture>()
                   && gridTiles4x4[3, 3].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[3, 2].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[3, 1].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[3, 0].GetComponent<Texture>() != defaultImage)
            {
                Debug.Log("This is a win for the far right column");
            }

        #endregion

        #region tile[3,0]
            else if (gridTiles4x4[3, 0].GetComponent<Texture>() == gridTiles4x4[3 - 1, 1].GetComponent<Texture>() == gridTiles4x4[3 - 2, 2].GetComponent<Texture>() == gridTiles4x4[3 - 3, 3].GetComponent<Texture>()
                   && gridTiles4x4[3, 0].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[2, 1].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[1, 2].GetComponent<Texture>() != defaultImage
                && gridTiles4x4[0, 3].GetComponent<Texture>() != defaultImage)
            {
                Debug.Log("Win for the diagonal starting from [3,0]");
            }
        #endregion

        }
#endif
    }

    private void OnDisable()
    {
        startupDel -= populateTilesArray;
        startupDel -= checkForWin;
        startupDel -= typeOfGrid;
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
