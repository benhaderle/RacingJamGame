using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    private Rigidbody rigid;
    private Vector3 targetVel;
    public int speed = 5;
    private float gravity = 9.8f;
    private float maxVelcoityChange;
    private int exitcode = 0;
    //private Quaternion originalCharRotation;
    //private Quaternion originalCamRotation;
    private Vector3 rot; //x is mouse vertical look, y is our orientation
    public float lookSpeed = 1.5f;

    private bool lockCursor = true;
    public AudioSource footSource;

    void OnTriggerEnter(Collider otherObject)

    {

        print("Just entered the trigger defined by the object " + otherObject.gameObject.name);
        exitcode = 1;

    }


    void OnTriggerExit(Collider otherObject)

    {

        print("Just exited the trigger defined by the object " + otherObject.gameObject.name);
        //Destroy(otherObject.gameObject);

    }

    void OnCollisionEnter(Collision collision)
    {
        //Application.Quit();
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Cube")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("hit");
        }

        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "obs")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            //Application.Quit();
            Debug.Log("hittag");

        }
    }




    private void Start() {
        rigid = gameObject.GetComponent<Rigidbody>();
        rigid.useGravity = true;
        maxVelcoityChange = speed;
        //originalCamRotation = Camera.main.transform.localRotation;
        //originalCharRotation = transform.localRotation;
    }

    private void Update() {
        targetVel = new Vector3(Input.GetAxis("Horizontal"), 0, 1);
        targetVel = transform.TransformDirection(targetVel);
        targetVel *= speed;
        //Susan();
        CursorLock();
        //Footsteps();


    }

    private void FixedUpdate() {
        //<3 U we're gonna apply force here Boo
        Vector3 velocityChange = (targetVel - rigid.velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelcoityChange, maxVelcoityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelcoityChange, maxVelcoityChange);
        velocityChange.y = 0;
        
        rigid.AddForce(velocityChange, ForceMode.VelocityChange);

        rigid.AddForce(new Vector3(0, -gravity * rigid.mass, 0));
    }

    void Susan() {
        rot.y += Input.GetAxis("Mouse X");
        rot.x += -Input.GetAxis("Mouse Y");
        rot.x = Mathf.Clamp(rot.x, -45, 45);
        //Quaternion yQuaternion = Quaternion.AngleAxis(rot.y * lookSpeed, Vector3.up);
        //transform.localRotation = originalCharRotation * yQuaternion;
        //Quaternion xQuaternion = Quaternion.AngleAxis(rot.x * lookSpeed, Vector3.right);
        //Camera.main.transform.localRotation = originalCamRotation * xQuaternion;
    }

    void CursorLock() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            lockCursor = !lockCursor;
        }
        if(lockCursor) {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
        else {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }

    void Footsteps() {
        if(targetVel.magnitude != 0) {
            if (!footSource.isPlaying) {
                footSource.Play();
            }
        }
        else {
            footSource.Pause();
        }
    }



}

