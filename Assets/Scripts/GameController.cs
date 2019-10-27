using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public UIController uiController;
    public string playerName = "PlayerName";
    public float acceleration = 0.001f;

    private float gameTime = 0.0f;
    public float GameTime
    {
        get { return gameTime; }
    }
    private float distance = 0.0f;
    public float Distance
    {
        get { return distance; }
    }
    private float speed = 0.0f;
    public float Speed
    {
        get { return speed; }
    }

    private bool isStarted = false;
    public bool IsStarted
    {
        get { return isStarted; }
    }


    void Start()
    {

    }

    void Update()
    {
        if (isStarted)
        {
            gameTime += Time.deltaTime;
            speed += acceleration;

            distance += Time.deltaTime * speed;
        }
    }

    public void GameStart()
    {
        Debug.Log("GameController: gameStart()");

        isStarted = true;
        gameTime = 0;
        distance = 0;

    }

    public void GameRestart()
    {
        Debug.Log("GameController: gameRestart()");
    }

    public void GameOver()
    {
        Debug.Log("GameController: gameOver()");
        uiController.GameOver();

        isStarted = false;
    }
}

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindObjectOfType(typeof(T));
                if (instance == null)
                {
                    Debug.LogError("An instance of " + typeof(T) + " is needed in the scene, but there is none.");
                }
            }
            return instance;
        }
    }
}