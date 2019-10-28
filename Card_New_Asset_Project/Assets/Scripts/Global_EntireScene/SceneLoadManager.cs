using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneName
{
    Loading,
    Lobby,
    Play,
    Result
}

public class SceneManager : MonoBehaviour
{

    void Start()
    {
        DontDestroyOnLoad(this);
    }    

    public static void ChangeSceneTo(SceneName sceneName)
    {

    }
}
