using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject RockPrefab;
    public float spawnDelay = 0.2f;
    public float spawnRadius = 40f;
    public float speed = 50f;
    public static int countOfRocks = 5;
    public TextMeshProUGUI rocksRemainingText;
    public GameManager gameManager;

    public static int rocksRemaining;
    private Vector3 spawnPosition;

    private void Start()
    {
        StartCoroutine(SpawnRocks());
        rocksRemaining = countOfRocks;
    }

    private IEnumerator SpawnRocks()
    {
        spawnPosition.y = transform.position.y;
        spawnPosition.z = transform.position.z;
        for(int i = 0; i < countOfRocks; i++)
        {
            spawnPosition.x = Random.Range(-spawnRadius, spawnRadius);
            Instantiate(RockPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
    private void Update()
    {
        if(rocksRemaining == 0)
        {
            gameManager.StartCoroutine("NextLevel");
        }
        rocksRemainingText.text = rocksRemaining.ToString();
    }
}
