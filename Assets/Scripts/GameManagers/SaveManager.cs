using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

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

    public void LoadPlayer()
    {
        playerSave = new SaveEntity();
        Load(playerSave);
    }

    public void LoadSettings()
    {
        settingsSave = new SettingsEntity();
        Load(settingsSave);
    }

    public void Load()
    {
        playerSave = new SaveEntity();
        settingsSave = new SettingsEntity();
        Load(playerSave);
        Load(settingsSave);
    }

    public void SavePlayer()
    {
        Save(playerSave);
    }

    public void SaveSettings()
    {
        Save(settingsSave);
    }

    public void Save(BaseSaveEntity save, bool kill = false)
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            
            if (playerSave.GetType().IsInstanceOfType(save))
            {
                if (!kill)
                {
                    save = new SaveEntity(QuestManager.GetInstance().GetCurrQuestID(), RatingManager.GetInstance().Getrating());
                }
                file = File.Create(Application.persistentDataPath + PLAYER_SAVE_PATH);

                bf.Serialize(file, save);
            }

            if (settingsSave.GetType().IsInstanceOfType(save))
            {
                if (!kill)
                {
                    save = new SettingsEntity();
                }
                file = File.Create(Application.persistentDataPath + SETTINGS_SAVE_PATH);

                bf.Serialize(file, save);
            }

            Debug.Log("Save() " + save.GetType());
        }
        catch(Exception e)
        {
            if (e != null)
            {
                //handle
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

    public void Load(BaseSaveEntity save)
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            if (playerSave.GetType().IsInstanceOfType(save))
            {
                if (!File.Exists(Application.persistentDataPath + PLAYER_SAVE_PATH))
                {
                    CreatePlayerSave();
                }
                file = File.Open(Application.persistentDataPath + PLAYER_SAVE_PATH, FileMode.Open);
                playerSave = bf.Deserialize(file) as SaveEntity;
            }

            if (settingsSave.GetType().IsInstanceOfType(save))
            {
                if (!File.Exists(Application.persistentDataPath + SETTINGS_SAVE_PATH))
                {
                    CreateSettingsSave();
                }
                file = File.Open(Application.persistentDataPath + SETTINGS_SAVE_PATH, FileMode.Open);
                settingsSave = bf.Deserialize(file) as SettingsEntity;
            }

            Debug.Log("Load() " + save.GetType());
        }
        catch (Exception e)
        {
            if (e != null)
            {
                Debug.LogAssertion("SAVE NOT LOADED");
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
        playerSave = new SaveEntity(QuestManager.GetInstance().GetFirstQuestID(), new RatingEntity());
        Save(playerSave, true);
    }

    public void CreateSettingsSave()
    {
        settingsSave = new SettingsEntity();
        Save(settingsSave, true);
    }

    public RatingEntity GetRating()
    {
        if (playerSave == null)
        {
            Load();
        }

        return playerSave.GetRating();
    }

    public string GetSavedQuestID()
    {
        if (playerSave == null)
        {
            Load();
        }

        return playerSave.GetQuestID();
    }
}
