using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LobbyManager : MonoBehaviour
{
    private static LobbyManager inst;
    public LobbyManager()
    {
        inst = this;
    }
    public static LobbyManager Inst
    {
        get
        {
            return inst;
        }
    }

    [SerializeField] private GameObject menuPanel;

    public Button playButton;
    public Button exitButton;

    
    // Start is called before the first frame update
    private void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneLoadManager.ChangeSceneTo(SceneName.Play);
    }

    public void HideMenuPanel()
    {
        menuPanel.SetActive(false);
    }
    public void ShowMenuPanel()
    {
        menuPanel.SetActive(true);
    }

    private void OnPlayButtonClicked()
    {
        HideMenuPanel();
        PageManager.Inst.TurnOverRightToLeft(() => { CharacterManager.Inst.ShowCharacterPanel(); });

    }
    private void OnExitButtonClicked()
    {
        Application.Quit();
    }

    
    
}
