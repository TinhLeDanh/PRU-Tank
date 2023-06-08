using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class ChangeJson : MonoBehaviour
{

    public void OnButtonClick()
    {
        var t = new T0()
        {
            module = Guid.NewGuid().ToString(),
            sourceMap = false
        };
        var a = AddObjectByJson("t3", t);
        Debug.Log(a);
    }
    public void OnButtonClick2()
    {
        var a = GetObjectByJson<T0>("t3");
        if (a is not null)
        {
            Debug.Log(222+a.module);
        }
        else
        {
            Debug.Log(null);
        }
    }
    public void OnButtonClick3()
    {
        var a = RemoveObjectByJson("t3");
            Debug.Log(a);
    }

    

    public bool AddObjectByJson<T>(string key, T objectJson)
    {
        try
        {
            string filePath = Application.dataPath + "/Save/InforTank.json";
            string jsonString = File.ReadAllText(filePath);
            JObject jsonObject = JObject.Parse(jsonString);
            jsonObject[key] = JObject.FromObject(objectJson);
            File.WriteAllText(Application.dataPath + "/Save/InforTank.json", jsonObject.ToString());
            return true;
        }
        catch
        {
            return false;
        }
    }

    public T GetObjectByJson<T>(string key)
    {
        try
        {
            string filePath = Application.dataPath + "/Save/InforTank.json";
            string jsonString = File.ReadAllText(filePath);
            JObject jsonObject = JObject.Parse(jsonString);
            var t0Json = jsonObject[key]!.ToString();
            var myObj = JsonConvert.DeserializeObject<T>(t0Json);
            return myObj;
        }
        catch 
        {
            return default;
        }
    }
    public bool RemoveObjectByJson(string key)
    {
        try
        {
            string filePath = Application.dataPath + "/Save/InforTank.json";
            string jsonString = File.ReadAllText(filePath);
            JObject jsonObject = JObject.Parse(jsonString);
            jsonObject.Remove(key);
            File.WriteAllText(Application.dataPath + "/Save/InforTank.json", jsonObject.ToString());
            return true;
        }
        catch 
        {
            return false;
        }
    }

    public List<string> GetAllKeyMap()
    {
        try
        {
            var listKey = new List<string>();
            var allColors = Enum.GetValues(typeof(KeyMapEnum));
            foreach (KeyMapEnum key in allColors)
            {
                listKey.Add(key.ToString());
            }
            return listKey;
        }
        catch 
        {
            return null;
        }
    }

    [Serializable]
    public class T0
    {
        public string module { get; set; }
        public bool sourceMap { get; set; }
    }
}
