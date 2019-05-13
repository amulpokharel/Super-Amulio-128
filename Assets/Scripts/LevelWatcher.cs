using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelWatcher : MonoBehaviour
{
    public Text levelText;

    // Start is called before the first frame update
    void Start()
    {
        levelText.text = PlayerMove.levelName;
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = PlayerMove.levelName;
    }
}
