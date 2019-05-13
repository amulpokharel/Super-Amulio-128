using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleToGame : MonoBehaviour
{
    public Text startGame;
    public Text endGame;
    public AudioClip selectSfx;
    public AudioClip selectedSfx;
    public int totalLives;

    private bool started;
    private int option;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        option = 0;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return") && !started)
        {
            if(option == 0)
            {
                audioSource.PlayOneShot(selectedSfx);
                started = true;
                PlayerMove.currentLives = totalLives;
                PlayerMove.levelName = "Level 1";
                PlayerMove.totalCoins = 0;
                SceneManager.LoadScene("StoryPart1");
            }
            else if(option == 1)
            {
                audioSource.PlayOneShot(selectedSfx);
                //UnityEditor.EditorApplication.isPlaying = false;
                Application.Quit();
            }

        }
        else if(Input.GetKeyDown("down") && !started)
        {
            if(option == 0)
            {
                option = 1;
                endGame.text = "> EXIT <";
                startGame.text = "START GAME";
                startGame.color = Color.black;
                endGame.color = Color.white;
                audioSource.PlayOneShot(selectSfx);
            }
        }
        else if (Input.GetKeyDown("up") && !started)
        {
            if (option == 1)
            {
                option = 0;
                endGame.text = "EXIT";
                startGame.text = "> START GAME <";
                startGame.color = Color.white;
                endGame.color = Color.black;
                audioSource.PlayOneShot(selectSfx);
            }
        }


    }
}
