using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody body;
    [SerializeField]
    public float speed;

    UIManager uIManager;
    SwerveInputSystem ınputSystem;
    AnimationController animationController;


    private void Start()
    {
        body = GetComponent<Rigidbody>();
        animationController = FindObjectOfType<AnimationController>();
        uIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        ınputSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<SwerveInputSystem>();

    }
    void Update()
    {
        if (uIManager.PanelOff == true && ınputSystem.SwipeOn == true)
        {
            animationController.SetWalkingTrue();
            transform.Translate(0, 0, 1*speed*Time.deltaTime);           
        }
    }
}
