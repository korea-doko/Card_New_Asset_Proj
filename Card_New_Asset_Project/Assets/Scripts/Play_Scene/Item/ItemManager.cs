using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public ItemModel model;
    public ItemView view;

    private static ItemManager inst;
    public static ItemManager Inst
    {
        get
        {
            return inst;
        }
    }

    void Start()
    {
        model.Init();
        view.Init(model);
    }
}
