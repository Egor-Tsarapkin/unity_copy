using UnityEngine;
using System.IO;

public static class SaveSystem
{
    private static string Path =>
        Application.persistentDataPath + "/save.json";

    public static void Save(GameData data)
    {
        try
        {
            File.WriteAllText(Path, JsonUtility.ToJson(data));
            Debug.Log($"[SaveSystem] Сохранено: {Path}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"[SaveSystem] Ошибка сохранения: {e.Message}");
        }
    }

    public static bool Load(GameData data)
    {
        try
        {
            if (!File.Exists(Path))
            {
                return false;
            }

            JsonUtility.FromJsonOverwrite(File.ReadAllText(Path), data);
            Debug.Log($"[SaveSystem] Загружено. Уровень: {data.lastUnlockedLevel}");
            return true;
        }
        catch (System.Exception)
        {
            return false;
        }
    }

    public static void DeleteSave()
    {
        try
        {
            if (!File.Exists(Path)) return;
            File.Delete(Path);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"[SaveSystem] Ошибка удаления: {e.Message}");
        }
    }
}