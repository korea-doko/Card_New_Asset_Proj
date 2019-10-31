using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public CardModel model;
    public CardView view;


    // Start is called before the first frame update
    void Start()
    {
        model.Init();
        view.Init(model);

        Debug.Log("Card Manager");
    }    
}
