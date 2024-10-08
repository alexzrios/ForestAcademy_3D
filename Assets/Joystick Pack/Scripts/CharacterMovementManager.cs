using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementManager : MonoBehaviour
{
    public VariableJoystick joystick;
    public Canvas inputCanvas;
    public bool isJoystick;
    public CharacterController controller;
    public float movementSpeed;
    public float rotationSpeed;
    public Animator playerAnimator;

    
    
    // Start is called before the first frame update
    void Start()
    {
        EnableJoystickInput();
    }

    // Update is called once per frame
    void Update()
    {
        if (isJoystick)
        {
            var movementDirection = new Vector3(joystick.Direction.x, 0.0f, joystick.Direction.y);
            controller.SimpleMove(movementDirection * movementSpeed);

            if (movementDirection.sqrMagnitude <=0)
            {
                playerAnimator.SetBool("run",false);
                return;
            }
            playerAnimator.SetBool("run", true);

            var targetDirection = Vector3.RotateTowards(controller.transform.forward, movementDirection, rotationSpeed * Time.deltaTime, 0.0f);
            controller.transform.rotation = Quaternion.LookRotation(targetDirection);

        }
        
    }

    void EnableJoystickInput()
    {
        isJoystick = true;
        inputCanvas.gameObject.SetActive(true);
    }
}
