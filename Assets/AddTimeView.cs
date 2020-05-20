using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AddTimeView : MonoBehaviour
{
    public InputField desText;
    public Text timeText;
    public DayTime dayTime = new DayTime();
    private void Awake()
    {
        UpdateText();
    }
    void UpdateText()
    {
        timeText.text = dayTime.GetString();
    }
    public void MinusTenMinute()
    {
        dayTime.AddMinute(-10);
        UpdateText();
    }
    public void MinusMinute()
    {
        dayTime.AddMinute(-1);
        UpdateText();
    }
    public void MinusHour()
    {
        dayTime.AddHour(-1);
        UpdateText();
    }
    public void AddTenMinute()
    {
        dayTime.AddMinute(10);
        UpdateText();
    }
    public void  AddMinute()
    {
        dayTime.AddMinute(1);
        UpdateText();
    }
    public void AddHour()
    {
        dayTime.AddHour(1);
        UpdateText();
    }
    public void AddClock()
    {
        DataModel.Model.RemainTime.Add(new ClockModel(dayTime, desText.text));
        gameObject.SetActive(false);
        EventHandler.OnAddClock?.Invoke();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
