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
        ticTacManager.Player newPlayer = new ticTacManager.Player();
        newPlayer.playerCharacter = ticTacManager.Players.Jerry;
        newPlayer.playerTurnText.text = "It's Jerry's turn!";
        newPlayer.playerCharacterTexture = jerryTexture;

        if (newPlayer.isPlayer1)
            ticTacManager.player1 = newPlayer;
         else if (!newPlayer.isPlayer1)
            ticTacManager.player2 = newPlayer;
        
        

    }

    public void georgeHit()
    {
        ticTacManager.Player newPlayer = new ticTacManager.Player();
        newPlayer.playerCharacter = ticTacManager.Players.George;
        newPlayer.playerTurnText.text = "It's George's turn!";
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
        ticTacManager.Player newPlayer = new ticTacManager.Player();
        newPlayer.playerCharacter = ticTacManager.Players.Elaine;
        newPlayer.playerTurnText.text = "It's Elaine's turn!";
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
        ticTacManager.Player newPlayer = new ticTacManager.Player();
        newPlayer.playerCharacter = ticTacManager.Players.Kramer;
        newPlayer.playerTurnText.text = "It's Kramer's turn!";
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
        ticTacManager.Player newPlayer = new ticTacManager.Player();
        newPlayer.playerCharacter = ticTacManager.Players.Newman;
        newPlayer.playerTurnText.text = "It's Newman's turn!";
        newPlayer.playerCharacterTexture = newmanTexture;

        if (newPlayer.isPlayer1)
        {
            ticTacManager.player1 = newPlayer;
        }
        else if (!newPlayer.isPlayer1)
            ticTacManager.player2 = newPlayer;
    }
}
