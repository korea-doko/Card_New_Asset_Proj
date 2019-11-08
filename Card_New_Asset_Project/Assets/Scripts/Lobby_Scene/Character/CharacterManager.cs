using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public CharacterModel model;
    public CharacterView view;
    private static CharacterManager inst;
    public static CharacterManager Inst
    {
        get
        {
            return inst;
        }
    }
    public CharacterManager()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        model.Init();

        view.Init(model);
        view.OnBackButtonClicked += View_OnBackButtonClicked;
        view.OnNextButtonClicked += View_OnNextButtonClicked;
        view.OnPrevButtonClicked += View_OnPrevButtonClicked;
        view.OnSelectButtonClicked += View_OnSelectButtonClicked;
    }

    private void View_OnSelectButtonClicked(object sender, EventArgs e)
    {

    }

    private void View_OnPrevButtonClicked(object sender, EventArgs e)
    {

    }

    private void View_OnNextButtonClicked(object sender, EventArgs e)
    {
    }

    private void View_OnBackButtonClicked(object sender, EventArgs e)
    {
        PageManager.Inst.TurnOverLeftToRight
            (
                ()=> { LobbyManager.Inst.ShowMenuPanel(); }
            );        
    }

    public void ShowCharacterPanel()
    {
        view.ShowCharacterPanel();
    }
}
