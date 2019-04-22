using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tag = "P1";
    }

    void Update()
    {
        move();
    }


    void move()
    {
        float moveHorizontal = 0.0f;
        float moveForward = 0.0f;
        float moveVertical = 0.0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveForward = 1.0f;
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
        rb.velocity = movement * speed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<MeshRenderer>().material.SetColor("_Color", Color.yellow);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(Input.GetKey(KeyCode.F) && collision.gameObject.tag == "W")
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
        GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);

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
