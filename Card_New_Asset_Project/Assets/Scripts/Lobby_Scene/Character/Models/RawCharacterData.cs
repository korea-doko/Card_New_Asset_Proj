using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu][SerializeField]
public class RawCharacterData : ScriptableObject
{
    public Sprite charImage;
    public string charName;
    public string charDesc;
    public int maxLife;
    public int maxEnergy;
    public int maxCardSlots;

    // 초반에 유물 같은 것이나 특수 능력은 나중에 만들고
    // 여기에 enum 형식으로 추가 가능
}
