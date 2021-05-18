using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    private SwerveInputSystem swerveInputSystem;
    [SerializeField]
    private float swerveSpeed = 0.5f;
    [SerializeField]
    private float maxSwerveAmount = 1f;
    UIManager uIManager;

    private void Awake()
    {
        swerveInputSystem = GetComponent<SwerveInputSystem>();
    }
    private void Start()
    {
        uIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    private void Update()
    {
        if (uIManager.PanelOff==true)
        {
            SwerveMovementSystem();
        }
    }

    private void SwerveMovementSystem()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * swerveInputSystem.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmount, 0, 0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.07f, 1.07f),0,transform.position.z);
    }
}
