using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class determineGameType : MonoBehaviour {


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


}
