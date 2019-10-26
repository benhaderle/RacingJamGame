using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameController gameController;
    public Button buttonStart;
    public Button buttonRestart;
    public Text textGameOver;
    public Text textTime;
    public Text textDistance;


    void gameStart()
    {
        Debug.Log("Button clicked: gameStart()");
        //buttonStart.setActive(false);
        //buttonRestart.setActive(true);
        gameController.gameStart();
        //TODO: Show/Hide
    }
    void gameRestart()
    {
        Debug.Log("Button clicked: gameRestart()");
        //buttonStart.setActive(true);
        //buttonRestart.setActive(false);
        gameController.gameRestart();
        //TODO: Show/Hide
    }
    public void showGameOverText()
    {
        textGameOver.text = "test gameOver text";
    }

    // Start is called before the first frame update
    void Start()
    {
        //Button btn = buttonStart.GetComponent<Button>();
        //buttonStart.GetComponent<Button>().onClick.AddListener(gameStart);
        //buttonRestart.GetComponent<Button>().onClick.AddListener(gameRestart);
        buttonStart.onClick.AddListener(gameStart);
        buttonRestart.onClick.AddListener(gameRestart);
    }

    // Update is called once per frame
    void Update()
    {
        textTime.text = "Time: " + gameController.GameTime;
        textDistance.text = "Distance: " + gameController.Distance;
    }
}
