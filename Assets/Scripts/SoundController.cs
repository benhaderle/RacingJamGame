using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private float speed;
    private GameController gameController;

    public float st1;
    public float st2;

    public AudioSource bgm;
    public AudioSource crash;
    // Start is called before the first frame update
    void Start()
    {
        gameController = Singleton<GameController>.Instance;
        bgm.pitch = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!bgm.isPlaying  && gameController.IsStarted)
        {
            bgm.Play();
        }
        speed = gameController.Speed;

       if (st1!=0 && speed >= st1)
        {        
            bgm.pitch = 1.25f;
        } else if (st2!=0 && speed >= st2)
        {
            bgm.pitch = 1.5f;
        } else
        {
            bgm.pitch = 1.0f;
        }
    }

    void PlayCrash()
    {
        crash.Play();
    }
}
