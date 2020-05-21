using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamerTool.UI;
public class ClockView : View
{
    public GameObject clockCell;
    public Transform root;
    List<TimeCell> cells = new List<TimeCell>();
    // Start is called before the first frame update
    void Awake()
    {
        EventHandler.OnAddClock += UpdateCell;
        UpdateCell();
    }
    public void RemoveCell(TimeCell cell)
    {
        Destroy(cell.gameObject);
        cells.Remove(cell);
    }
    public void UpdateCell()
    {
 
        foreach (var time in DataModel.Model.RemainTime)
        {
         
            if (!cells.Exists(a=> { return a.GetModel() == time; }))
            {
                var cell = Instantiate(clockCell, root);
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
