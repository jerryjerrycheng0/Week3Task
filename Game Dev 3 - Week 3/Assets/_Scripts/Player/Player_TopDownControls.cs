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

        public Player_ArrowData[] arrowDataArray; // Array of arrow types
        private int currentArrowIndex = 0;

        // Event for switching arrow type
        public delegate void ArrowTypeSwitched(Player_ArrowData newArrowData);
        public static event ArrowTypeSwitched OnArrowTypeSwitched;

        private void Start()
        {
            playerRigidBody = GetComponent<Rigidbody2D>();
            originalSpeed = movementSpeed;

            // Initialize arrow type if available
            if (arrowDataArray.Length > 0)
            {
                currentArrowIndex = 0;
                NotifyArrowTypeChange();
            }
            else
            {
                Debug.LogWarning("No arrow types assigned to Player_TopDownControls!");
            }
        }

        void Update()
        {
            GetInputValues();

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

        private void SwitchArrowType()
        {
            currentArrowIndex = (currentArrowIndex + 1) % arrowDataArray.Length;
            NotifyArrowTypeChange();
        }

        private void NotifyArrowTypeChange()
        {
            Player_ArrowData currentArrowData = arrowDataArray[currentArrowIndex];
            OnArrowTypeSwitched?.Invoke(currentArrowData);
            Debug.Log("Switched to arrow type: " + currentArrowData.arrowType);
        }

        IEnumerator DashRoll()
        {
            yield return new WaitForSeconds(dashDuration);
            amIDashing = false;
        }
    }
}
