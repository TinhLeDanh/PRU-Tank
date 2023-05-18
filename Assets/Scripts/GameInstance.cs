using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    public MapGenerator mapGenerator;

    public GameObject tank;
    public GameObject enemy;

    private void Start()
    {
        
    }

    public void OnMapGenerated()
    {
        int rand = Random.Range(0, mapGenerator.floorPosition.Count);
        Vector2 spawnPos = mapGenerator.floorPosition[rand];

        Instantiate(tank, spawnPos, Quaternion.identity);
        Instantiate(enemy, spawnPos, Quaternion.identity);
    }
}
