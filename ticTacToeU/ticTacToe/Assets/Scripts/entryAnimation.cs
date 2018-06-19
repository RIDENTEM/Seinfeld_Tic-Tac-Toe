using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
public class entryAnimation : MonoBehaviour
{


    [SerializeField] private GameObject playerImage;

    Vector3 player2Pos = new Vector3(250.0f, 0.0f, 0.0f);

    Color totallyClear = new Color(255.0f, 255.0f, 255.0f, 0.0f);
    Color totallyFull = new Color(255.0f, 255.0f, 255.0f, 255.0f);

    void Start()
    {
        GameObject player2Image = Instantiate(playerImage, player2Pos, Quaternion.identity);

        playerImage.GetComponent<Material>().mainTexture = ticTacManager.player1.playerCharacterTexture;
        player2Image.GetComponent<Material>().mainTexture = ticTacManager.player2.playerCharacterTexture;

        playerImage.GetComponent<Material>().color = totallyClear;
        player2Image.GetComponent<Material>().color = totallyClear;

        

    }

    void lerpAlphaToFull()
    {
        Color lerpedColor = totallyClear;
        lerpedColor.a = Mathf.Lerp(lerpedColor.a, 1.0f, 3.0f * Time.deltaTime);
        playerImage.GetComponent<Material>().color = lerpedColor;

    }

    void lerpAlphaToClear()
    {
        Color lerpedColor = totallyFull;
        lerpedColor.a = Mathf.Lerp(lerpedColor.a, 0.0f, 3.0f * Time.deltaTime);
        playerImage.GetComponent<Material>().color = lerpedColor;



    }

    // Update is called once per frame
    void Update()
    {
        lerpAlphaToFull();
    }
}
