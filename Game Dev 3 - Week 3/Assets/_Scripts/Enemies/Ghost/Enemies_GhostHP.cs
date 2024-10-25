using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevWithMarco.Player;

namespace GameDevWithMarco.Enemies
{
    public class Enemies_GhostHP : MonoBehaviour
    {
        public int ghostHP = 20;
        public bool isDead = false;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Check if the colliding object is an arrow
            if (collision.gameObject.CompareTag("Arrows"))
            {

                    TakeDamage(Random.Range(2, 10));
            }
        }

        // Method to apply damage to the ghost
        private void TakeDamage(int damage)
        {
            ghostHP -= damage;

            // Check if ghostHP is less than or equal to 0
            if (ghostHP <= 0)
            {
                Die();
            }
        }

        // Method to handle ghost's death
        private void Die()
        {
            gameObject.SetActive(false);
            isDead = true;
        }
        public void Revive()
        {
            ghostHP = 20;
            gameObject.SetActive(true);
            isDead = false;
            Debug.Log("Ghosts are back");
        }
    }
}
