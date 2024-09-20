using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.4f;
    [SerializeField] private GameObject[] pipePrefab;
    [SerializeField] private GameObject[] pipePrefabRed;

    private const int MAX_PIPE = 3;
    private int pipeIndex = 0;

    private float timer;

    void Update()
    {
        if (GameManager.instance.GameState == GameManager.State.PLAY)
        {
            if (timer >= maxTime)
            {
                SpawnPipe();
                timer = 0;
            }
            timer += Time.deltaTime;
        }
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        
        //GameObject pipePf = (Random.Range(0,100) < 10) ? pipePrefabRed : pipePrefab;
        //GameObject pipe = Instantiate(pipePf, spawnPos, Quaternion.identity);
        //Destroy(pipe, 5f);

        if (Random.Range(0, 100) < 10)
        {
            pipePrefabRed[pipeIndex].transform.SetPositionAndRotation(spawnPos, Quaternion.identity);
            pipePrefabRed[pipeIndex].GetComponent<MovePipe>().Moving = true;
        }
        else
        {
            pipePrefab[pipeIndex].transform.SetPositionAndRotation(spawnPos, Quaternion.identity);
            pipePrefab[pipeIndex].GetComponent<MovePipe>().Moving = true;
        }

        if (++pipeIndex == MAX_PIPE)
        {
            pipeIndex = 0;
        }
    }
}
