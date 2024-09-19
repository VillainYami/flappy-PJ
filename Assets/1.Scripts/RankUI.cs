using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;

public class RankUI : MonoBehaviour
{
    [SerializeField] private Image medal;
    [SerializeField] private TextMeshProUGUI rankText;
    [SerializeField] private TextMeshProUGUI dateText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Sprite[] medalSP;

    public void SetRank(int rank, int score, string dt)
    {
        // 3이상일시 3을, 아니면 그 값을 인덱스로 한다.
        int medalIndex = (rank > 2) ? 3 : rank;

        medal.sprite = medalSP[medalIndex];

        rankText.text = (rank + 1).ToString();

        rankText.gameObject.SetActive(rank >= 3);

        if (dt != null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("20");
            sb.Append(dt.Substring(0, 2));
            sb.Append("/");
            sb.Append(dt.Substring(2, 2));
            sb.Append("/");
            sb.Append(dt.Substring(4, 2));
            sb.Append("\n");
            sb.Append(dt.Substring(6, 2));
            sb.Append(":");
            sb.Append(dt.Substring(8, 2));
            sb.Append(":");
            sb.Append(dt.Substring(10, 2));

            dateText.text = sb.ToString();
        }

        scoreText.text = score.ToString();
    }
}
