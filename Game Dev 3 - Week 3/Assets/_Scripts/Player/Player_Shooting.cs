using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shooting : MonoBehaviour
{
    [Header("Arrow")]
    //This variable will keep track of what game object should the arrow be
    [SerializeField] GameObject currentArrowGameobject;
    
    [Header("Instantiation Related Variables")]
    //To know where we want the arrows to come from
    public Transform tipOfTheCrossbow;
    //Will be used to give force to the projectile
    public float projectileForce;
    //Will need this to access some variables
    public GameObject crossbowSprites;                                 



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootArrow();
        }
    }

   

    void ShootArrow()
    {        
        //Spawns a game object that we have set, at a location we set, with a rotation we set
        //Then it stores it into the projectile local variable for later use
        GameObject projectile = Instantiate(currentArrowGameobject, tipOfTheCrossbow.position, crossbowSprites.transform.rotation);
        //It finds the rigid body of the projectile game object and stores it into a local variables
        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
        //Adds force to the rigidybody of the projectile in order to eject it in the direction we need
        projectileRigidbody.AddForce(tipOfTheCrossbow.right * projectileForce);
    }
}
