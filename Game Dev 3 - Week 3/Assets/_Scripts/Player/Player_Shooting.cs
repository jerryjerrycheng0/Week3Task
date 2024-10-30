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

        private AudioSource audioSource; //Arrow sound
        private float currentArrowPitch = 1.0f;

        private void OnEnable()
        {
            Player_TopDownControls.OnArrowTypeSwitched += UpdateArrowData; //Switches arrow types
        }

        private void OnDisable()
        {
            Player_TopDownControls.OnArrowTypeSwitched -= UpdateArrowData;
        }

        private void Start()
        {
            if (currentArrowGameobject == null) //Failsafe in case nothing is assigned
            {
                Debug.LogWarning("No arrow data set in Player_Shooting!");
            }
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = arrowSound;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                ShootArrow(); //Shoots arrows
            }
        }

        private void UpdateArrowData(Player_ArrowData newArrowData)
        {
            currentArrowGameobject = newArrowData.arrowObject; //Refernces the arrow object
            projectileForce = newArrowData.arrowForce; //References the arrow speed
            crossbowDamage = newArrowData.arrowDamage; //References the arrow damage
            currentArrowPitch = newArrowData.pitch; //Set pitch based on the arrow data

            Debug.Log("Updated Player_Shooting with arrow type: " + newArrowData.arrowType); //Keeping in track of which arrow is currently being used
        }

        void ShootArrow()
        {
            GameObject projectile = Instantiate(currentArrowGameobject, tipOfTheCrossbow.position, crossbowSprites.transform.rotation);
            Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();
            projectileRigidbody.AddForce(tipOfTheCrossbow.right * projectileForce);

            //Play the arrow sound with the appropriate pitch
            if (audioSource != null && arrowSound != null)
            {
                audioSource.pitch = currentArrowPitch;
                audioSource.Play();
            }
        }
    }
}
