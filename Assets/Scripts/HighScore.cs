using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI highScore;

    public static int score = 0;

    private void Start()
    {
        score = 0;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();
        highScore.text = score.ToString();
    }
}
