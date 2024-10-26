using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevWithMarco.Player
{
    public class Player_Shooting : MonoBehaviour
    {
        [Header("Arrow Settings")]
        public GameObject currentArrowGameobject;

        [Header("Instantiation Related Variables")]
        public Transform tipOfTheCrossbow;
        public float projectileForce;
        public GameObject crossbowSprites;

        public int crossbowDamage;

        private void Start()
        {
            if (currentArrowGameobject == null)
            {
                Debug.LogWarning("No arrow data set in Player_Shooting!");
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ShootArrow();
            }
        }

        // Method to update arrow data from Player_ArrowData
        public void SetArrowData(Player_ArrowData newArrowData)
        {
            currentArrowGameobject = newArrowData.arrowObject;
            projectileForce = newArrowData.arrowForce;
            crossbowDamage = newArrowData.arrowDamage;
            Debug.Log("Updated Player_Shooting with arrow type: " + newArrowData.arrowType);
        }

        //Shoots arrows
        void ShootArrow()
        {
            GameObject projectile = Instantiate(currentArrowGameobject, tipOfTheCrossbow.position, crossbowSprites.transform.rotation);
            Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
            projectileRigidbody.AddForce(tipOfTheCrossbow.right * projectileForce);
        }
    }
}
