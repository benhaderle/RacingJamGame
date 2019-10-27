using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarStatus : MonoBehaviour
{
    [Header("Speed")]
    public Text textSpeed;

    // private float speed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        textSpeed.text = Singleton<GameController>.Instance.Speed.ToString() + " MPH";
    }
}
