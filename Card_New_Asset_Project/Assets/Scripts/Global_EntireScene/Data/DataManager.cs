using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    
    public static List<RawCharacterData> rawCharacterDataList;
    
    void Start()
    {
        DontDestroyOnLoad(this);

        LoadRawCharacterData();
    }   

    private void LoadRawCharacterData()
    {
        rawCharacterDataList = new List<RawCharacterData>();

        RawCharacterData[] rcds = Resources.LoadAll<RawCharacterData>("SOs/Characters");

        foreach (RawCharacterData rcd in rcds)
            rawCharacterDataList.Add(rcd);
    }
}
