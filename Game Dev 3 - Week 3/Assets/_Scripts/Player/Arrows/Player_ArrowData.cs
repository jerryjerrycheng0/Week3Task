using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevWithMarco.Player
{
    [CreateAssetMenu(fileName = "ArrowData", menuName = "Scriptable Objects/ArrowData")]
    public class Player_ArrowData : ScriptableObject
    {
        public GameObject arrowObject;
        public float arrowForce;
        public int arrowDamage;
        public enum ArrowType
        {
            Curve,
            Straight,
            Explosive
        }
        public ArrowType arrowType;
    }
}
