using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public PlayerData PlayerData = new PlayerData();
    public GameObject Player;

    public void SaveData(string Level)
    {
        PlayerData = new PlayerData(Player.transform.position, Level);

        string json = JsonUtility.ToJson(PlayerData);

        string path = Path.Combine(Application.persistentDataPath, "GAMEDATA.json");

        Debug.Log(path);

        File.WriteAllText(path, json);

        Debug.Log("Saved new position: " + json);
    }

    public void LoadData()
    {
        string path = Path.Combine(Application.persistentDataPath, "GAMEDATA.json");

        PlayerData = JsonUtility.FromJson<PlayerData>(File.ReadAllText(path));

        Player.transform.position = PlayerData.Position;

        Debug.Log("Loaded old position name of: " + PlayerData.Level);
    }

    public void LoadSavedLevel(SceneChanger sceneChanger)
    {
        string path = Path.Combine(Application.persistentDataPath, "GAMEDATA.json");

        PlayerData = JsonUtility.FromJson<PlayerData>(File.ReadAllText(path));
        sceneChanger.ChangeSceneTo(PlayerData.Level);
    }
}

[Serializable]
public class PlayerData
{
    public Vector3 Position;
    public string Level;

    public PlayerData() { }

    public PlayerData(Vector3 position, string level)
    {
        Position = position;
        Level = level;
    }
}

