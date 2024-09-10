using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    [SerializeField] private int scval;
    [SerializeField] private AudioClip acPoint;
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            GameManager.instance.PlayAudio(acPoint);
            ScoreManager.instance.UpdateScore(scval);
        }
    }
}
