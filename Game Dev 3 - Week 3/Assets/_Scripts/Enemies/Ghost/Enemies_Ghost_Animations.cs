using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_Ghost_Animations : MonoBehaviour
{
    Animator anim;
    Enemies_Ghost_Movement movementScript;


    void Start()
    {
        anim = GetComponent<Animator>();
        movementScript = GetComponentInParent<Enemies_Ghost_Movement>();
    }

    public void PlayAlertedAnimations()
    {
        anim.SetTrigger("alerted");
    }

    public void PlayChaseAnimation()
    {
        anim.SetBool("isChasing", true);
    }

    public void PlayIdleAnimation()
    {
        anim.SetBool("isChasing", false);
    }
}
