using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConstructionController : MonoBehaviour
{
    public static ConstructionController Instance { get; private set; }

    public int width;
    public int height;
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
            ConstructionMapData mapObject = new ConstructionMapData("map custom", stuffMatrix);
            saveSystem.AddObjectByJson("t4", mapObject);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            ConstructionMapData mapObject = saveSystem.GetObjectByJson<ConstructionMapData>("t4");
            LoadMap(mapObject);
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadSceneAsync("Menu"); 
        }
    }

    private void InitMatrix()
    {
        ResetMatrix(-1);
    }

    private void ResetMatrix(int value)
    {
        for (int i = 0; i < stuffMatrix.GetLength(0); i++)
            for (int j = 0; j < stuffMatrix.GetLength(1); j++)
            {
                stuffMatrix[i, j] = value;
            }
    }

    private void LoadMap(ConstructionMapData map)
    {
        stuffMatrix = map.matrix;

        for (int i = 0; i < stuffMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < stuffMatrix.GetLength(1); j++)
            {
                if (stuffMatrix[i, j] != -1)
                    Instantiate(stuffs.stuffList[stuffMatrix[i, j]], new Vector2(i, j), Quaternion.identity);
            }

        }
    }

    public void ApplyStuffToMatrix(int x, int y, int id)
    {
        stuffMatrix[x, y] = id;
    }


}
