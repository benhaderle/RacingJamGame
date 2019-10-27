using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMove : MonoBehaviour
{
    private Rigidbody cart;
    private Vector3 pos;
    public float speed = 0.000000001f;
    public float turnspeed = 0.0000001f;
    public float speedFactor = 1f;
    public float fallspeed = 0.1f;
    public float fallheight = 0.2f;

    private RaycastHit track;

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

    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;


        
        if (Physics.Raycast(transform.position, -transform.up, out track, 20))
        {
            //Debug.Log("track" + track.normal);
            //Debug.Log("body" + transform.up);

            Debug.Log(track.distance);
            


            Vector3 cproduct = Vector3.Cross(track.normal, transform.forward).normalized;

            if (Input.GetKey("a"))
            {

                pos += cproduct * turnspeed * Time.deltaTime *(-1);

            }
            if (Input.GetKey("d"))
            {

                pos += cproduct * turnspeed * Time.deltaTime;

            }



            if (transform.up != track.normal)
            {
                //Debug.Log("need to rotate");
                transform.rotation = Quaternion.FromToRotation(Vector3.up, track.normal);
            }

            float forwardspeed = speed * Time.deltaTime;
            pos += transform.forward * forwardspeed;

            if (track.distance > 0.2)
            {
                pos += -1 * transform.up * fallspeed;
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
