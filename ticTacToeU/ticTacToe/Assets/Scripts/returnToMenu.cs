﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class returnToMenu : MonoBehaviour {

	
    public void returnToMainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }


}
