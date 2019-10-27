using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray r = new Ray(transform.position, -transform.up);
        GetComponent<Collider>().Raycast(r, out hit, Mathf.Infinity);
        Debug.Log(GetComponent<Collider>().Raycast(r, out hit, Mathf.Infinity));
        if (Physics.Raycast(r, out hit, Mathf.Infinity)) {
            Debug.Log("hit");
            float rotation = Vector3.Angle(transform.up, hit.normal);
            transform.Rotate(transform.right, rotation);
        }
    }
}
