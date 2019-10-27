using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public UIController uiController;
    public string playerName = "PlayerName";
    public float acceleration = 0.2f;

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
    public float Speed {
        get {return speed;}
    }


    void Start()
    {

    }

    void Update()
    {
        gameTime += Time.deltaTime;
        speed += acceleration;

        distance += Time.deltaTime * speed;
    }

    public void gameStart()
    {
        Debug.Log("GameController: gameStart()");
    }

    public void gameRestart()
    {
        Debug.Log("GameController: gameRestart()");
    }

    public void gameOver()
    {
        Debug.Log("GameController: gameOver()");
        uiController.showGameOverText();
    }
}
