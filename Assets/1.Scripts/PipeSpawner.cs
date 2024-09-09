using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.4f;
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private GameObject pipePrefabRed;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTime)
        {
            SpawnPipe();
            timer = 0;
        }
    }

    private void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject pipePf = (Random.Range(0,100) < 10) ? pipePrefabRed : pipePrefab;
        GameObject pipe = Instantiate(pipePf, spawnPos, Quaternion.identity);
        Destroy(pipe, 5f);
    }
}
