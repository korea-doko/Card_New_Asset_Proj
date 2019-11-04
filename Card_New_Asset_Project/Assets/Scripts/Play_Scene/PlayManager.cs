using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public SpriteRenderer bgSpr;

    public float defaultWidth;
    public float defaultHeight;

    // Start is called before the first frame update
    void Start()
    {

      

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneLoadManager.ChangeSceneTo(SceneName.Result);
    }
}
