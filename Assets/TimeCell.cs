using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DreamerTool.UI;
using UnityEngine.EventSystems;
public class TimeCell : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
   
    ClockModel model;
    public Toggle isStartToggle;
    public Text timeText;
    public void SetModel( ClockModel clockModel)
    {
        model = clockModel;
        isStartToggle.isOn = clockModel.isStart;
        
        timeText.text = clockModel.dayTime.GetString();
    }
    public ClockModel GetModel()
    {
        return model;
    }
    public void IsStartToggle(bool v)
    {
        model.isStart = v;
    }
    public void Delete()
    {
         
       View.CurrentScene.GetView<TipView>().SetTip(null, transform.position);
        DataModel.Model.RemoveRemainTime(model);
        View.CurrentScene.GetView<ClockView>().RemoveCell(this);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

        View.CurrentScene.GetView<TipView>().SetTip(model.clockDes,transform.position);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        View.CurrentScene.GetView<TipView>().SetTip(null, transform.position);
    }
}
