using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject SettingPanel;

    [SerializeField] private string StartLevelName;

    [SerializeField] private Button[] GraphicsButtons;

    void Start()
    {
        CloseAll();
        MainPanel.SetActive(true);
        QualitySettings.SetQualityLevel(1);

        ColorBlock cb = GraphicsButtons[0].colors;

        foreach (var item in GraphicsButtons)
        {

            cb.normalColor = Color.red;
            item.colors = cb;
        }
        cb.normalColor = Color.green;

        GraphicsButtons[1].colors = cb;
        
    }


    void Update()
    {

    }

    private void CloseAll()
    {
        MainPanel.SetActive(false);
        SettingPanel.SetActive(false);
    }

    public void NewGameButton()
    {
        SceneManager.LoadScene(StartLevelName);
    }

    public void ActiveSettingPanel()
    {
        CloseAll();
        SettingPanel.SetActive(true);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);

        ColorBlock cb;
        cb = GraphicsButtons[0].colors;

        foreach (var item in GraphicsButtons)
        {
            cb.normalColor = Color.red;
            item.colors = cb;
        }

        cb.normalColor = Color.green;
        GraphicsButtons[qualityIndex].colors = cb;


    }

    public void Back()
    {
        CloseAll();
        MainPanel.SetActive(true);
    }
}
