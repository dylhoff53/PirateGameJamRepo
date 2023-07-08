using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreThing : MonoBehaviour
{
    public int score;
    public GameManager gm;
    public bool newScore;


    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SaveScore()
    {
        if (gm.score > score)
        {
            newScore = true;
            score = gm.score;
        } else
        {
            score = gm.score;
        }
    }
}
