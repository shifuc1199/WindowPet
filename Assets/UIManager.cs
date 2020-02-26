using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeechLib;
public class UIManager : MonoBehaviour
{
    public static UIManager _instance;
    public GameObject SettingMenu;
    private void Awake()
    {
      
        _instance = this;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
