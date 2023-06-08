using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public void CreateNewFile(string fileName)
    {
        string path = Application.dataPath + "/Save/" + fileName;
        File.CreateText(path);
    }
}
