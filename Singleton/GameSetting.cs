using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    public static float sensitivity;
    public static GameSetting instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        { 
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        InitializeManager();
    }
    private void InitializeManager()
    {
    }

}
