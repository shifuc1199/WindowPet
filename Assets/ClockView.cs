using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockView : MonoBehaviour
{
    public GameObject clockCell;

    List<TimeCell> cells = new List<TimeCell>();
    // Start is called before the first frame update
    void Awake()
    {
        EventHandler.OnAddClock += UpdateCell;
        UpdateCell();
    }
    public void UpdateCell()
    {
        foreach (var time in DataModel.Model.RemainTime)
        {
            if (!cells.Exists(a=> { return a.GetModel() == time; }))
            {
                var cell = Instantiate(clockCell, transform);
                cell.GetComponent<TimeCell>().SetModel(time);
                cells.Add(cell.GetComponent<TimeCell>());
            }
           
        }
    }
    private void OnDestroy()
    {
        EventHandler.OnAddClock -= UpdateCell; 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
