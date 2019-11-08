using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    public CharacterPanel characterPanel;

    public event EventHandler OnBackButtonClicked;
    public event EventHandler OnNextButtonClicked;
    public event EventHandler OnPrevButtonClicked;
    public event EventHandler OnSelectButtonClicked;

    public void Init(CharacterModel model)
    {
        characterPanel.Init();

        characterPanel.OnBackButtonClicked += CharacterPanel_OnBackButtonClicked;
        characterPanel.OnNextButtonClicked += CharacterPanel_OnNextButtonClicked;
        characterPanel.OnPrevButtonClicked += CharacterPanel_OnPrevButtonClicked;
        characterPanel.OnSelectButtonClicked += CharacterPanel_OnSelectButtonClicked;
    }

    
    public void ShowCharacterPanel(CharacterModel model)
    {
        characterPanel.Show(model);
    }

    private void CharacterPanel_OnSelectButtonClicked(object sender, EventArgs e)
    {
        OnSelectButtonClicked(sender, e);
    }
    private void CharacterPanel_OnPrevButtonClicked(object sender, EventArgs e)
    {
        OnPrevButtonClicked(sender, e);
    }
    private void CharacterPanel_OnNextButtonClicked(object sender, EventArgs e)
    {
        OnNextButtonClicked(sender, e);
    }
    private void CharacterPanel_OnBackButtonClicked(object sender, EventArgs e)
    {
        OnBackButtonClicked(sender, e);
    }

}
