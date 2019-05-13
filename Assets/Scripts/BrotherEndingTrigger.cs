using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BrotherEndingTrigger : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            PlayerMove.levelName = "Ending";
            SceneManager.LoadScene("Ending");
        }
    }
}
