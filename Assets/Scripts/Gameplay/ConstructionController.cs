using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionController : MonoBehaviour
{
    public static ConstructionController Instance { get; private set; }

    public int[,] stuffMatrix;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        stuffMatrix = new int[20, 20];
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

    public void ApplyStuffToMatrix()
    {

    }
}
