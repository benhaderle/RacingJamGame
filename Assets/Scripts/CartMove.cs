using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMove : MonoBehaviour
{
    private Rigidbody cart;
    private Vector3 pos;
    public float speed;
    public float turnspeed;
    public float speedFactor = 1f;
    public float fallspeed = 0.1f;
    public float fallheight = 0.2f;

    private RaycastHit track;

    private bool lockCursor = true;
    public AudioSource engineSound;

    TrackPiece lastPiece;
    float endAngleRemaing = 0;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hittag");
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

        if (Input.GetKey(KeyCode.A)) {

            pos += -transform.right * turnspeed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.D)) {

            pos += transform.right * turnspeed * Time.deltaTime;

        }

        if (Physics.Raycast(pos, -transform.up, out track, 10))
        {

            pos = track.point + track.normal.normalized * 1f;

            cart.rotation = Quaternion.FromToRotation(Vector3.up, track.normal.normalized);
           /* Vector3 rot = transform.rotation.eulerAngles;
            if (lastPiece == null || lastPiece != track.collider.transform.parent.GetComponent<TrackPiece>()) {
                ;

                lastPiece = track.collider.transform.parent.GetComponent<TrackPiece>();
                //endAngleRemaing = lastPiece.endRotation.y;
            }

            if (lastPiece != null) {
                 //* Quaternion.FromToRotation(Vector3.forward, lastPiece.endRotation);
            }
            

            Debug.Log(transform.forward - track.collider.transform.parent.GetComponent<TrackPiece>().endRotation);*/
            //transform.rotation = Quaternion.LookRotation(transform.forward, track.normal.normalized); //Slerp(Quaternion.Euler(Vector3.up), Quaternion.Euler(track.normal), .1f);

            //Debug.Log("track" + track.normal);
            //Debug.Log("body" + transform.up);

            //Debug.Log(track.distance);



            /* Vector3 cproduct = Vector3.Cross(track.normal, transform.forward).normalized;

             if (Input.GetKey("a"))
             {

                 pos += cproduct * turnspeed * Time.deltaTime *(-1);

             }
             if (Input.GetKey("d"))
             {

                 pos += cproduct * turnspeed * Time.deltaTime;

             }*/

            //Debug.Log(Mathf.Abs(transform.up.y) == Mathf.Abs(track.normal.y));
            //Debug.Log(Mathf.Abs(transform.up.z) == Mathf.Abs(track.normal.z));


            /*if (!(Mathf.Abs(transform.up.x) == Mathf.Abs(track.normal.x) && Mathf.Abs(transform.up.y) == Mathf.Abs(track.normal.y) 
                && Mathf.Abs(transform.up.z) == Mathf.Abs(track.normal.z)))
            {
                //Debug.Log("need to rotate");
                transform.rotation = Quaternion.FromToRotation(Vector3.up, track.normal); //Slerp(Quaternion.Euler(Vector3.up), Quaternion.Euler(track.normal), .1f);
            }*/

            // transform.Rotate(transform.forward, turnspeed * Time.deltaTime);
            //transform.Rotate(transform.right, turnspeed * Time.deltaTime);



            //if (track.distance > 0.2)
            //{
            //    pos += -1 * transform.up * fallspeed;
            //}
        }




        float forwardspeed = speed * Time.deltaTime;
        pos += transform.forward * forwardspeed;

        cart.position = pos;
        //CursorLock();

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
