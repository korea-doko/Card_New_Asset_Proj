using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class SceneLoadManager 
{
    public enum SceneName
    {
        Loading,
        Lobby,
        Play,
        Result
    }

    public static void ChangeSceneTo(SceneName _sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene((int)_sceneName);

    }
}
