using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    //singleton instance
    public static SaveManager instance;
    public SaveData data;

    private string saveFilePath; 
    void Start()
    {
        //already a singleton in the scene?
        if(instance != null && instance != this)
        {
            //if so, destroy ourselves
            Destroy(this);
            return;
        }
        instance = this;
        saveFilePath = $"{Application.persistentDataPath}/save/save.json";

        SaveToFile();
        Debug.Log(Application.persistentDataPath);
    }

    public void LoadFromFile()
    {
        //if file doesn't exist, don't try to load a nonexistant file
        if(!File.Exists(saveFilePath))
        {
            return; //do nothiing
        }
        //otherwise, read save file and write to our data variable
        string json = File.ReadAllText(saveFilePath);
        JsonUtility.FromJsonOverwrite(json, data);
    }

   public void SaveToFile()
    {
        //if file doesn't already exist, create it
        if(!File.Exists(saveFilePath))
        {
            //create directory, then file
            Directory.CreateDirectory(Path.GetDirectoryName(saveFilePath));
            File.CreateText(saveFilePath);
        }

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);
    }
}
