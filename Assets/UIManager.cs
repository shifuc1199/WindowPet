using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager _instance;
    public GameObject SettingMenu;
    public ClockTip ClockTip;
    public GameObject Tip;
    private void Awake()
    {
        _instance = this;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void SetTip(string contenct,Vector3 pos)
    {
        if(contenct==null)
        {
            Tip.SetActive(false);
            return;
        }
        Tip.transform.position = pos;
        Tip.SetActive(true);
        Tip.GetComponentInChildren<Text>().text = contenct;
    }
    private void Update()
    {
        
        foreach (var time in DataModel.Model.RemainTime)
        {
            if(time.isStart && !time.isPass)
            {
                if(time.dayTime.Equals(DateTime.Now))
                {
                    ClockTip.SetModel(time);
                    time.isPass = true;
                }
            }
        }
    }
}
