using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Arrow_Logic : MonoBehaviour
{
    //To store the prefab of the broken arrow
    public GameObject brokenArrow;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Will instantiate the broken arrow prefab
        Instantiate(brokenArrow, transform.position, Quaternion.identity);
        //Will destroy the game object this script is attached to
        Destroy(gameObject);                                                
    }
}
