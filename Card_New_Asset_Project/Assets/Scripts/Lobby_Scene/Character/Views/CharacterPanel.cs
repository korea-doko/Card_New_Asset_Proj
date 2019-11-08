using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CharacterPanel : MonoBehaviour
{
    public event EventHandler OnNextButtonClicked;
    public event EventHandler OnPrevButtonClicked;
    public event EventHandler OnSelectButtonClicked;
    public event EventHandler OnBackButtonClicked;

    public Image characterImage;

    

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descText;

    public Button nextButton;
    public Button prevButton;
    public Button selectButton;
    public Button backButton;
    

    public void Init()
    {
        nextButton.onClick.AddListener(ClickNextButton);
        prevButton.onClick.AddListener(ClickPrevButton);
        selectButton.onClick.AddListener(ClickSelectButton);
        backButton.onClick.AddListener(ClickBackButton);

        Hide();
    }


    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }


    private void ClickNextButton()
    {
        OnNextButtonClicked(this, EventArgs.Empty);
    }
    private void ClickPrevButton()
    {
        OnPrevButtonClicked(this, EventArgs.Empty);
    }
    private void ClickSelectButton()
    {
        OnSelectButtonClicked(this, EventArgs.Empty);
    }
    private void ClickBackButton()
    {
        OnBackButtonClicked(this, EventArgs.Empty);
        Hide();
    }

}
