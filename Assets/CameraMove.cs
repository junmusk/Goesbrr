using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float velocity = 15;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement();
        
    }

    void FixedUpdate()
    {

    }

    private void movement() {

        if (Input.GetKeyDown(KeyCode.A))
        {
            myRigidBody.velocity += Vector2.left * velocity;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            myRigidBody.velocity += Vector2.right * velocity;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            myRigidBody.velocity += Vector2.up * velocity;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            myRigidBody.velocity += Vector2.down * velocity;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            myRigidBody.velocity += Vector2.left * -velocity;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            myRigidBody.velocity += Vector2.right * -velocity;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            myRigidBody.velocity += Vector2.up * -velocity;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            myRigidBody.velocity += Vector2.down * -velocity;
        }
    }
}
