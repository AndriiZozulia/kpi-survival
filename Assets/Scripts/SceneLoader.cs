using UnityEngine;
using UnityEngine.SceneManagement;
using Entity;
using System;

public class SceneLoader : MonoBehaviour
{

    public string sceneName;
    private const string lastLoadedPath = "Assets/base_mm/LastLoadedScene.xml";

    public void LoadScene()
    {
        if (sceneName.Equals(""))
        {
            sceneName = XMLUtil.Deserialize<SceneEntity>(lastLoadedPath).name;
        }

        SaveLastScene();

        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
        else
        {
            throw new NullReferenceException();
        }
    }

    void SaveLastScene()
    {
        SceneEntity sceneItem = new SceneEntity();
        sceneItem.name = SceneManager.GetActiveScene().name;

        XMLUtil.Serialize(sceneItem, "Assets/base_mm/LastLoadedScene.xml");
    }

    public SceneEntity GetLastLoadedScene()
    {
        return XMLUtil.Deserialize<SceneEntity>(lastLoadedPath);
    }
}