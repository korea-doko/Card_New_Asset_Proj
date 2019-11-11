using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class LoadDataModel
{
    [SerializeField] public List<RawCharacterData> rawCharacterDataList;
    [SerializeField] public List<RawItemData> rawItemDataList;

    public void Init()
    {
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