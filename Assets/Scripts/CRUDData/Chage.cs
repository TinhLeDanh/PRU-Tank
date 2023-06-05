using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    }
    public T GetObjectByJson<T>(string key)
    {
        string filePath =  Application.dataPath + "/Save/InforTank.json";
        string jsonString = File.ReadAllText(filePath);
        JObject jsonObject = JObject.Parse(jsonString);
        string t0Json = jsonObject[key].ToString();
        var myObj =JsonConvert.DeserializeObject<T>(t0Json);
        return myObj;
    }
    
    [Serializable]
    public class t0
    {
        public string module { get; set; }
        public bool sourceMap { get; set; }
    }
}
