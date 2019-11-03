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

        //float worldHeight = Camera.main.orthographicSize * 2.0f;
        //float worldWidth = worldHeight / Screen.height * Screen.width;

        //bgSpr.transform.localScale =
        //    new Vector3
        //    (
        //        worldWidth / bgSpr.sprite.bounds.size.x,
        //        worldHeight / bgSpr.sprite.bounds.size.y,
        //        1
        //    );

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneLoadManager.ChangeSceneTo(SceneName.Result);
    }
}
