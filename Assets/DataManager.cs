using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
public class DataManager 
{
  

     public void SaveData()
    {

    }
    private void OnApplicationQuit()
    {
        SaveData();
    }
}
