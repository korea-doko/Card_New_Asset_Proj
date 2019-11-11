using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] public LoadDataModel loadDataModel;
    [SerializeField] public PassDataModel passDataModel;

    private static DataManager inst;
    public DataManager()
    {
        inst = this;
    }
    public static DataManager Inst
    {
        get
        {
            return inst;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(this);

        loadDataModel.Init();
        passDataModel.Init();
    }
}