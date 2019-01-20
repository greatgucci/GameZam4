using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioSource drink;
    public AudioSource jump;
    public AudioSource stunned;
    public AudioSource bgm;

    public static AudioManager instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        bgm.Play();
        bgm.loop = true;
    }
}
