using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class ChangeJson : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnButtonClick()
    {
        var t = new t0()
        {
            module = Guid.NewGuid().ToString(),
            sourceMap = false
        };
        var a = AddObjectByJson("t3", t);
        Debug.Log(a);
    }
    public void OnButtonClick2()
    {
        var a = GetObjectByJson<t0>("t3");
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
        var a = RemoveObjectByJson<t0>("t3");
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
        catch (Exception e)
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
            string t0Json = jsonObject[key].ToString();
            var myObj = JsonConvert.DeserializeObject<T>(t0Json);
            return myObj;
        }
        catch (Exception e)
        {
            return default;
        }
    }
    public bool RemoveObjectByJson<T>(string key)
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
        catch (Exception e)
        {
            return false;
        }
    }

    [Serializable]
    public class t0
    {
        public string module { get; set; }
        public bool sourceMap { get; set; }
    }
}
