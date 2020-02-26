using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    DataModel model;
    private void Awake()
    {
        Instance = this;
    }
     public void SaveData()
    {

    }
    private void OnApplicationQuit()
    {
        SaveData();
    }
}
