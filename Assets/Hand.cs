using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Hand : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    private Rigidbody rb;


    //Time
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    private float nextActionTimeHalf = 0.0f;
    public float periodHalf = 0.01f;
    //Tracker
    private Vector3 posVRPN;
    private float x;
    private float y;
    private float z;
    private Queue<Vector3> bufferTracker;
    private int tamBuffer = 40;
    // Movement
    private float minArmDistanceZ = 0.05f;
    private float maxArmDistanceZ = 1.9f;
    private bool moveArmZ = false;
    private int dirArmZ = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
         GetComponent<MeshRenderer>().material.SetColor("_Color", Color.black);
        tag = "P1";
        bufferTracker = new Queue<Vector3>();

    }

    void Update()
    {


        if (Time.time > nextActionTimeHalf)
        {
            nextActionTimeHalf += periodHalf;
            InputDataTracker("Tracker0@10.3.137.218");
            move();
        }

       






    }


    void move()
    {
        float moveHorizontal = 0.0f;
        float moveForward = 0.0f;
        float moveVertical = 0.0f;
        ////////////////////////////


        dirArmZ = 0;
        moveArmZ = false;
        int i = 1;
        if (bufferTracker.Count >= tamBuffer)
        {
            while (!moveArmZ && i < tamBuffer - 1)
            {
                float dif = Mathf.Abs(bufferTracker.ElementAt(tamBuffer - 1).magnitude - bufferTracker.ElementAt(tamBuffer - i - 1).magnitude);
                if (dif >= minArmDistanceZ)
                {
                    moveArmZ = true;
                    Vector3 m = (bufferTracker.ElementAt(tamBuffer - 1) - bufferTracker.ElementAt(tamBuffer - i - 1));
                    m /= m.magnitude;

                    rb.velocity = m * speed;
                    Debug.Log(rb.velocity);
                }
                else
                {

                    rb.velocity *= 0;
                }
                i++;
            }
        }

            ///////////////////////////

           /* if (Input.GetKey(KeyCode.W))
            {
                moveForward = 0.5f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                moveForward = -1.0f;

            }
            else if (Input.GetKey(KeyCode.A))
            {
                moveHorizontal = -1.0f;

            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveHorizontal = 1.0f;

            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                moveVertical = 1.0f;

            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                moveVertical = -1.0f;

            }


            Vector3 movement = new Vector3(moveHorizontal, moveVertical, moveForward);
            rb.velocity = movement * speed;*/
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", Color.yellow);
    }

    private void OnCollisionStay(Collision collision)
    {
        if( collision.gameObject.tag == "W")
        {

            if(tag == "P1")
            {
                collision.gameObject.tag = "X";
                collision.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
                tag = "P2";
                transform.position = new Vector3(0, 0, 0);

            }
            else
            {
                collision.gameObject.tag = "O";
                collision.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                tag = "P1";
                transform.position = new Vector3(0, 0, 0);


            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", Color.black);

    }


    void InputDataTracker(string address)
    {
        posVRPN = VRPN.vrpnTrackerPos(address, 3);

        x = 1 * posVRPN.x;
        y = -1 * posVRPN.z;
        z = -1 * posVRPN.y;

        Vector3 qVector = new Vector3(x, y, z);
        bufferTracker.Enqueue(qVector);
        if (bufferTracker.Count > tamBuffer)
        {
            bufferTracker.Dequeue();
        }
    }

    // Update is called once per frame
    /* void Update()
     {

         if (Input.GetKey(KeyCode.W))
         {
             transform.position += new Vector3(0, 0, 0.5f);

         }
         else if (Input.GetKey(KeyCode.S))
         {
             transform.position += new Vector3(0, 0, -0.5f);

         }
         else if (Input.GetKey(KeyCode.A))
         {
             transform.position += new Vector3(-0.5f, 0, 0);

         }
         else if (Input.GetKey(KeyCode.D))
         {
             transform.position += new Vector3(0.5f, 0, 0);

         }
         else if (Input.GetKey(KeyCode.UpArrow))
         {
             transform.position += new Vector3(0, 0.5f, 0);

         }
         else if (Input.GetKey(KeyCode.DownArrow))
         {
             transform.position += new Vector3(0, -0.5f, 0);

         }

     }*/
}
