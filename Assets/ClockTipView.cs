using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DreamerTool.UI;
public class ClockTipView : View
{
    public float tipTime;
    public Text timeText;
    public void SetModel(ClockModel clockModel)
    {
        gameObject.SetActive(true);
        SpeakManager.Instance.Speak(clockModel.clockDes);
        timeText.text = clockModel.dayTime.GetString();
        Timer.Register(tipTime, () =>
        {
            gameObject.SetActive(false);
        });
    }
}
