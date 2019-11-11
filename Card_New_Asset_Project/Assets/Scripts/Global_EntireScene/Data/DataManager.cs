using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] public List<RawCharacterData> rawCharacterDataList;
    [SerializeField] public List<RawItemData> rawItemDataList;

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

        LoadRawCharacterData();
        LoadRawItemData();
    }   

    private void LoadRawCharacterData()
    {
        rawCharacterDataList = new List<RawCharacterData>();

        RawCharacterData[] rcds = Resources.LoadAll<RawCharacterData>("SOs/Characters");

        foreach (RawCharacterData rcd in rcds)
            rawCharacterDataList.Add(rcd);
    }
    private void LoadRawItemData()
    {
        rawItemDataList = new List<RawItemData>();

        RawItemData[] rids = Resources.LoadAll<RawItemData>("SOs/Items");

        foreach (RawItemData rid in rids)
            rawItemDataList.Add(rid);
    }
}
