using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private PlayCanvas canvas;
    [SerializeField] private Ranking ranking;

    private int score = 0;
    private int rank = 0;

    public int Score => score;
    public int Rank => rank;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void UpdateScore(int val)
    {
        score += val;
        canvas.UpdateScore();
    }

    public void CheckHiScore()
    {
        rank = ranking.CalcurateRank(score);
        canvas.UpdateResult();
    }
#if UNITY_EDITOR
    [MenuItem("FlappyBird/Reset HiScore", false, 1)]
    public static void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
#endif
}
