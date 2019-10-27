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
        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 7, -10), .5f); // new Vector3(0, 4, -6);
        //transform.position = car.transform.position - car.transform.forw;
    }
}
