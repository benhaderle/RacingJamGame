using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMove : MonoBehaviour
{
    private Rigidbody cart;
    private Vector3 DirectionInput;
    private Vector3 pos;
    public float speed = 0.01f;
    public float turnspeed = 0.0000001f;
    public float speedFactor = 10;

    private RaycastHit track;


    public bool grounded;
    private Vector3 posCur;
    private Quaternion rotCur;

    private float gravity = 9.8f;
    private float maxVelcoityChange;
    private Vector3 rot; //x is mouse vertical look, y is our orientation
    public float lookSpeed = 1.5f;
    private bool lockCursor = true;
    public AudioSource engineSound;

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "obs")
        {

            Debug.Log("hittag");
            //do sth.
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cart = gameObject.GetComponent<Rigidbody>();
        cart.useGravity = false;
        maxVelcoityChange = speed*speedFactor;
        //originalCamRotation = Camera.main.transform.localRotation;
        //originalCharRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {



        DirectionInput = new Vector3(Input.GetAxis("Horizontal"), 0, 1);
        DirectionInput = transform.TransformDirection(DirectionInput);
        //DirectionInput *= turnspeed;

        pos = transform.position;
        pos += transform.forward * speed * Time.deltaTime;
        //pos.x += speed * Time.deltaTime;
        pos.z += turnspeed * DirectionInput.z;

        
        if (Physics.Raycast(transform.position, transform.InverseTransformDirection(Vector3.down), out track, 20))
        {
            //transform.rotation = Quaternion.FromToRotation(Vector3.down, track.collider.n);
            Debug.Log("track" + track.normal);
            Debug.Log("body" + transform.up);
            if (transform.up != track.normal)
            {
                Debug.Log("need to rotate");
                transform.rotation = Quaternion.FromToRotation(Vector3.up, track.normal);
            }
        }



        cart.MovePosition(pos);
        CursorLock();

    }

    private void FixedUpdate()
    {
        
    }

    void CursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            lockCursor = !lockCursor;
        }
        if (lockCursor)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }


}
