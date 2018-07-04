using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [SerializeField] private AudioClip jerryIntroClip;
    [SerializeField] private AudioClip georgeIntroClip;
    [SerializeField] private AudioClip elaineIntroClip;
    [SerializeField] private AudioClip kramerIntroClip;
    [SerializeField] private AudioClip newmanIntroClip;

    [SerializeField] private Text playerChooseText;
    [SerializeField] private GameObject[] playerSelectionButtons;
    [SerializeField] private GameObject doneButton;

    bool isPlayer1Ready = false;
    bool isPlayer2Ready = false;


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
        newPlayer.playerIntro = jerryIntroClip;

        if (isPlayer1Ready == false)
        {
            Debug.Log("Player 1 has selected Jerry.");

            newPlayer.isPlayer1 = true;
            isPlayer1Ready = true;
            ticTacManager.player1 = newPlayer;
        }
        else if (isPlayer1Ready == true)
        {
            Debug.Log("Player 2 has selected Jerry.");

            newPlayer.isPlayer1 = false;
            ticTacManager.player2 = newPlayer;
            isPlayer2Ready = true;
        }


    }
    public void georgeHit()
    {
        Player newPlayer = new Player();
        newPlayer.playerCharacter = ticTacManager.Players.George;
        newPlayer.playerTurnText = "It's George's turn!";
        newPlayer.playerCharacterTexture = georgeTexture;
        newPlayer.playerIntro = georgeIntroClip;

        if (isPlayer1Ready == false)
        {
            Debug.Log("Player 1 has selected George.");

            isPlayer1Ready = true;
            newPlayer.isPlayer1 = true;
            ticTacManager.player1 = newPlayer;
        }
        else if (isPlayer1Ready == true)
        {
            Debug.Log("Player 2 has selected George.");

            newPlayer.isPlayer1 = false;
            ticTacManager.player2 = newPlayer;
            isPlayer2Ready = true;

        }
    }
    public void elaineHit()
    {
        Player newPlayer = new Player();
        newPlayer.playerCharacter = ticTacManager.Players.Elaine;
        newPlayer.playerTurnText = "It's Elaine's turn!";
        newPlayer.playerCharacterTexture = elaineTexture;
        newPlayer.playerIntro = elaineIntroClip;
        if (isPlayer1Ready == false)
        {
            Debug.Log("Player 1 has selected Elaine.");

            isPlayer1Ready = true;
            newPlayer.isPlayer1 = true;
            ticTacManager.player1 = newPlayer;
        }
        else if (isPlayer1Ready == true)
        {
            Debug.Log("Player 2 has selected Elaine.");

            newPlayer.isPlayer1 = false;
            ticTacManager.player2 = newPlayer;
            isPlayer2Ready = true;

        }
    }
    public void kramerHit()
    {
        Player newPlayer = new Player();
        newPlayer.playerCharacter = ticTacManager.Players.Kramer;
        newPlayer.playerTurnText = "It's Kramer's turn!";
        newPlayer.playerCharacterTexture = kramerTexture;
        newPlayer.playerIntro = kramerIntroClip;

        if (isPlayer1Ready == false)
        {
            Debug.Log("Player 1 has selected Kramer.");

            isPlayer1Ready = true;
            newPlayer.isPlayer1 = true;
            ticTacManager.player1 = newPlayer;
        }
        else if (isPlayer1Ready == true)
        {
            Debug.Log("Player 2 has selected Kramer.");

            newPlayer.isPlayer1 = false;
            ticTacManager.player2 = newPlayer;
            isPlayer2Ready = true;

        }
    }
    public void newmanHit()
    {
        Player newPlayer = new Player();
        newPlayer.playerCharacter = ticTacManager.Players.Newman;
        newPlayer.playerTurnText = "It's Newman's turn!";
        newPlayer.playerCharacterTexture = newmanTexture;
        newPlayer.playerIntro = newmanIntroClip;

        if (isPlayer1Ready == false)
        {
            Debug.Log("Player 1 has selected Newman.");

            isPlayer1Ready = true;
            newPlayer.isPlayer1 = true;
            ticTacManager.player1 = newPlayer;
        }
        else if (isPlayer1Ready == true)
        {
            Debug.Log("Player 2 has selected Newman.");

            newPlayer.isPlayer1 = false;
            ticTacManager.player2 = newPlayer;
            isPlayer2Ready = true;

        }
    }

    private void Update()
    {
        if (doneButton)
        {

            if (isPlayer1Ready == true)
            {
                playerChooseText.text = "Player 2 choose character";
            }
            else
                doneButton.SetActive(false);

            if (isPlayer2Ready == true)
            {
                for (int i = 0; i < playerSelectionButtons.Length; i++)
                {
                    playerSelectionButtons[i].SetActive(false);

                }
                playerChooseText.gameObject.SetActive(false);
                doneButton.SetActive(true);
            }
        }
     }
}
