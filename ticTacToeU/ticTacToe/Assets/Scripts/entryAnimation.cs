using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
public class entryAnimation : MonoBehaviour
{


    [SerializeField] private RawImage playerImage;
    [SerializeField] private RawImage player2Image;
    private Animation player1Anim;
     private Animation player2Anim;

    

    void Start()
    {
        player1Anim.Play();
        player2Anim.Play();


        //   player1Animator.


    }

    // Update is called once per frame
    void Update()
    {

    }
}
