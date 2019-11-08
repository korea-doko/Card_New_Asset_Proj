using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerModel model;
    public PlayerView view;

    private static PlayerManager inst;
    public static PlayerManager Inst
    {
        get
        {
            return inst;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        model.Init();
        view.Init(model);
    }    
}
