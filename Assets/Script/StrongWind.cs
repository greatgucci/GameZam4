using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongWind : MonoBehaviour {

    public float speed;
    Rigidbody2D rig;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame

    public void SetThis(int dir)
    {
        Rigidbody2D rig = GetComponent<Rigidbody2D>();
        float speed = 4;

        switch (dir)
        {
            case 0://down
                transform.position = new Vector3(Random.Range(-9, 9), -10, 0);
                transform.Rotate(new Vector3(0, 0, -90));
                rig.velocity = new Vector2(0,speed);
                break;
            case 1://up
                transform.position = new Vector3(Random.Range(-9, 9), 10, 0);
                transform.Rotate(new Vector3(0, 0, 90));
                rig.velocity = new Vector2(0,-speed);
                break;
        }
    }
    float myTime;
    private void Update()
    {
        myTime += Time.deltaTime;
        if (myTime>5)
        {
            Destroy(this);
        }
    }
}
