using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
 
    [SerializeField]
    private Move move;
    [SerializeField]
    private SwerveMovement swerveMovement;
    [SerializeField]
    private RagdollController ragdollController;
    private CameraFollow cameraFollow;
    private RotateFood rotateFood;

    private void Start()
    {
        ragdollController = GetComponent<RagdollController>();
        cameraFollow = FindObjectOfType<CameraFollow>();
        rotateFood = FindObjectOfType<RotateFood>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag=="Obstacle")
        {
            GetComponent<Animator>().enabled = false;
            ragdollController.GetRigidBodies(false);
            ragdollController.GetColliders(true);
            //GetComponent<BoxCollider>().enabled = false;
            move.enabled = false;
            swerveMovement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
            cameraFollow.enabled = false;
            rotateFood.enabled = false;
        }
    }
}
