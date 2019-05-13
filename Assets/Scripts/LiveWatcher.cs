using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiveWatcher : MonoBehaviour
{
    public Text liveText;

    // Start is called before the first frame update
    void Start()
    {
        liveText.text = PlayerMove.currentLives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        liveText.text = PlayerMove.currentLives.ToString();
    }
}
