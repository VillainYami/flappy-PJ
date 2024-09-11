using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float speed = 0.65f;
    [SerializeField] private BoxCollider2D upPipe;
    [SerializeField] private BoxCollider2D downPipe;
    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.instance.GameState == GameManager.State.PLAY)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (GameManager.instance.GameState == GameManager.State.GAMEOVER)
        {
            upPipe.enabled = downPipe.enabled = false;
        }
    }
}
