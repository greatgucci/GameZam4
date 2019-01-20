using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    public static Items instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if(PlayerPrefs.GetInt("IsItem") == 1)
        {
            switch(Random.Range(0,6))
            {
                case 0:
                    SmallSoup();
                    UIController.instance.ItemAdd(0);
                    break;
                case 1:
                    BigSoup();
                    UIController.instance.ItemAdd(1);
                    break;
                case 2:
                    BongbongDrink();
                    UIController.instance.ItemAdd(2);
                    break;
                case 3:
                    Bangi();
                    UIController.instance.ItemAdd(3);
                    break;
                case 4:
                    Alchoal();
                    UIController.instance.ItemAdd(4);
                    break;
                case 5:
                    DasBoots();
                    UIController.instance.ItemAdd(5);
                    break;

            }
        }
    }
    public void SmallSoup()
    {
        PlayerMoving.instance.playerScale = 0.75f;
    }
    public void BigSoup()
    {
        PlayerMoving.instance.playerScale = 1.25f;
    }
    public void BongbongDrink()
    {
        PlayerMoving.instance.plusValue = 30f;
    }
    public void Bangi()
    {
        PlayerMoving.instance.plusValue = -30f;
    }
    public void Alchoal()
    {
        PlayerMoving.instance.isAlchoal = true;
    }
    public void DasBoots()
    {
        PlayerMoving.instance.jumpConditioner = 3;
    }
}
