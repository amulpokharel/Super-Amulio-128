using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelTransitionListener : MonoBehaviour
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
            GameObject.FindGameObjectWithTag("Music").GetComponent<MainMusic>().StopMusic();
            SceneManager.LoadScene(PlayerMove.levelName);
        }
    }
}
