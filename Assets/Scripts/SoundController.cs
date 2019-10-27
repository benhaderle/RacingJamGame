using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private float speed;
    private GameController gameController;

    public float SoundThreshold1;
    public float SoundThreshold2;

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

        if ( Mathf.Abs(SoundThreshold1) > 1e-6 && speed >= SoundThreshold1)
        {        
            bgm.pitch = 1.25f;
        } else if (Mathf.Abs(SoundThreshold2) > 1e-6 && speed >= SoundThreshold2)
        {
            bgm.pitch = 1.5f;
        } else
        {
            bgm.pitch = 1.0f;
        }
    }

    public void PlayCrash()
    {
        crash.Play();
    }

    public void StopBGM()
    {
        bgm.Stop();
    }
}
