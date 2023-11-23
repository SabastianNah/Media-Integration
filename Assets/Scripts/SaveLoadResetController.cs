
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveLoadResetController
{
    public static void savePlayerData(PlayerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "playerSaveData.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameDataController data = new GameDataController(player);

        formatter.Serialize(stream, data);
        Debug.Log("Saving...");
        stream.Close();
    }

    public static GameDataController loadPlayerData()
    {
        string path = Application.persistentDataPath + "playerSaveData.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameDataController data = formatter.Deserialize(stream) as GameDataController;
            stream.Close();
            return data;
        } else
        {
            Debug.LogError("Save file not found error" + path);
            return null;
        }
        
    }
    public static void saveDoorData(GameObject door)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "saveData.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameDataController data = new GameDataController(door);

        formatter.Serialize(stream, data);
        Debug.Log("Saving...");
        stream.Close();
    }

    public static GameDataController loadDoorData()
    {
        string path = Application.persistentDataPath + "saveData.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameDataController data = formatter.Deserialize(stream) as GameDataController;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found error" + path);
            return null;
        }

    }
}
