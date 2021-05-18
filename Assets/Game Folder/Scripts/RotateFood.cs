using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFood : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 1.0f;

    private void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}
