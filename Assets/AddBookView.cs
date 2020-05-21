using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DreamerTool.UI;
public class AddBookView : View
{
    BookCell cell;
    public InputField input;
    // Start is called before the first frame update
      public void SetModel(BookCell book)
    {
        cell = book;
 
        input.text = book.model.content;
    }
    public void AddBook()
    {
        CurrentScene.CloseView<BookView>();
        
 
        if (cell == null)
        {
            DataModel.Model.AddBook(new BookModel(input.text));
            EventHandler.OnAddBook?.Invoke();
        }
        else
        {
            cell.model.content = input.text;
            DataModel.Model.UpdateBook(cell.model);
            cell.UpdateModel();
        }
        OnCloseClick();
        View.CurrentScene.OpenView<BookView>();

    }
    private void OnDisable()
    {
        cell = null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
