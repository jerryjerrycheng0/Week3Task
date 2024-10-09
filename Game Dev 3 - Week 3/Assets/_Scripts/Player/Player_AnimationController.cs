using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AnimationController : MonoBehaviour
{
    //Will store a reference to the Animator
    private Animator animatorVariable;                      
    //Will store a reference to the player top down controls script
    private Player_TopDownControls playerControls;      

    // Start is called before the first frame update
    void Start()
    {
        //Since the animator is on a child game object, I will need to use
        //GetComponenetInChildren<>() to find it
        animatorVariable = GetComponentInChildren<Animator>();
        //Need to use FindObjectOfType because the script I am looking for
        //is not on this game object                                                                                                                                        
        playerControls = FindObjectOfType<Player_TopDownControls>();    
    }

    // Update is called once per frame
    void Update()
    {
        SetSpeedParameter();        
    }

    void SetSpeedParameter()
    {
        //Same as the Gym 2
        animatorVariable.SetFloat("Speed", playerControls.movement.sqrMagnitude);      
    }
}
