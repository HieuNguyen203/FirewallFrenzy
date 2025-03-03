using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
struct ScoreTrophy
{
    public int score;
    public Sprite trophy; 
}

public class HighestScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highestScore;
    [SerializeField] ScoreTrophy[] trophy;
    [SerializeField] Image image; 

    private int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = PlayerPrefs.GetInt("HighestScore");
        highestScore.text = currentScore.ToString();
        for(int i = 1; i < trophy.Length; i++)
        {
            if (trophy[i].score < currentScore)
            {
                continue;
            }
            image.sprite = trophy[i - 1].trophy;
            break;
        }
    }
}
