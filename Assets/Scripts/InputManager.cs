using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction touchPositionAction;
    private InputAction touchTapAction;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchTapAction = playerInput.actions["TouchPress"];
        touchPositionAction = playerInput.actions["TouchPosition"];
    }

    private void OnEnable()
    {
        touchTapAction.performed += TouchTapped;   
    }

    private void OnDisable()
    {
        touchTapAction.performed -= TouchTapped;
    }   

    private void TouchTapped(InputAction.CallbackContext context)
    {
        bool value = context.ReadValueAsButton();
        Debug.Log("Touch Tapped: " + value);
         
    }
}
