using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingToTitle : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            PlayerMove.totalCoins = 0;
            PlayerMove.currentLives = 3;
            PlayerMove.levelName = "Level 1";
            SceneManager.LoadScene("TitleScreen");
        }
    }
}
