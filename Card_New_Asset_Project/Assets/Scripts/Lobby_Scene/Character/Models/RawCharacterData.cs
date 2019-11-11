using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu][System.Serializable]
public class RawCharacterData : ScriptableObject
{
    [SerializeField] public Sprite charImage;
    [SerializeField] public string charName;
    [SerializeField] public string charDesc;
    [SerializeField] public int maxLife;
    [SerializeField] public int maxEnergy;
    [SerializeField] public int maxCardSlots;
    [SerializeField] public int maxInventory;

    // 초반에 유물 같은 것이나 특수 능력은 나중에 만들고
    // 여기에 enum 형식으로 추가 가능
}
