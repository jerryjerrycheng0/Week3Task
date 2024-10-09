using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_Tower_Animations : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayerHasBeenSpottedAnimation()
    {
        anim.SetTrigger("playerSpotted");
    }
}
