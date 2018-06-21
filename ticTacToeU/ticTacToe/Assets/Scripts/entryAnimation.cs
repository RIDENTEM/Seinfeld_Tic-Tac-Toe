using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
public class entryAnimation : MonoBehaviour
{


    [SerializeField] private RawImage playerImage;
    [SerializeField] private RawImage player2Image;
    bool fadeInDone = false;
    [SerializeField] private float duration = 3.0f;
    private float elapsedTime = 0.0f;
    Vector3 player2Pos = new Vector3(250.0f, 0.0f, 0.0f);

    Color totallyClear = new Color(255.0f, 255.0f, 255.0f, 0.0f);
    Color totallyFull = new Color(255.0f, 255.0f, 255.0f, 255.0f);

    void Start()
    {

        playerImage.texture = ticTacManager.player1.playerCharacterTexture;
        player2Image.texture = ticTacManager.player2.playerCharacterTexture;

        playerImage.color = totallyClear;
        player2Image.color = totallyClear;



    }

    void lerpAlphaToFull()
    {

        if (elapsedTime < 1)
        {
            Color lerpedColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            elapsedTime += Time.deltaTime / duration;
            lerpedColor.a = Mathf.Lerp(lerpedColor.a, 1.0f, elapsedTime);
            playerImage.color = lerpedColor;
            player2Image.color = lerpedColor;
        }
        if (elapsedTime >= 1)
            fadeInDone = true;

    }

    void lerpAlphaToClear()
    {

        Color lerpedColor = totallyFull;
        lerpedColor.a = Mathf.Lerp(lerpedColor.a, 0.0f, 3.0f * Time.deltaTime);
        playerImage.color = lerpedColor;



    }

    // Update is called once per frame
    void Update()
    {
        lerpAlphaToFull();
        if (fadeInDone == true)
            lerpAlphaToClear();
    }
}
