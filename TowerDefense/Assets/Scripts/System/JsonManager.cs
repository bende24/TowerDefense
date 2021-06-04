using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class JsonManager{
    static private string getJsonAsResource(string path){
        TextAsset jsonFile = Resources.Load<TextAsset>(path);
        return jsonFile.text;
    }
    
    static public T getDataFromJson<T>(string folder, string json) {
        string path = folder + json;
        string jsonFile = getJsonAsResource(path);
        return JsonUtility.FromJson<T>(jsonFile);
    }
}