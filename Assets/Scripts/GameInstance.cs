using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameInstance : MonoBehaviour
{
    public MapGenerator mapGenerator;

    public PlayerCharacterEntity tank;
    public EnemyCharacterEntity enemy;

    private void Start()
    {
        SpawnEnemy();
    }

    public void OnMapGenerated()
    {
        int rand = Random.Range(0, mapGenerator.floorPosition.Count);
        Vector2 spawnPos = mapGenerator.floorPosition[rand];

        Instantiate(tank, spawnPos, Quaternion.identity);
        Instantiate(enemy, spawnPos, Quaternion.identity);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemy, Vector2.zero , Quaternion.identity);
    }
}
