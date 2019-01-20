using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Spine.Unity;

public class PlayerMoving : MonoBehaviour {

    public static PlayerMoving instance;
    // Use this for initialization
    private void Awake()
    {
        instance = this;
    }
    float currentHp;
    float currentMin=400;
    float currentMax=800;



    public bool isEnable=true;

    public void SetItem(int val)
    {
        switch(val)
        {
            case 0:
                Items.instance.SmallSoup();
                break;
            case 1:
                Items.instance.BigSoup();
                break;
            case 2:
                Items.instance.BongbongDrink();
                break;
            case 3:
                Items.instance.Bangi();
                break;
            case 4:
                Items.instance.Alchoal();
                    break;
            case 5:
                Items.instance.DasBoots();
                break;
        }
        UIController.instance.ItemAdd(val);
    }
    public float HP
    {
        get
        {
            return currentHp;
        }
        set
        {
            currentHp = value;
            UIController.instance.CurrentControll(value);
            if(currentHp<currentMin || currentHp>currentMax)
            {
                GameOver();
            }
        }
    }
    public float Min
    {
         get
        {
            return currentMin;
        }
        set
        {
            currentMin = value;
            UIController.instance.MinControll(value);
        }
    }
    public float Max
    {
        get
        {
            return currentMax;
        }
        set
        {
            currentMax = value;
            UIController.instance.MaxControll(1600-value);
        }
    }

    public float hpMinus;
    public Rigidbody2D rig;
    public int jumpCounter;

    public float moveSpeed;
    public float jumpHeight;
    public float downSpeed;
    SkeletonAnimation myAnim;
    public bool isGrounded;

    public float playerScale=1;
    public float plusValue=0;
    public int jumpConditioner = 2;
    public bool isAlchoal = false;
    private void Start()
    {
        myAnim = this.GetComponent<SkeletonAnimation>();

        HP = 800;
        rig = GetComponent<Rigidbody2D>();
        isEnable = true;
    }
    private void Update()
    {
        HP -=  hpMinus*Time.deltaTime;
        rig.velocity = new Vector3(0, rig.velocity.y, 0);

        if (isEnable)
        {
            if(!isAlchoal)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jumpCounter = jumpCounter + 1;
                }

                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.localScale = new Vector2(-playerScale, playerScale);
                    rig.velocity = new Vector3(-moveSpeed, rig.velocity.y, 0);
                    if (isGrounded)
                        changeAnim(true, 1f, "RUN");
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.localScale = new Vector2(playerScale, playerScale);
                    rig.velocity = new Vector3(moveSpeed, rig.velocity.y, 0);
                    if (isGrounded)
                        changeAnim(true, 1f, "RUN");
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    rig.velocity = new Vector2(rig.velocity.x, -downSpeed);
                    changeAnim(false, 1f, "WARF");
                }

                if (Input.GetKeyDown(KeyCode.Space) && jumpCounter <= jumpConditioner)
                {
                    //if (rig.velocity.y < 0)
                    rig.velocity = new Vector2(rig.velocity.x, 0);
                    rig.velocity += new Vector2(0, jumpHeight);
                    changeAnim(false, 1f, "JUMP");

                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jumpCounter = jumpCounter + 1;
                }
                if(isGrounded)
                changeAnim(true, 1f, "IDLE");
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.localScale = new Vector2(-playerScale, playerScale);
                    rig.velocity = new Vector3(-moveSpeed, rig.velocity.y, 0);
                    if (isGrounded && rig.velocity.x < 0.1)
                        changeAnim(true, 1f, "RUN");
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.localScale = new Vector2(playerScale, playerScale);
                    rig.velocity = new Vector3(moveSpeed, rig.velocity.y, 0);
                    if (isGrounded&&rig.velocity.x<0.1)
                        changeAnim(true, 1f, "RUN");
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    rig.velocity = new Vector2(rig.velocity.x, -downSpeed);
                    if(rig.velocity.y>0)
                    changeAnim(true, 1f, "WARF");
                }

                if (Input.GetKeyDown(KeyCode.Space) && jumpCounter <= jumpConditioner)
                {
                    //if (rig.velocity.y < 0)
                    rig.velocity = new Vector2(rig.velocity.x, 0);
                    rig.velocity += new Vector2(0, jumpHeight);
                    changeAnim(false, 1f, "JUMP");
                    AudioManager.instance.jump.Play();
                }
            }
           
        }
    }

    public void GameOver()
    {
        StartCoroutine(GameOverCoroutine());
    }
    IEnumerator GameOverCoroutine()
    {
        isEnable = false;
        changeAnim(false, 1f, "DEAD");
        yield return new WaitForSeconds(3f);
        if(PlayerPrefs.GetInt("HighScore")<DayManager.instance.currentScore)
        {
            PlayerPrefs.SetInt("HighScore", DayManager.instance.currentScore);
        }
        SceneManager.LoadScene(0);
    }
    public float stunTime = 2f;

    public void GoStun()
    {
        StartCoroutine(stunned());
    }
    public IEnumerator stunned()
    {
       isEnable = false;
        changeAnim(true, 1f, "SLEEP");
        AudioManager.instance.stunned.Play();
        yield return new WaitForSeconds(stunTime);
        isEnable = true;
    }
    public void changeAnim(bool _isloop, float _timescale, string aniName)
    {
        myAnim.loop = _isloop;
        myAnim.timeScale = _timescale;
        myAnim.AnimationName = aniName;
    }
}
