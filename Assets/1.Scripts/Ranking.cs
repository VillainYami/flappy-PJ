using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public const int MAX_RANK = 5;
    public static string DTPattern = @"yyMMddhhmmss";

    [SerializeField] private RankUI[] ranking;
    
    void Start()
    {
        for (int i = 0; i < MAX_RANK; i++)
        {
            string key = PlayerPrefs.GetString($"RANKDATE{i}", $"24010112000{i}");
            int value = PlayerPrefs.GetInt($"RANKSCORE{i}", 0);
            ranking[i].SetRank(i, value, key);
        }
    }

    public int CalcurateRank(int score)
    {
        Dictionary<string, int> rankDic = new Dictionary<string, int>();
        for (int i = 0; i < MAX_RANK; i++)
        {
            string key = PlayerPrefs.GetString($"RANKDATE{i}", $"24010112000{i}");
            int value = PlayerPrefs.GetInt($"RANKSCORE{i}", 0);
            rankDic.Add(key, value);
        }
        string nowKey = DateTime.Now.ToString(DTPattern);
        rankDic.Add(nowKey, score);

        var newdic = rankDic.OrderByDescending(x => x.Value);
        int nowRanking = MAX_RANK;
        int index = 0;
        foreach (var item in newdic)
        {
            PlayerPrefs.SetString($"RANKDATE{index}",item.Key);
            PlayerPrefs.SetInt($"RANKSCORE{index}",item.Value);
            if (item.Key.CompareTo(nowKey) == 0)
            {
                nowRanking = index;
            }
            if (++index == MAX_RANK) break;
        }

        return nowRanking;
    }
}
