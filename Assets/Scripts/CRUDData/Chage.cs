using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class Chage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public TextAsset jsonFile;

    public void OnButtonClick()
    {
        // string filePath = Path.Combine("Save", "InforTank.json");
        string filePath =  Application.dataPath + "/Save/InforTank.json";
        string jsonString = File.ReadAllText(filePath);
        Debug.Log(jsonString);
        var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
Debug.Log(data);
        // Lấy giá trị của key "t1"
        var t1Data = (Dictionary<string, object>)data["t0"];
        var t1Name = (string)t1Data["module"];
        var t1Price = (bool)t1Data["sourceMap"];
        Debug.Log(t1Name+t1Price);
        // string t1Name = (string)t1Data["name"];
        // int t1Price = (int)t1Data["price"];
        //
        // Debug.Log("t1 name: " + t1Name);
        // Debug.Log("t1 price: " + t1Price);
    }
}
