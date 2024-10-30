using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevWithMarco.Player;
using Pathfinding;

namespace GameDevWithMarco.Enemies
{
    public class Enemies_GhostHP : MonoBehaviour
    {
        public int ghostHP = 20;
        public bool isDead = false;
        public bool readyToRevive = false;
        public Player_Shooting playerShooting;
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] Animator animExclam;
        private Collider2D ghostCollider;
        AIDestinationSetter destinationSetter;
        public AudioSource ghostOof;

        public AudioSource ghostDed;
        


        public void Start()
        {
            playerShooting = FindObjectOfType<Player_Shooting>();
            ghostCollider = GetComponent<Collider2D>();
            destinationSetter = GetComponent<AIDestinationSetter>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Arrows"))
            {
                TakeDamage(playerShooting.crossbowDamage); //takes damage according to the Player Shooting script's output
            }
        }

        // Method to apply damage to the ghost
        private void TakeDamage(int damage)
        {
            ghostHP -= damage;

            if (ghostHP <= 0)
            {
                Die();
            }
            if (ghostHP > 0)
            {
                ghostOof.Play(); //Ensures this sound only plays when taking damage and not when dead
            }
        }

        // Method to handle ghost's death
        private void Die()
        {
            //Disables everything so the revive method would work properly (deactivating the whole thing doesn't work)
            spriteRenderer.enabled = false;
            ghostCollider.enabled = false;
            animExclam.enabled = false;
            isDead = true;
            readyToRevive = true;
            destinationSetter.target = transform;
            ghostDed.Play();
        }

        // Revive the ghost and reset its health
        public void Revive()
        {
            //Revives all ghosts
            if (readyToRevive == true)
            {
                ghostHP = 20;
                spriteRenderer.enabled = true;
                ghostCollider.enabled = true;
                animExclam.enabled = true;
                isDead = false;
                readyToRevive = false;
            }
        }
    }
}
