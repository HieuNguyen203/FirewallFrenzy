using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopByPoints : PlayerLife
{
    [SerializeField] float stopPoint = 50f;
    private void Update()
    {
        if(HighScore.score == stopPoint)
        {
            ShowPanel();
        }
    }
}
