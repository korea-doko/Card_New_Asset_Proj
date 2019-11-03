using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneName
{
    Loading,
    Lobby,
    Play,
    Result
}

public class SceneLoadManager : MonoBehaviour
{

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }    

    public static void ChangeSceneTo(SceneName _sceneName)
    {
        SceneManager.LoadScene(_sceneName.ToString());
    }
}
