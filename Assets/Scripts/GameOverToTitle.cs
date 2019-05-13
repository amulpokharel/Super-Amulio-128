using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverToTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            PlayerMove.totalCoins = 0;
            PlayerMove.currentLives = 3;
            PlayerMove.levelName = "Level 1";
            SceneManager.LoadScene("LevelTransitionScreen");
        }
    }
}
