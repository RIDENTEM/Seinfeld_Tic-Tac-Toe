using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class determineGameType : MonoBehaviour
{

    [SerializeField] private GameObject characterSelection;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameType;
    [SerializeField] private Texture jerryTexture;
    [SerializeField] private Texture georgeTexture;
    [SerializeField] private Texture elaineTexture;
    [SerializeField] private Texture kramerTexture;
    [SerializeField] private Texture newmanTexture;

    bool isPlayer1Ready = false;


    public void gameType3x3()
    {
        ticTacManager.isNormalGame = true;

        SceneManager.LoadScene("mainGame");
    }

    public void gameType4x4()
    {
        ticTacManager.isNormalGame = false;
        SceneManager.LoadScene("mainGame");

    }

    public void onPlayButtonHit()
    {
        mainMenu.SetActive(false);
        characterSelection.SetActive(true);
    }

    public void onCharacterSelectionDone()
    {

        characterSelection.SetActive(false);
        gameType.SetActive(true);

    }

    public void jerryHit()
    {
        Player newPlayer = new Player();
        newPlayer.playerCharacter = ticTacManager.Players.Jerry;
        newPlayer.playerTurnText = "It's Jerry's turn!";
        newPlayer.playerCharacterTexture = jerryTexture;

        if (newPlayer.isPlayer1)
            ticTacManager.player1 = newPlayer;
         else if (!newPlayer.isPlayer1)
            ticTacManager.player2 = newPlayer;
        
        

    }

    public void georgeHit()
    {
        Player newPlayer = new Player();
        newPlayer.playerCharacter = ticTacManager.Players.George;
        newPlayer.playerTurnText = "It's George's turn!";
        newPlayer.playerCharacterTexture = georgeTexture;

        if (newPlayer.isPlayer1)
        {
            ticTacManager.player1 = newPlayer;
        }
        else if(!newPlayer.isPlayer1)
            ticTacManager.player2 = newPlayer;
    }
    public void elaineHit()
    {
        Player newPlayer = new Player();
        newPlayer.playerCharacter = ticTacManager.Players.Elaine;
        newPlayer.playerTurnText = "It's Elaine's turn!";
        newPlayer.playerCharacterTexture = elaineTexture;

        if (newPlayer.isPlayer1)
        {
            ticTacManager.player1 = newPlayer;
        }
        else if (!newPlayer.isPlayer1)
            ticTacManager.player2 = newPlayer;
    }
    public void kramerHit()
    {
        Player newPlayer = new Player();
        newPlayer.playerCharacter = ticTacManager.Players.Kramer;
        newPlayer.playerTurnText = "It's Kramer's turn!";
        newPlayer.playerCharacterTexture = kramerTexture;

        if (newPlayer.isPlayer1)
        {
            ticTacManager.player1 = newPlayer;
        }
        else if (!newPlayer.isPlayer1)
            ticTacManager.player2 = newPlayer;
    }
    public void newmanHit()
    {
        Player newPlayer = new Player();
        newPlayer.playerCharacter = ticTacManager.Players.Newman;
        newPlayer.playerTurnText = "It's Newman's turn!";
        newPlayer.playerCharacterTexture = newmanTexture;

        if (newPlayer.isPlayer1)
        {
            ticTacManager.player1 = newPlayer;
        }
        else if (!newPlayer.isPlayer1)
            ticTacManager.player2 = newPlayer;
    }
}
