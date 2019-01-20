using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MyObjects : MonoBehaviour {

    
    public int value;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerMoving.instance.HP += value+PlayerMoving.instance.plusValue;
            AudioManager.instance.drink.Play();
            Destroy(this.gameObject);
        }
    }
    public void SetThis(int dir)
    {
        Rigidbody2D rig = GetComponent<Rigidbody2D>();
        float speed =0;
        switch (RandomSpawn.instance.currentLevel)
        {
            case Level.LOW:
                speed = 2;
                break;
            case Level.MIDDLE:
                speed = 3;
                break;
            case Level.HIGH:
                speed = 3.5f;
                break;
        }
        switch (dir)
        {
            case 0://left
                transform.position = new Vector3(-12, Random.Range(-4, 4), 0);
                rig.velocity = new Vector2(speed, Random.Range(-1, 1));
                break;
            case 1://up
                transform.position = new Vector3(Random.Range(-9, 9), 10, 0);
                rig.velocity = new Vector2(-Random.Range(-1, 1),- speed);
                break;
            case 2://right
                transform.position = new Vector3(12, Random.Range(-4, 4), 0);
                rig.velocity = new Vector2(-speed, Random.Range(-1, 1));
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }
    float myTime;
    private void Update()
    {
        myTime += Time.deltaTime;
        if (myTime > 10)
        {
            Destroy(this.gameObject);
        }
    }
}
