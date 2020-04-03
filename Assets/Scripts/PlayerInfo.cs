using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(menuName = "Player Info")]
public class PlayerInfo : ScriptableObject
{
    public Vector2 spawnPos;
    public int deathCounter;

    public string savePath => Application.persistentDataPath + Path.DirectorySeparatorChar + name + ".txt";

    public void StoreToDisk()
    {
        string playerInfoAsText = JsonUtility.ToJson(this, true);
        File.WriteAllText(savePath, playerInfoAsText);
        Debug.Log(savePath);
    }

    public bool readFromDisk()
    {
        if (File.Exists(savePath))
        {
            Debug.LogError("File exists");
            string textFromFile = File.ReadAllText(savePath);
            JsonUtility.FromJsonOverwrite(textFromFile, this);
            Debug.Log(textFromFile);
            return true;
        }
        else
        {
            Debug.LogError("File doesn't exist");
            return false;
        }
    }
}
