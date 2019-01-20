using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum Day
{
    MORNING,
    NIGHT
}
public class DayManager : MonoBehaviour {
    public static DayManager instance;
    private void Awake()
    {
        instance = this;
    }
    public Color day;
    public Color night;
    public Day currentDay = Day.NIGHT;
    public SpriteRenderer window;
    public int currentScore;
	// Use this for initialization
	void Start () {
        StartCoroutine(ChangeDay());
	}
    IEnumerator ChangeDay()
    {
        while(true)
        {
            currentDay = Day.NIGHT;
            PlayerMoving.instance.Min = 400;
            PlayerMoving.instance.Max = 1200;
            window.color = night;
            UIController.instance.GoodControll(false);
            float tempTime=30;
            while(true)
            {
                tempTime -= 1;
                if(tempTime<=0)
                {
                    break;
                }
                currentScore++;
                UIController.instance.TimeControll((int)tempTime);
                yield return new WaitForSeconds(1f);
            }
            currentDay = Day.MORNING;
            PlayerMoving.instance.Min = 100;
            PlayerMoving.instance.Max = 900;
            window.color = day;
            UIController.instance.GoodControll(true);
            tempTime = 30;
            while (true)
            {
                tempTime -= 1;
                if (tempTime <= 0)
                {
                    break;
                }
                currentScore++;

                UIController.instance.TimeControll((int)tempTime);
                yield return new WaitForSeconds(1f);
            }
            if(RandomSpawn.instance.currentLevel == Level.LOW)
            {
                RandomSpawn.instance.currentLevel = Level.MIDDLE;
            }else if (RandomSpawn.instance.currentLevel == Level.MIDDLE)
            {
                RandomSpawn.instance.currentLevel = Level.HIGH;
            }
        }
    }
}
