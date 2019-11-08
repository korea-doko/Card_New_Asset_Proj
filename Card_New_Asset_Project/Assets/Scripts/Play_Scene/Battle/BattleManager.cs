using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{


    public BattleModel model;
    public BattleView view;

    private static BattleManager inst;
    public static BattleManager Inst
    {
        get
        {
            return inst;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }
    
}
