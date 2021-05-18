using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveInputSystem : MonoBehaviour
{
    public float MoveFactorX => moveFactorX;

    private float lastFrameFingerPositionX;
    private float moveFactorX;
    private bool swipeOn = false;
    public bool SwipeOn { get { return swipeOn; } }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
        }

        else if (Input.GetMouseButton(0))
        {
            
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
            if (moveFactorX>0)
            {
                swipeOn = true;
            }
        }

        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
        }
    }
}
