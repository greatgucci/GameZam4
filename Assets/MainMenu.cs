using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public Text HighScore;
    public Text OnOff;
    public GameObject Manual;
    public GameObject Item;

    private void Start()
    {
        PlayerPrefs.SetInt("IsItem", 0);
        OnOff.text = "Off";
        HighScore.text = "최고기록 : " + PlayerPrefs.GetInt("HighScore") +"초";
    }
    public  void LoadToIngame()
    {
        SceneManager.LoadScene(1);
    }
    public void setItemBool()
    {
        if(PlayerPrefs.GetInt("IsItem") == 0)
        {
            OnOff.text = "On";
            PlayerPrefs.SetInt("IsItem", 1);
        }
        else
        {
            PlayerPrefs.SetInt("IsItem", 0);
            OnOff.text = "Off";
        }
    }
    public void GamePopUp()
    {
        Manual.SetActive(true);
    }
    public void GamePopUpExit()
    {
        Manual.SetActive(false);
    }
    public void ItemPopUp()
    {
        Item.SetActive(true);
    }
    public void ItemPopUpExit()
    {
        Item.SetActive(false);
    }
}
