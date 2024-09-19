using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scorePlay;
    [SerializeField] private Image medal;
    [SerializeField] private TextMeshProUGUI scoreResult;
    [SerializeField] private TextMeshProUGUI bestScore;
    [SerializeField] private Sprite[] medalSP;

    private ScoreManager smi;

    void Start()
    {
        smi = ScoreManager.instance;
    }
    
    public void UpdateScore()
    {
        scorePlay.text = smi.Score.ToString();
    }

    public void UpdateResult()
    {
        //3위 이내 메달표시
        if (smi.Rank < 3)
        {
            medal.sprite = medalSP[smi.Rank];
        }
        //4위부터 메달 표시없음
        else
        {
            medal.gameObject.SetActive(false);
        }

        scoreResult.text = smi.Score.ToString();

        // 베스트스코어는 최고스코어 값을 보여준다.
        bestScore.text = PlayerPrefs.GetInt("RANKSCORE0", 0).ToString();
    }
}
