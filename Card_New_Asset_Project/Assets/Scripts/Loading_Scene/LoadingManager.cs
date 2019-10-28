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
            Debug.Log("a");
            SceneLoadManager.ChangeSceneTo(SceneLoadManager.SceneName.Lobby);

            
        }
    }
}
