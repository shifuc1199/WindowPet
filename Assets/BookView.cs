using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamerTool.UI;
public class BookView : View
{
    public GameObject bookCell;
    public Transform root;
    List<BookCell> cells = new List<BookCell>();
    private void Awake()
    {
        UpdateCell();
        EventHandler.OnAddBook += UpdateCell;
    }
    private void OnDestroy()
    {
        EventHandler.OnAddBook -= UpdateCell;
    }
    public void RemoveCell(BookCell cell)
    {
        Destroy(cell.gameObject);
        cells.Remove(cell);
    }
    public void UpdateCell()
    {

        foreach (var time in DataModel.Model.BookList)
        {
            if (!cells.Exists(a => { return a.GetModel() == time; }))
            {
                var cell = Instantiate(bookCell, root);
                cell.GetComponent<BookCell>().SetModel(time);
                cells.Add(cell.GetComponent<BookCell>());
            }
        }

    }
}
