using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum State
    {
        TITLE,
        READY,
        PLAY,
        GAMEOVER,
        HISCORE
    }
    public State GameState { get { return gameState; } }
    public static GameManager instance;
    
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject[] stateUI;
    [SerializeField] private Sprite[] bgsp;
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private AudioClip acReady;
    [SerializeField] private AudioClip acHit;
    private new AudioSource audio;
    private State gameState;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        Time.timeScale = 1.0f;
        GameTitle();
    }

    public void PlayAudio(AudioClip clip)
    {
        audio.PlayOneShot(clip);
    }

    private void ChangeState(State val)
    {
        gameState = val;
        //stateUI에 있는 모든 UI를 끈다
        foreach (var item in stateUI)
        {
            item.SetActive(false);
        }
        int temp = (int)val;
        background.sprite = bgsp[temp % 2];
        stateUI[temp].SetActive(true);
    }

    public void GameTitle()
    {
        ChangeState(State.TITLE);
    }
    public void GameReady()
    {
        ChangeState(State.READY);
        PlayAudio(acReady);
    }
    public void GamePlay()
    {
        ChangeState(State.PLAY);
    }

    public void GameOver()
    {
        ChangeState(State.GAMEOVER);
        PlayAudio(acHit);
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
