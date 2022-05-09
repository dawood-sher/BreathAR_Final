using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Joystick joystic;
    public float speed = 10;
    private Vector3 velocityVector = Vector3.zero;  //initial velocity
    //public float maxVelocityChange = 50f;
    private Rigidbody playerRb;
    Vector3 myForward;
    Vector3 myRight;



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        myForward = new Vector3(0.5f,0f,0.5f);
        myRight = new Vector3(-0.5f, 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
        //Taking joystic inputs
        float _xMovementInput = joystic.Horizontal;
        float _zMovementInput = joystic.Vertical;

        //Calculating velocity vectors
        Vector3 _movementHorizontal = myForward * _xMovementInput;
        Vector3 _movementVertical =  myRight *_zMovementInput;
        
        //calculating final movemnt velocity vector

        Vector3 _movmentVelocityVector = (_movementHorizontal + _movementVertical).normalized * speed;

        // Apply Movement

        Move(_movmentVelocityVector);
            
        
    }


    void Move(Vector3 movementVelocityVector)
    {
        velocityVector = movementVelocityVector;
    }


    private void FixedUpdate()
    {
        
        if (velocityVector != Vector3.zero)
        {
            // get rigidbody,s current velocity
            Vector3 velocity = playerRb.velocity;
            Vector3 velocityChange = (velocityVector - velocity);

            // Apply a force by the amount of velocity change to reach the target velocity
            // clamp funtion keeps the value between two values max and min
           // velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            // velocityChange.z = 
           // velocityChange.y =0.05f;
            // velocityChange.z = 0.1f;

            playerRb.AddForce(velocityChange , ForceMode.VelocityChange);





        }

    }
}
