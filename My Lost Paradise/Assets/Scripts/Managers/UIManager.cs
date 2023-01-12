using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("General Panel")]
    [SerializeField] GameObject GeneralPanel;

    [Header("Home Panel")]
    [SerializeField] GameObject HomePanel;

    [Header("Settings Panel")]
    [SerializeField] GameObject SettingsPanel;
    [SerializeField] GameObject SettingsUIPanel;

    [Header("Prize Panel")]
    [SerializeField] GameObject PrizePanel;
    [SerializeField] GameObject PrizeUIPanel;


    [Header("Shop Panel")]
    [SerializeField] GameObject ShopPanel;
    [SerializeField] GameObject ShopUIPanel;

    [Header("Win Panel")]
    [SerializeField] GameObject WinPanel;
    [SerializeField] TMP_Text WinCoinTxt;
    [SerializeField] GameObject WinUIPanel;

    [Header("Fail Panel")]
    [SerializeField] GameObject FailPanel;
    [SerializeField] GameObject FailUIPanel;

    private bool opened;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    private void Start()
    {
        OpenHomePanel();
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            opened = true;
            ShopPanel.SetActive(true);
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            opened = false;
            ShopPanel.SetActive(false);
            Time.timeScale = 1;
        }
        

    }

    public void Quit()
    {
        Application.Quit();
    }

    //////// General Panel ///////
    public void OpenGeneralPanel()
    {
        GeneralPanel.SetActive(true);
    }
    public void CloseGeneralPanel()
    {
        GeneralPanel.SetActive(false);
    }

    //////// Home Panel ///////
    public void OpenHomePanel()
    {
        HomePanel.SetActive(true);
    }
    public void CloseHomePanel()
    {
        HomePanel.SetActive(false);
        //Time.timeScale = 1;
    }


    //////// Settings Panel ///////
    public void OpenSettingsPanel()
    {
        SettingsPanel.SetActive(true);
        SettingsUIPanel.SetActive(true);

    }
    public void CloseSettingsPanel()
    {
        SettingsPanel.SetActive(false);
        SettingsUIPanel.SetActive(false);
    }


    //////// Win Panel ///////
    public void OpenWinPanel()
    {
        WinPanel.SetActive(true);
    }
    public void CloseWinPanel()
    {
        WinPanel.SetActive(false);
    }



    //////// Fail Panel ///////
    public void OpenFailPanel()
    {
        FailPanel.SetActive(true);
    }
    public void CloseFailPanel()
    {
        FailPanel.SetActive(false);
    }


    //////// Prize Panel ///////
    public void OpenPrizePanel()
    {
        PrizePanel.SetActive(true);
        PrizeUIPanel.SetActive(true);
    }
    public void ClosePrizePanel()
    {
        PrizePanel.SetActive(false);
        PrizeUIPanel.SetActive(false);
    }


    //Shop Panel
    public void OpenShopPanel()
    {
        ShopPanel.SetActive(true);
        ShopUIPanel.SetActive(true);
    }

    public void CloseShopPanel()
    {

        ShopPanel.SetActive(false);
        ShopUIPanel.SetActive(false);
    }
}