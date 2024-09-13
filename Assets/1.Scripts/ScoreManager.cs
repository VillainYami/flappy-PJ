using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private PlayCanvas canvas;

    private int score = 0;

    public int Score { get { return score; } }
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void UpdateScore(int val)
    {
        score += val;
        canvas.UpdateScore();
    }
}
