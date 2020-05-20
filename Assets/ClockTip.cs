using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClockTip : MonoBehaviour
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
