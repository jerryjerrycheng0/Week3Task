using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_TopDownControls : MonoBehaviour
{
    /// <summary>
    /// This script controls the movement of the player.
    /// </summary>

    //To store the rigidbody2d of the player, so we can use it
    private Rigidbody2D playerRigidBody;
    //TO set the speed of the player
    public float movementSpeed = 5f;
    //To store the x and y values
    public Vector2 movement;
    //Will be used to store the last move direction, which is useful for animation purposes
    public Vector2 lastMoveDirection;                       
    //Variables for the dash
    public float dashMovementSpeed;                         
    public float dashDuration;
    public float originalSpeed;
    public bool amIDashing = false;
    
    //Built in Methods
    private void Start()
    {
        //Will find the rigidbody2d and store it into the variable
        playerRigidBody = GetComponent<Rigidbody2D>();
        //Sets the speed of the player
        originalSpeed = movementSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        GetInputValues();
    }    

    private void FixedUpdate()
    {
        
        MovePlayer();     

    }


    //Custom Methods
    private void GetInputValues()
    {
        //Will store the movement on the x into our movement variable
        float moveX = Input.GetAxisRaw("Horizontal");
        //Will store the movement on the y into our movement variable
        float moveY = Input.GetAxisRaw("Vertical"); 

       //This if statement is just to store the last move direction
        if ((moveX == 0 && moveY == 0) && movement.x != 0 || movement.y != 0)
        {
            lastMoveDirection = movement;
        }

        //Will normalize the speed to make sure you are not faster when pressing multiple direction
        movement = new Vector2(moveX, moveY).normalized;                 

        //Dashes if we are pressing space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            amIDashing = true;
            StartCoroutine(DashRoll());
        }
    }
    private void MovePlayer()
    {
        if (amIDashing)
        {
            //Same as below, but with the dashMovementSpeed instead. 
            playerRigidBody.MovePosition(playerRigidBody.position + movement * dashMovementSpeed * Time.fixedDeltaTime);
        }
        else
        {
            //Uses the rigid body component to move the position of the player, adding the direction you are pressing
            //multiplied by the speed we want the player to go at, and multiplying it again to Time.fixedDeltatime
            //which will make sure it is "frame independent" which mean that will not be faster if you pc is powerful!
            playerRigidBody.MovePosition(playerRigidBody.position + movement * movementSpeed * Time.fixedDeltaTime);
        }
        
    }


    
    //Dash coroutine
    IEnumerator DashRoll()
    {       
        yield return new WaitForSeconds(dashDuration);
        amIDashing = false;
    }
}

