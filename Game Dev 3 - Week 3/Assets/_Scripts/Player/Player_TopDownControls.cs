using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevWithMarco.Player
{
    public class Player_TopDownControls : MonoBehaviour
    {
        private Rigidbody2D playerRigidBody;
        public float movementSpeed = 5f;
        public Vector2 movement;
        public Vector2 lastMoveDirection;

        public float dashMovementSpeed;
        public float dashDuration;
        public float originalSpeed;
        public bool amIDashing = false;

        // Array of arrow types
        public Player_ArrowData[] arrowDataArray;
        private int currentArrowIndex = 0;

        // Reference to Player_Shooting script
        private Player_Shooting playerShooting;

        private void Start()
        {
            playerRigidBody = GetComponent<Rigidbody2D>();
            originalSpeed = movementSpeed;

            // Find the Player_Shooting component
            playerShooting = GetComponent<Player_Shooting>();

            // Initialize arrow type if available
            if (arrowDataArray.Length > 0)
            {
                currentArrowIndex = 0;
                SetCurrentArrowData();
            }
            else
            {
                Debug.LogWarning("No arrow types assigned to Player_TopDownControls!");
            }
        }

        void Update()
        {
            GetInputValues();

            // Check if Left Shift is pressed to switch arrow types
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                SwitchArrowType();
            }
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void GetInputValues()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            if ((moveX == 0 && moveY == 0) && movement.x != 0 || movement.y != 0)
            {
                lastMoveDirection = movement;
            }

            movement = new Vector2(moveX, moveY).normalized;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                amIDashing = true;
                StartCoroutine(DashRoll());
            }
        }

        private void MovePlayer()
        {
            if (amIDashing)
            {
                playerRigidBody.MovePosition(playerRigidBody.position + movement * dashMovementSpeed * Time.fixedDeltaTime);
            }
            else
            {
                playerRigidBody.MovePosition(playerRigidBody.position + movement * movementSpeed * Time.fixedDeltaTime);
            }
        }

        // Switch to the next arrow type and update both Player_TopDownControls and Player_Shooting
        private void SwitchArrowType()
        {
            currentArrowIndex = (currentArrowIndex + 1) % arrowDataArray.Length;
            SetCurrentArrowData();
        }

        // Set the current arrow data in both Player_TopDownControls and Player_Shooting
        private void SetCurrentArrowData()
        {
            // Update the arrow data in this script
            Player_ArrowData currentArrowData = arrowDataArray[currentArrowIndex];

            // Update the Player_Shooting script with the current arrow data
            if (playerShooting != null)
            {
                playerShooting.SetArrowData(currentArrowData);
            }

            Debug.Log("Switched to arrow type: " + currentArrowData.arrowType);
        }

        IEnumerator DashRoll()
        {
            yield return new WaitForSeconds(dashDuration);
            amIDashing = false;
        }
    }
}
