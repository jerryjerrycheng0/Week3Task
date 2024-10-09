using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemies_Ghost_Movement : MonoBehaviour
{
    /// <summary>
    /// Main logic comes from this video: https://www.youtube.com/watch?v=jvtFUfJ6CP8
    /// </summary>

    //Variables for pathfinding
    AIDestinationSetter destinationSetter;
    Transform playerTransform;
    AIPath aiPathComponentVariable;
    public float lostTrackDistance;

    //Variables for the animation
    Enemies_Ghost_Animations ghostAnimationScript;


    void Start()
    {
        VariablesSetter();
    }

    private void Update()
    {        
        CheckIfPlayerIsInRange();
    }
    
    private void VariablesSetter()
    {
        destinationSetter       = GetComponent<AIDestinationSetter>();
        playerTransform         = GameObject.FindGameObjectWithTag("Player").transform;
        ghostAnimationScript    = GetComponentInChildren<Enemies_Ghost_Animations>();
        aiPathComponentVariable = GetComponent<AIPath>();
    }

    //This method is here just so I can execute it in response to the raise event, since I cannot
    //execute coroutines in the inspector...
    public void WaitThenChaseCoroutineExecuter()
    {
        StartCoroutine(WaitThenStartChasing());                     
    }

    private IEnumerator WaitThenStartChasing()
    {
        //Gets a random float value between 2 numbers
        float randomChaseStartTime = Random.Range(0.3f, 2f);
        //Stops execution of code for a set amount of time
        yield return new WaitForSeconds(randomChaseStartTime);
        //Starts to chase the player 
        ChaseThePlayer();
        //Plays the chase animation
        ghostAnimationScript.PlayChaseAnimation();                 
    }

    public void ChaseThePlayer()
    {
        //Sets the pathfinding destination to be the player
        destinationSetter.target = playerTransform;     
    }

    public void StopChasingThePlayer()
    {
        Debug.Log("Stop Chasin the Player!");
        //Stops ai from moving
        destinationSetter.target = transform;       
    }

    private void CheckIfPlayerIsInRange()
    {
        //Checks if the remaining distance on the path is greater than the lostTrackDistance value
        if (aiPathComponentVariable.remainingDistance > lostTrackDistance)
        {
            //The ghost go idle
            ghostAnimationScript.PlayIdleAnimation();
            //Stops to chase the player
            StopChasingThePlayer();
        }
    }
    
}
