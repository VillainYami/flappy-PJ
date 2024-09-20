using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float speed = 0.65f;
    [SerializeField] private BoxCollider2D upPipe;
    [SerializeField] private BoxCollider2D downPipe;
    public bool Moving { get; set; }

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.instance.GameState == GameManager.State.PLAY)
        {
            if (Moving)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        else if (GameManager.instance.GameState == GameManager.State.GAMEOVER)
        {
            upPipe.enabled = downPipe.enabled = false;
        }
    }
}
