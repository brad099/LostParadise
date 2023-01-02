using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESDataManager : MonoBehaviour
{
    [SerializeField] public GameData gameData;

    private static ESDataManager _instance;

    public static ESDataManager Instance
    {
        get
        {
            _instance = FindObjectOfType<ESDataManager>();
            return _instance;
        }
        set { _instance = value; }
    }

    private void Awake()
    {
        Load();
    }

    public void Load()
    {
        if (ES3.FileExists())
        {
            if (ES3.KeyExists(nameof(GameData)))
            {
                gameData = ES3.Load(nameof(GameData), gameData);
            }
        }
    }

    public void Save()
    {
        ES3.Save(nameof(GameData), gameData);
    }

    public void SetCheckPoint(Vector3 checkPoint)
    {
        gameData.checkPoint = checkPoint;
        Save();
    }

    public Vector3 GetLastCheckPoint()
    {
        return gameData.checkPoint;
    }
}
