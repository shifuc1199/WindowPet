using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TimeCell : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    ClockModel model;
    public Text timeText;
    public void SetModel(  ClockModel clockModel)
    {
        model = clockModel ;
        timeText.text = clockModel.dayTime.GetString();
    }
    public ClockModel GetModel()
    {
        return model;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
         
        UIManager._instance.SetTip(model.clockDes,transform.position);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager._instance.SetTip(null, transform.position);
    }
}
