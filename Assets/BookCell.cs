using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DreamerTool.UI;
using UnityEngine.EventSystems;
public class BookCell : MonoBehaviour,IPointerClickHandler
{
    public Text showText;
    public BookModel model;
    public void OnPointerClick(PointerEventData eventData)
    {
        View.CurrentScene.OpenView<AddBookView>().SetModel(this);
    }
    public void UpdateModel()
    {
        showText.text = model.content;
    }
    public void SetModel(BookModel book)
    {
        model = book;
        showText.text = book.content;
    }
 
    public BookModel GetModel()
    {
        return model;
    }
}
