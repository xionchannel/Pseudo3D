using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WASDMover : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 1f;
    public float turnAngleSpeed = 1f;

    private Vector3 GroundVec(Vector3 v)
    {
        v.y = 0;
        return v.normalized;
    }
    
    void Update()
    {
        var key = Keyboard.current;
        if (key == null) return;

        float forwardSpeed = 0f;
        if (key.wKey.isPressed)
        {
            forwardSpeed = 1f;
        }
        else if (key.sKey.isPressed)
        {
            forwardSpeed = -1f;
        }
        target.Translate(GroundVec(target.forward) * forwardSpeed * moveSpeed * Time.deltaTime, Space.World);

        float sideSpeed = 0f;
        if (key.dKey.isPressed)
        {
            sideSpeed = 1f;
        }
        else if (key.aKey.isPressed)
        {
            sideSpeed = -1f;
        }
        target.Translate(GroundVec(target.right) * sideSpeed * moveSpeed * Time.deltaTime, Space.World);

        float upSpeed = 0f;
        if (key.upArrowKey.isPressed)
        {
            upSpeed = 1f;
        }
        else if (key.downArrowKey.isPressed)
        {
            upSpeed = -1f;
        }
        target.Translate(Vector3.up * upSpeed * moveSpeed * Time.deltaTime, Space.World);

        float turnSpeed = 0f;
        if (key.rightArrowKey.isPressed)
        {
            turnSpeed = 1f;
        }
        else if (key.leftArrowKey.isPressed)
        {
            turnSpeed = -1f;
        }
        target.Rotate(Vector3.up, turnSpeed * turnAngleSpeed * Time.deltaTime, Space.World);
    }
}
