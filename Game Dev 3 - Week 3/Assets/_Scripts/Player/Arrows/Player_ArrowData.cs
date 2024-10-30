using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevWithMarco.Player
{
    [CreateAssetMenu(fileName = "ArrowData", menuName = "Scriptable Objects/ArrowData")]
    public class Player_ArrowData : ScriptableObject
    {
        public GameObject arrowObject; //appearance of arrows
        public float arrowForce; //the speed of arrows
        public int arrowDamage; //the damage of arrows

        public enum ArrowType
        {
            Curve, //curvy, slow and low damage arrows
            Straight, //straight, fast but medium damage arrows
            Explosive //explosive, slow but high damage arrows
        }

        public ArrowType arrowType;
        public float pitch = 1.0f; //Default pitch value, to keep each arrows unique
    }
}
