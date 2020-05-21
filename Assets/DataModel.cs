using System.Collections.Generic;
using System;
using LitJson;
public class DataModel   
{
   static DataModel _model;
    [JsonNonField]
    public static DataModel Model 
    {
        get
        {


            if (_model == null)
            {
                _model = DataManager.GetData();

                if(_model==null)
                    _model = new DataModel();
            }

            return _model;
        }
    }
    public List<BookModel> BookList = new List<BookModel>();
    public List<ClockModel> RemainTime = new List<ClockModel>(); // 提醒时间
    public bool isTopMost; // 是否置顶
    public bool isSteupStart;  
    public void AddBook(BookModel model)
    {
        
        BookList.Add(model);
    }
    public void RemoveBook(BookModel model)
    {
        BookList.Remove(model);
    }
    public void RemoveRemainTime(ClockModel model)
    {
        RemainTime.Remove(model);
    }
    public void UpdateBook(BookModel model)
    {
        BookList[BookList.FindIndex(a => { return a == model; })] = model;
    }
    public void AddRemainTime(ClockModel model)
    {
        RemainTime.Add(model);
      
    }
}
public class BookModel
{
    public string content;
    public BookModel()
    {

    }
    public BookModel(string content)
    {
        this.content = content;
    }
}
public class DayTime
{
    public int hour;
    public int minute;
    public override bool Equals(object obj)
    {
        if(obj is DateTime)
        {
            var dateTime =(DateTime)obj;
            return dateTime.Hour == hour && dateTime.Minute == minute;
        }
        return base.Equals(obj);
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
    public void AddMinute(int value)
    {
        minute += value;
        if (minute >= 60)
        {
            AddHour(minute/60);
            minute %= 60;
        }
        if (minute < 0)
        {
            if (minute / 60 == 0)
            {
                AddHour(-1); ;
            }
            else
            {
                AddHour(minute / 60);
            }
            if (minute % 60 == 0)
            {
                minute = 0;
            }
            else
            {
                minute = 60 + minute % 60;
            }
        }
    }
    public void AddHour(int value)
    {
        hour += value;
        if(hour>23)
        {
            hour %= 24;
        }
        if (hour < 0)
        {
            hour = 24+hour;
        }
    }
 
    public string GetString()
    {
        return (hour<10?"0":"")+hour + ":" +( minute < 10 ? "0" : "")+minute;
    }
   
}
public class ClockModel
{
    public int id;
    public DayTime dayTime;
    public string clockDes;
    public bool isStart = true;

    public bool isPass = false;
    public ClockModel()
    {

    }
    public ClockModel(DayTime dayTime,string clockDes)
    {

        this.clockDes = clockDes;
        this.dayTime = dayTime;
    }
}