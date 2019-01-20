using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Level
{
    LOW,
    MIDDLE,
    HIGH
}
public class RandomSpawn : MonoBehaviour {

    public static RandomSpawn instance;
    private void Awake()
    {
        instance = this;
    }
    public GameObject[] spawnObject; //0->hotsix , 1->fat , 2->pet , 3->slowCow
    public GameObject strongWind;

     Level _currentLevel;
    public Level currentLevel
    {
        get
        {
            return _currentLevel;
        }
        set
        {
            if(value == Level.MIDDLE)
            {
                spawnItemPerSec = middleSpawn;
            }else if(value == Level.HIGH)
            {
                spawnItemPerSec = highSpawn;
            }
            _currentLevel = value;
        }
    }
    public float spawnItemPerSec;
    public float spawnWindPerSec;
    public int middleSpawn;
    public int highSpawn;

    private void Start()
    {
        StartCoroutine(SpawnItem());
        StartCoroutine(SpawnWind());
    }
    IEnumerator SpawnWind()
    {
        while (true)
        {
            InstantantiateWind();
            yield return new WaitForSeconds(1 / spawnWindPerSec);

        }
    }
    IEnumerator SpawnItem()
    {
        while(true)
        {
            switch(currentLevel)
            {
                case Level.LOW:
                    InstantiateRandomPos1(Random.Range(0, 3),Random.Range(0,100));
                    break;
                case Level.MIDDLE:
                    InstantiateRandomPos2(Random.Range(0, 3), Random.Range(0, 100));
                    break;
                case Level.HIGH:
                    InstantiateRandomPos3(Random.Range(0, 3), Random.Range(0, 100));
                    break;
            }
            yield return new WaitForSeconds(1/spawnItemPerSec);

        }
    }
    void InstantiateRandomPos1(int dir,int val)
    {
        int temp=0;
        if(val<=45)
        {
            temp = 0;
        }else if(val <= 65)
        {
            temp = 1;
        }
        else if(val <= 75)
        {
            temp = 2;
        }
        else
        {
            temp = 3;
        }
         Instantiate(spawnObject[temp]).GetComponent<MyObjects>().SetThis(dir);

        
    }
    void InstantiateRandomPos2(int dir, int val)
    {
        int temp = 0;
        if (val <= 40)
        {
            temp = 0;
        }
        else if (val <= 60)
        {
            temp = 1;
        }
        else if (val <= 70)
        {
            temp = 2;
        }
        else
        {
            temp = 3;
        }

        Instantiate(spawnObject[temp]).GetComponent<MyObjects>().SetThis(dir);

    }
    void InstantiateRandomPos3(int dir, int val)
    {
        int temp = 0;
        if (val <= 35)
        {
            temp = 0;
        }
        else if (val <= 50)
        {
            temp = 1;
        }
        else if (val <= 60)
        {
            temp = 2;
        }
        else
        {
            temp = 3;
        }

        Instantiate(spawnObject[temp]).GetComponent<MyObjects>().SetThis(dir);


    }
    void InstantantiateWind()
    {
        Instantiate(strongWind).GetComponent<StrongWind>().SetThis(Random.Range(0,2));
        Debug.Log("Wind Spawn");
    }
}
