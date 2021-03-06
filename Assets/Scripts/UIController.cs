﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button buttonStart;
    public Button buttonRestart;

    public Text textTime;
    public Text textDistance;
    public Text textSpeed;

    public Text textGameOver;
    public Text textGameOverTime;
    public Text textGameOverDistance;

    public RawImage rawImageGameTitle;

    public Button buttonTestGameOver;

    private GameController gameController;

    void GameStart()
    {
        Debug.Log("Button clicked: UIController.GameStart()");
        gameController.GameStart();

        buttonStart.gameObject.SetActive(false);
        //buttonRestart.gameObject.SetActive(true);

        textTime.gameObject.SetActive(true);
        textDistance.gameObject.SetActive(true);
        textSpeed.gameObject.SetActive(true);

        textGameOver.gameObject.SetActive(false);
        textGameOverTime.gameObject.SetActive(false);
        textGameOverDistance.gameObject.SetActive(false);

        rawImageGameTitle.gameObject.SetActive(false);
    }
    void GameRestart()
    {
        Debug.Log("Button clicked: UIController.GameRestart()");
        gameController.GameRestart();

        buttonStart.gameObject.SetActive(true);
        buttonRestart.gameObject.SetActive(false);

        textTime.gameObject.SetActive(false);
        textDistance.gameObject.SetActive(false);
        textSpeed.gameObject.SetActive(false);

        textGameOver.gameObject.SetActive(false);
        textGameOverTime.gameObject.SetActive(false);
        textGameOverDistance.gameObject.SetActive(false);

        rawImageGameTitle.gameObject.SetActive(true);
    }
    public void GameOver()
    {
        Debug.Log("UIController.GameOver()");

        textGameOver.text = "You Crashed!! :b";
        textGameOverTime.text = "Time: " + string.Format("{0:F}", gameController.GameTime);
        textGameOverDistance.text = "Dist: " + string.Format("{0:F}", gameController.Distance);

        textTime.gameObject.SetActive(false);
        textDistance.gameObject.SetActive(false);
        textSpeed.gameObject.SetActive(false);

        textGameOver.gameObject.SetActive(true);
        textGameOverTime.gameObject.SetActive(true);
        textGameOverDistance.gameObject.SetActive(true);

        buttonStart.gameObject.SetActive(false);
        buttonRestart.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameController = Singleton<GameController>.Instance;

        buttonStart.onClick.AddListener(GameStart);
        buttonRestart.onClick.AddListener(GameRestart);
        buttonTestGameOver.onClick.AddListener(gameController.GameOver);

        textTime.gameObject.SetActive(false);
        textDistance.gameObject.SetActive(false);
        textSpeed.gameObject.SetActive(false);

        buttonRestart.gameObject.SetActive(false);
        textGameOver.gameObject.SetActive(false);
        textGameOverTime.gameObject.SetActive(false);
        textGameOverDistance.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.IsStarted) 
        {
            textTime.text = "Time: " + string.Format("{0:F}", gameController.GameTime);
            textDistance.text = "Dist: " + string.Format("{0:F}", gameController.Distance);
            textSpeed.text = "Speed: " + string.Format("{0:F}", gameController.Speed);
        }
    }
}
