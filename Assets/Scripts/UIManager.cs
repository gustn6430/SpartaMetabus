using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI backText;

    // Start is called before the first frame update
    void Start()
    {
        if (restartText == null)
            Debug.Log("restart text is null");

        if (scoreText == null)
            Debug.Log("score text is null");

        restartText.gameObject.SetActive(false);
        backText.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
    }

    public void SetBack()
    {
        backText.gameObject.SetActive(true);
    }
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
