using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Entity;

public enum SaveType
{
    Player,
    Settings
}

public class SaveManager
{
    static SaveManager Instance;

    const string PLAYER_SAVE_PATH = "/KpiSurvivalSave.dat";
    const string SETTINGS_SAVE_PATH = "/KpiSurvivalSettings.dat";

    SaveEntity playerSave;
    SettingsEntity settingsSave;

    public static SaveManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new SaveManager();
        }
        return Instance;
    }

    public void Load()
    {
    }

    public void SavePlayer()
    {
        Save(SaveType.Player);
    }

    public void SaveSettings()
    {
        Save(SaveType.Settings);
    }

    private void Save(SaveType type, bool newSave = false)
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            
            if (type == SaveType.Player)
            {
                playerSave = SaveEntity.CreateSave(newSave);
                file = File.Create(Application.persistentDataPath + PLAYER_SAVE_PATH);

                bf.Serialize(file, playerSave);

                Debug.Log("Save() Player");
            }

            if (type == SaveType.Settings)
            {
                if (!newSave)
                {
                    settingsSave = new SettingsEntity();
                }
                file = File.Create(Application.persistentDataPath + SETTINGS_SAVE_PATH);

                bf.Serialize(file, settingsSave);

                Debug.Log("Save() Settings");
            }
        }
        catch(Exception e)
        {
            if (e != null)
            {
                Debug.LogAssertion(e.Message);
            }
        }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }

    public void Load(SaveType type)
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            string savePath = Application.persistentDataPath;

            if (type == SaveType.Player)
            {
                if (!File.Exists(savePath + PLAYER_SAVE_PATH))
                {
                    CreatePlayerSave();
                }
                file = File.Open(savePath + PLAYER_SAVE_PATH, FileMode.Open);
                playerSave = bf.Deserialize(file) as SaveEntity;

                Debug.Log("Load() Player");
            }

            if (type == SaveType.Settings)
            {
                if (!File.Exists(savePath + SETTINGS_SAVE_PATH))
                {
                    CreateSettingsSave();
                }
                file = File.Open(savePath + SETTINGS_SAVE_PATH, FileMode.Open);
                settingsSave = bf.Deserialize(file) as SettingsEntity;
                Debug.Log("Load() Settings");
            }
        }
        catch (Exception e)
        {
            if (e != null)
            {
                Debug.LogAssertion(e.Message);
            }
        }
        finally
        {
            if (file != null)
            {
                file.Close();
            }
        }
    }

    public void CreatePlayerSave()
    {
        Save(SaveType.Player, true);
    }

    public void CreateSettingsSave()
    {
        Save(SaveType.Settings, true);
    }

    public RatingEntity GetRating()
    {
        if (playerSave == null)
        {
            Load(SaveType.Player);
        }

        return playerSave.GetRating();
    }

    public string GetSavedQuestID()
    {
        if (playerSave == null)
        {
            Load(SaveType.Player);
        }

        return playerSave.GetQuestID();
    }

    public int GetSavedActionIndex()
    {
        if (playerSave == null)
        {
            Load(SaveType.Player);
        }

        return playerSave.GetActionIndex();
    }
}
