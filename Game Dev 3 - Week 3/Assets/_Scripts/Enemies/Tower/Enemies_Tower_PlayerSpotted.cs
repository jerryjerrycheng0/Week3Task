using GameDevWithMarco.ObserverPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevWithMarco.Enemies
{
    public class Enemies_Tower_PlayerSpotted : MonoBehaviour
    {
        [SerializeField] GameEvent playerSpotted;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //If the player enters the collider, the spotted event is raised!
            if (collision.gameObject.tag == "Player")
            {
                playerSpotted?.Raise();
            }
        }
    }
}
