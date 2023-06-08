using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConstructionController : MonoBehaviour
{
    public static ConstructionController Instance { get; private set; }

    public int width;
    public int height;
    public Vector2 spawnPos;
    public int[,] stuffMatrix;
    public ConstructionStuffListSO stuffs;

    private ChangeJson saveSystem;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        stuffMatrix = new int[width, height];
        saveSystem = GetComponent<ChangeJson>();
    }

    private void Start()
    {
        InitMatrix();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ConstructionMapData mapObject = new ConstructionMapData("map", stuffMatrix);
            saveSystem.AddObjectByJson("t4", mapObject);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadMap();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadSceneAsync("Menu");
        }
    }

    private void InitMatrix()
    {
        //ResetMatrix(-1);
        CreateBase();
    }

    private void ResetMatrix(int value)
    {
        for (int i = 0; i < stuffMatrix.GetLength(0); i++)
            for (int j = 0; j < stuffMatrix.GetLength(1); j++)
            {
                stuffMatrix[i, j] = value;
            }
    }

    public bool LoadMap()
    {
        ConstructionMapData map = saveSystem.GetObjectByJson<ConstructionMapData>("t4");
        if (map == null)
            return false;

        stuffMatrix = map.matrix;

        for (int i = 0; i < stuffMatrix.GetLength(0); i++)
            for (int j = 0; j < stuffMatrix.GetLength(1); j++)
            {
                if (stuffMatrix[i, j] != -1 && (i != spawnPos.x && j != spawnPos.y))
                    Instantiate(stuffs.stuffList[stuffMatrix[i, j]], new Vector2(i, j), Quaternion.identity);
            }

        return true;
    }

    private void CreateBase()
    {
        ResetMatrix(-1);

        stuffMatrix[width / 2, 0] = 12;
        stuffMatrix[width / 2 - 1, 0] = 2;
        stuffMatrix[width / 2 + 1, 0] = 0;
        stuffMatrix[width / 2, 1] = 1;
        stuffMatrix[width / 2 - 1, 1] = 14;
        stuffMatrix[width / 2 + 1, 1] = 13;

        Instantiate(stuffs.stuffList[12], new Vector2(width / 2, 0), Quaternion.identity);
        Instantiate(stuffs.stuffList[13], new Vector2(width / 2 + 1, 1), Quaternion.identity);
        Instantiate(stuffs.stuffList[14], new Vector2(width / 2 - 1, 1), Quaternion.identity);
        Instantiate(stuffs.stuffList[0], new Vector2(width / 2 + 1, 0), Quaternion.identity);
        Instantiate(stuffs.stuffList[1], new Vector2(width / 2, 1), Quaternion.identity);
        Instantiate(stuffs.stuffList[2], new Vector2(width / 2 - 1, 0), Quaternion.identity);

    }

    public void ApplyStuffToMatrix(int x, int y, int id)
    {
        stuffMatrix[x, y] = id;
    }


}
