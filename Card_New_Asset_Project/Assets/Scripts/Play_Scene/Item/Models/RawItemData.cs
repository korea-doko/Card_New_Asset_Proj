using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu][System.Serializable]
public class RawItemData : ScriptableObject
{
    [SerializeField] public Sprite itemSprite;
    [SerializeField] public string itemName;
    [SerializeField] public string itemTooltip;
    [SerializeField] public string itemDesc;    
}
