using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ticTacTileScript : MonoBehaviour
{

    private RawImage thisButtonImage;
    private bool tileClicked;
    private ticTacManager gameManager;
    private characterSounds characterSoundObject;
    public ticTacManager.Players playerSide;
    private Animator thisTileAnimator;
    private void Start()
    {
        thisTileAnimator = GetComponent<Animator>();
        gameManager = FindObjectOfType<ticTacManager>();
        characterSoundObject = FindObjectOfType<characterSounds>();
        thisButtonImage = GetComponent<RawImage>();
        tileClicked = false;
        playerSide = ticTacManager.Players.None;
    }

    public ticTacManager.Players getPlayerType()
    {
        return playerSide;
    }

    public void onTileClicked()
    {
        Debug.LogFormat(ticTacManager.currentPlayer.ToString());
        //thisTileAnimator.SetBool("clicked", true);

        if (!tileClicked)
        {
            characterSoundObject.playCharacterSound(ticTacManager.currentPlayer.playerCharacter);
            //Play in/out animation to make it look nice
            thisTileAnimator.Play("clickAnimation");
            //if its player hearts turn and they press a tile
            //function to store moves whenever a tile is hit, also finds the index of the current tile in the tiles array
            if (ticTacManager.isNormalGame)
                gameManager.storeMoves(System.Array.IndexOf(gameManager.gridButtons3x3, gameObject.GetComponent<Button>()));
            else if (!ticTacManager.isNormalGame)
                gameManager.storeMoves(System.Array.IndexOf(gameManager.gridButtons4x4, gameObject.GetComponent<Button>()));

            switch (ticTacManager.currentPlayer.playerCharacter)
            {
                case ticTacManager.Players.Jerry:
                    {
                        //this needs to be earlier to let the win script know that the tile has been changed
                        playerSide = ticTacManager.Players.Jerry;

                        //set the image of that tile to a heart 
                        if (gameManager)
                            thisButtonImage.texture = ticTacManager.currentPlayer.playerCharacterTexture;
                        //check for win here instead whenever a spot is clicked 
                        if (ticTacManager.isNormalGame)
                            gameManager.genericWinCheck(3);
                        else
                            gameManager.genericWinCheck(4);
                        //set the current player to whoevers turn it is
                        if (ticTacManager.currentPlayer.isPlayer1)
                            ticTacManager.currentPlayer = ticTacManager.player2;
                        else if (!ticTacManager.currentPlayer.isPlayer1)
                            ticTacManager.currentPlayer = ticTacManager.player1;
                        //After the check for win, let the player know whose turn it is
                        gameManager.displayPlayerTurn(ticTacManager.currentPlayer);
                        break;
                    }
                case ticTacManager.Players.George:
                    {
                        playerSide = ticTacManager.Players.George;

                        //set the image of that tile to a heart 
                        if (gameManager)
                            thisButtonImage.texture = ticTacManager.currentPlayer.playerCharacterTexture;
                        //check for win here instead whenever a spot is clicked 
                        if (ticTacManager.isNormalGame)
                            gameManager.genericWinCheck(3);
                        else
                            gameManager.genericWinCheck(4);
                        //set the current player to whoevers turn it is
                        if (ticTacManager.currentPlayer.isPlayer1)
                            ticTacManager.currentPlayer = ticTacManager.player2;
                        else if (!ticTacManager.currentPlayer.isPlayer1)
                            ticTacManager.currentPlayer = ticTacManager.player1;
                        //After the check for win, let the player know whose turn it is
                        gameManager.displayPlayerTurn(ticTacManager.currentPlayer);
                        break;
                    }
                case ticTacManager.Players.Elaine:
                    {
                        playerSide = ticTacManager.Players.Elaine;

                        //set the image of that tile to a heart 
                        if (gameManager)
                            thisButtonImage.texture = ticTacManager.currentPlayer.playerCharacterTexture;
                        //check for win here instead whenever a spot is clicked 
                        if (ticTacManager.isNormalGame)
                            gameManager.genericWinCheck(3);
                        else
                            gameManager.genericWinCheck(4);
                        //set the current player to whoevers turn it is
                        if (ticTacManager.currentPlayer.isPlayer1)
                            ticTacManager.currentPlayer = ticTacManager.player2;
                        else if (!ticTacManager.currentPlayer.isPlayer1)
                            ticTacManager.currentPlayer = ticTacManager.player1;
                        //After the check for win, let the player know whose turn it is
                        gameManager.displayPlayerTurn(ticTacManager.currentPlayer);
                        break;
                    }

                case ticTacManager.Players.Kramer:
                    {
                        playerSide = ticTacManager.Players.Kramer;

                        //set the image of that tile to a heart 
                        if (gameManager)
                            thisButtonImage.texture = ticTacManager.currentPlayer.playerCharacterTexture;
                        //check for win here instead whenever a spot is clicked 
                        if (ticTacManager.isNormalGame)
                            gameManager.genericWinCheck(3);
                        else
                            gameManager.genericWinCheck(4);

                        //set the current player to whoevers turn it is
                        if (ticTacManager.currentPlayer.isPlayer1)
                            ticTacManager.currentPlayer = ticTacManager.player2;
                        else if (!ticTacManager.currentPlayer.isPlayer1)
                            ticTacManager.currentPlayer = ticTacManager.player1;
                        //After the check for win, let the player know whose turn it is
                        gameManager.displayPlayerTurn(ticTacManager.currentPlayer);

                        break;
                    }

                case ticTacManager.Players.Newman:
                    {
                        playerSide = ticTacManager.Players.Newman;

                        //set the image of that tile to a heart 
                        if (gameManager)
                            thisButtonImage.texture = ticTacManager.currentPlayer.playerCharacterTexture;
                        //check for win here instead whenever a spot is clicked 
                        if (ticTacManager.isNormalGame)
                            gameManager.genericWinCheck(3);
                        else
                            gameManager.genericWinCheck(4);

                        //set the current player to whoevers turn it is
                        if (ticTacManager.currentPlayer.isPlayer1)
                            ticTacManager.currentPlayer = ticTacManager.player2;
                        else if (!ticTacManager.currentPlayer.isPlayer1)
                            ticTacManager.currentPlayer = ticTacManager.player1;
                        //After the check for win, let the player know whose turn it is
                        gameManager.displayPlayerTurn(ticTacManager.currentPlayer);

                        break;
                    }
            }


            tileClicked = true;
            ticTacManager.overallTurnNumber++;
        }
        else
        {
            //play some in/out animation make it look nice
            thisTileAnimator.Play("activeTilePressAnimation");
        }


    }


}
