using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI 보이는것만 
/// </summary>
public class UIController : MonoBehaviour {
    public Image myItem;
    public Sprite[] items;


    public static UIController instance;
    private void Awake()
    {
        instance = this;
        min = transform.Find("Min").GetComponent<Image>();
        max = transform.Find("Max").GetComponent<Image>();
        current = transform.Find("current").GetComponent<Image>();
        myItem = transform.Find("ItemBackGround").Find("Item").GetComponent<Image>();
        good = transform.Find("Good").GetComponent<Image>();
        time = transform.Find("Time").GetComponent<Text>();
    }

    Image min;
    Image max;
    Image current;
    Image good;
    Text time;
	// Use this for initialization

    public void CurrentControll(float value)
    {
        current.rectTransform.anchoredPosition = new Vector2(value, -70)+new Vector2(-150,0);
    }
    public void MinControll(float value)
    {
        min.rectTransform.sizeDelta = new Vector2(value, 50); 
    }
    public void MaxControll(float value)
    {
        max.rectTransform.sizeDelta = new Vector2(value, 50);
    }
    public void ItemAdd(int target)
    {
        myItem.sprite = items[target];
    }
    public void GoodControll(bool isDay)
    {
        if(isDay)
        {
            good.rectTransform.anchoredPosition = new Vector2(100, 0);
        }
        else
        {
            good.rectTransform.anchoredPosition = new Vector2(400, 0);

        }
    }
    public void TimeControll(int _time)
    {
        if(DayManager.instance.currentDay == Day.MORNING)
        time.text = "낮"+_time.ToString()+"초";
        else
        {
            time.text = "새벽" + _time.ToString() + "초";
        }
        if (_time<10)
        {
            time.color = Color.red;
        }
        else
        {
            time.color = Color.black;
        }
    }
}
