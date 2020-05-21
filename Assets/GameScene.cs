using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamerTool.UI;
using System;

public class GameScene : Scene
{
    private void Start()
    {
       
    }
    private void OnApplicationQuit()
    {
        DataManager.SaveData();
    }
    private void Update()
    {
        foreach (var time in DataModel.Model.RemainTime)
        {
            if (time.isStart && !time.isPass)
            {
                if (time.dayTime.Equals(DateTime.Now))
                {
                   GetView<ClockTipView>().SetModel(time);
                    time.isPass = true;
                }
            }
        }
    }
}
