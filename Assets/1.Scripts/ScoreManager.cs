using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI scoretext;
    private int score = 0;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void UpdateScore(int val)
    {
        score += val;
        scoretext.text = score.ToString();
    }
}
