using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameInstance : MonoBehaviour
{
    public MapGenerator mapGenerator;

    public PlayerCharacterEntity tank;
    public EnemyCharacterEntity enemy;

    private ConstructionController constructionController;
    private int[,] stuffMatrix;

    private void Awake()
    {
        constructionController = GetComponent<ConstructionController>();
       
    }

    private void Start()
    {
        //SpawnEnemy();
        SetupCamera();
        InitConstructionMap();
    }

    private void SetupCamera()
    {
        Camera cam = Camera.main;
        cam.transform.position = new Vector3(constructionController.width / 2, constructionController.height / 2, -10);
    }

    private void InitConstructionMap()
    {
        if (constructionController.LoadMap())
        {
            Instantiate(tank, constructionController.spawnPos, Quaternion.identity);
        }
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

    private void SpawnPlayer()
    {

    }
}
