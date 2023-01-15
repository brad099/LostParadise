using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Home Panel")]
    [SerializeField] GameObject HomePanel;

    [Header("Settings Panel")]
    [SerializeField] GameObject SettingsPanel;
    [SerializeField] GameObject SettingsHomePanel;


    [Header("Pause Panel")]
    [SerializeField] GameObject PausePanel;
    [SerializeField] Slider SoundSlider;
    private bool PMenu;
    [SerializeField] GameObject BackgroundMusic;
    private bool BMusic;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    private void Start()
    {
        SoundManager.instance.Play("Background", true);
        SoundSlider.onValueChanged.AddListener(SoundManager.instance.ChangeVolume);
        OpenHomePanel();
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PMenu = !PMenu;
            PausePanel.SetActive(PMenu);
            if (PMenu)
            {
            Time.timeScale = 0;    
            }
            else
            {
            Time.timeScale = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            SettingsPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    ////    Slider Volume   ////

    public void BackMusic()
    {
        BMusic = !BMusic;
        if (BMusic)
        {     
            BackgroundMusic.SetActive(false);
        }
        else
        {
            BackgroundMusic.SetActive(true);
        }
    }


    public void Quit()
    {
        Application.Quit();
    }

    //////// Home Panel ///////
    public void OpenHomePanel()
    {
        HomePanel.SetActive(true);
    }
    public void CloseHomePanel()
    {
        // Starting Game
        HomePanel.SetActive(false);
        Time.timeScale = 1;
    }


    //////// Settings Panel ///////
    public void OpenSettingsPanel()
    {
        HomePanel.SetActive(false);
        PausePanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }
    public void CloseSettingsPanel()
    {
        SettingsPanel.SetActive(false);
        PausePanel.SetActive(true);
    }

    // Settings Home Version
    public void OpenSettingsHomePanel()
    {
        HomePanel.SetActive(false);
        PausePanel.SetActive(false);
        SettingsHomePanel.SetActive(true);
    }
    public void CloseSettingsHomePanel()
    {
        SettingsHomePanel.SetActive(false);
        HomePanel.SetActive(true);
    }

    //Pause Panel
    public void OpenPausePanel()
    {
        SettingsPanel.SetActive(true);
    }

    public void ClosePausePanel()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}