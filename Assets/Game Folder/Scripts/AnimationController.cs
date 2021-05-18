using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationController : MonoBehaviour
{
    Animator animator;

    const string FUNNY_MOMENT = "Fun";
    string currentState;
    public GameObject confetti;
    public GameObject confettiObject;

    private void OnEnable()
    {
        FinishCollision.triggerAnim += TriggerAnim;
    }

    private void OnDisable()
    {
        FinishCollision.triggerAnim -= TriggerAnim;
    }



    private void Start()
    {
        animator = GetComponent<Animator>();

    }
    public void SetWalkingTrue()
    {
        animator.SetBool("isWalking", true);
    }

    public void SetWalkingFalse()
    {
        animator.SetBool("isWalking", false);
    }

    public void SetFallTrue()
    {
        animator.SetTrigger("Fall");
        animator.SetBool("isWalking", false);
    }

    public void ServeTrigger()
    {
        animator.SetTrigger("Serve");
        //animator.SetBool("isWalking", false);
    }

    public void TriggerAnim(string newState)
    {
        if (currentState == newState) return;

        animator.SetTrigger(FUNNY_MOMENT);

        currentState = newState;
    }

    public IEnumerator Fun()
    {
        yield return new WaitForSeconds(2.5f);
        animator.SetTrigger("Fun");
       // Instantiate(confetti);
    }
}
