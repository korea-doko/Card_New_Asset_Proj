using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingManager : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {        
            SceneLoadManager.ChangeSceneTo(SceneName.Lobby);            
        }
    }
}
