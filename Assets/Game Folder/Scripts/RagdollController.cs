using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{

    void Start()
    {
        GetRigidBodies(true);
        GetColliders(false);
        
    }

    public void GetRigidBodies(bool state)
    {
        Rigidbody[] body = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody childrensBodies in body)
        {
            childrensBodies.isKinematic = state;
        }
    }

    public void GetColliders(bool state)
    {
        
        CapsuleCollider[] colliders = GetComponentsInChildren<CapsuleCollider>();
        foreach(CapsuleCollider childrensColliders in colliders)
        {
            childrensColliders.enabled = state;
        }
        
    }
}
