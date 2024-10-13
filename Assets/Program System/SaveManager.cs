using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    private static string savePath =  Application.persistentDataPath + "/playerdata.save";

    // save data
    public static void SaveGame(int highScore, List<Achievement> unlockedAchievements) {
        BinaryFormatter formatter = new();
        FileStream stream = new(savePath, FileMode.Create);
        List<string> achievementsTitle = new();

        foreach(var achievement in unlockedAchievements) {
            achievementsTitle.Add(achievement.title);
        }

        PlayerData data = new(highScore, achievementsTitle);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    // load data
    public static PlayerData LoadGame() {
        if(File.Exists(savePath)) {
            BinaryFormatter formatter = new();
            FileStream stream = new(savePath, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        } else {
            Debug.LogWarning("player data not found");
            return null;
        }
        
    }
}
