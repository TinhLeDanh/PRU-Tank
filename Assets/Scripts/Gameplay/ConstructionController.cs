using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionController : MonoBehaviour
{
    public static ConstructionController Instance { get; private set; }

    public int width;
    public int height;
    public int[,] stuffMatrix;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        stuffMatrix = new int[width, height];
    }

    private void Start()
    {
        InitMatrix();
    }

    private void InitMatrix()
    {
        ResetMatrix(0);
    }

    private void ResetMatrix(int value)
    {
        foreach (int i in stuffMatrix)
            foreach (int j in stuffMatrix)
                stuffMatrix[i, j] = value;
    }

    public void ApplyStuffToMatrix(int x, int y, int id)
    {
        stuffMatrix[x, y] = id;
    }
}
