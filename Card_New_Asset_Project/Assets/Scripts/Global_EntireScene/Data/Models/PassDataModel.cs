using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PassDataModel 
{
    public int selectedRawCharacterIndex;

    public void Init()
    {
        this.selectedRawCharacterIndex = -1;
    }
}
