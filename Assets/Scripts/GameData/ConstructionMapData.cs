using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ConstructionMapData
{
    public string mapName;
    public int[,] matrix;

    public ConstructionMapData(string name, int[,] newMatrix)
    {
        mapName = name;
        matrix = newMatrix;
    }
}
