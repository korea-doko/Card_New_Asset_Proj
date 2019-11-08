using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private static MapManager inst;
    public MapModel model;
    public MapView view;

    public static MapManager Inst
    {
        get
        {
            return inst;
        }
    }
    public MapManager()
    {
        inst = this;
    }

    private void Start()
    {
        model.Init();
        view.Init(model);
    }
}
