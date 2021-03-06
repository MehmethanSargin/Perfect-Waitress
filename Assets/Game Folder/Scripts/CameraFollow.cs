using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void Update()
    {
        Vector3 targetPos = player.position + offset;
        targetPos.x = 1.85f;
        transform.position = targetPos;
    }
}
