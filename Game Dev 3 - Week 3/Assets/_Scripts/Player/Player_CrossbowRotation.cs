using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CrossbowRotation : MonoBehaviour
{
    //To store the mouse position
    private Vector2 mousePosition;     
    //Will store the angle we need
    private float angle;                
    //RB ref
    private Rigidbody2D crossbowRb;
    //To set what's the target
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the Rigidbody and puts its data into the variable
        crossbowRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the mouse poistion
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);        
    }


    private void FixedUpdate()
    {
        //Those 2 methods are in the FixedUpdate because they deal with Physics
        CrossbowRotation();
        CrossbowPosition();
    }


    void CrossbowRotation()
    {
        //Direction from the mouse position to the crossbow's Rigidbody
        Vector2 lookDirection = mousePosition - crossbowRb.position;
        //Gets the angle between x and y
        angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        //Uses the angle variable to set the rotation
        crossbowRb.rotation = angle;                                                
    }

    void CrossbowPosition()
    {
        //Will set the position of the crossbow. Without it, the crossbow will not follow.
        crossbowRb.position = target.position;         
    }
}
