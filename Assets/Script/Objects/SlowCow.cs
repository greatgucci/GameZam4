using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowCow : MyObjects
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerMoving.instance.HP += value;
            PlayerMoving.instance.GoStun();
            
            Destroy(this.gameObject);
        }

    }

}
