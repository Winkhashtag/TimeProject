using UnityEngine;

[System.Serializable]
public class SaveData 
{
    public Vector3 position;
    public PlayerData playerdata;
    public float favoriteColor;
}

[System.Serializable]
public class PlayerData
{
    public string name;
   
}
