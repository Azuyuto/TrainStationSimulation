using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonController : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 2;
    Vector3 force;
    public bool reverse = false;



    void Start()
    {
        force = Vector3.left * speed;

        if (reverse)
        {
            ReverseVector();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

        Move();
    }

    void Move()
    {
        //transform.GetComponent<Rigidbody>().AddForce(force);
        transform.GetComponent<Rigidbody>().velocity = force;
    }

    void ReverseVector()
    {
        force = -force;
        direction.Set(-direction.x, direction.y, direction.z);
    }
}
