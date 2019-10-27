using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private float speed;
    private GameController gameController;
    private AudioSource bgm;

    public AudioSource defaultsound;
    //public AudioSource fastersound;
    public AudioSource crash;
    // Start is called before the first frame update
    void Start()
    {
        gameController = Singleton<GameController>.Instance;
        bgm = defaultsound;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.IsStarted && !bgm.isPlaying)
        {
            bgm.Play();
        }
       // speed = gameController.Speed;

        //if (speed > 10)
       // {        
          //  bgm = fastersound;
       // }
    }

    void PlayCrash()
    {
        crash.Play();
    }
}
