using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinWatcher : MonoBehaviour
{
    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = PlayerMove.totalCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = PlayerMove.totalCoins.ToString();
    }
}
