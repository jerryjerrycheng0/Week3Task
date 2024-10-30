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
        public AudioClip arrowSound;

        private AudioSource audioSource; // AudioSource to play arrow sound
        private float currentArrowPitch = 1.0f; // Default pitch value

        private void OnEnable()
        {
            Player_TopDownControls.OnArrowTypeSwitched += UpdateArrowData;
        }

        private void OnDisable()
        {
            Player_TopDownControls.OnArrowTypeSwitched -= UpdateArrowData;
        }

        private void Start()
        {
            if (currentArrowGameobject == null)
            {
                Debug.LogWarning("No arrow data set in Player_Shooting!");
            }

            // Initialize AudioSource component
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = arrowSound;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ShootArrow();
            }
        }

        private void UpdateArrowData(Player_ArrowData newArrowData)
        {
            currentArrowGameobject = newArrowData.arrowObject;
            projectileForce = newArrowData.arrowForce;
            crossbowDamage = newArrowData.arrowDamage;
            currentArrowPitch = newArrowData.pitch; // Set pitch based on the arrow data

            Debug.Log("Updated Player_Shooting with arrow type: " + newArrowData.arrowType);
        }

        void ShootArrow()
        {
            GameObject projectile = Instantiate(currentArrowGameobject, tipOfTheCrossbow.position, crossbowSprites.transform.rotation);
            Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
            projectileRigidbody.AddForce(tipOfTheCrossbow.right * projectileForce);

            // Play the arrow sound with the appropriate pitch
            if (audioSource != null && arrowSound != null)
            {
                audioSource.pitch = currentArrowPitch;
                audioSource.Play();
            }
        }
    }
}
