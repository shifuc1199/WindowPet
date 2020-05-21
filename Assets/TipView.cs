using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DreamerTool.UI;
public class TipView : View
{
    public void SetTip(string contenct, Vector3 pos)
    {
        if (contenct == null)
        {
            gameObject.SetActive(false);
            return;
        }
        transform.position = pos;
        gameObject.SetActive(true);
        gameObject.GetComponentInChildren<Text>().text = contenct;
    }
}
