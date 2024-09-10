using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GMState = GameManager.State;

public class FlappyCtrl : MonoBehaviour
{
    [SerializeField] private float velocity = 1.5f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private AudioClip acWing;
    private GameManager gmi;

    private Rigidbody2D rb;

    private void Start()
    {
        gmi = GameManager.instance;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gmi.GameState == GMState.READY)
            {
                gmi.GamePlay();
                rb.gravityScale = 0.5f;
            }
            else if (gmi.GameState == GMState.PLAY)
            {
                gmi.PlayAudio(acWing);
                rb.velocity = Vector2.up * velocity;
            }
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0,0,rb.velocity.y * rotateSpeed);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        gmi.GameOver();
    }
}
