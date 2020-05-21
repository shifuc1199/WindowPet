using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
public class DataManager 
{
    public const string dataKey = "data";

    public static DataModel GetData()
    {
        if(PlayerPrefs.HasKey(dataKey))
        {
            return JsonMapper.ToObject<DataModel>(PlayerPrefs.GetString("data"));
        }
        return null;
    }
    public static void ClearData()
    {
        PlayerPrefs.DeleteKey(dataKey);
    }
    public static void SaveData()
    {
       PlayerPrefs.SetString(dataKey, JsonMapper.ToJson(DataModel.Model));
    }
    
}
