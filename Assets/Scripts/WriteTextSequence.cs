using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class WriteTextSequence : MonoBehaviour
{
    public Text textField;
    public float pauseBetweenChars = 0.1f;
    public string nextScene;

    private string stringToWrite;

    void Start()
    {
        textField = GetComponent<Text>();

        stringToWrite = textField.text;
        textField.text = "";
        StartCoroutine(SequenceType());
    }

    IEnumerator SequenceType()
    {
        foreach (char letter in stringToWrite.ToCharArray())
        {
            textField.text += letter;
            yield return 0;            
            yield return new WaitForSecondsRealtime(pauseBetweenChars);
        }

        yield return 0;
        yield return new WaitForSecondsRealtime(2F);

        SceneManager.LoadScene(nextScene);

    }
}
