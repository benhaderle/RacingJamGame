using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(car.transform.position);
        transform.position = car.transform.position + new Vector3(0, 4, -6); ;// new Vector3(0, 4, -6);
    }
}
