using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Custom class used to manage the game's input system
/// without having to instantiate the ControllerInputAction class in various other classes
/// </summary>
public static class InputManager
{
    //input action created in the editor | private since we dont want to gain access from other classes
    private static ControllerInputActions _input; 
    private static bool _isInit = false;

    //shortcut property used to give access to the vector of the movement direction
    public static Vector2 MovementAxis => _input.GroundMovement.Movement.ReadValue<Vector2>();  
    
    static InputManager()
    {
        Init();
    }

    private static void Init() //init the input action
    {
        if (_isInit) return;

        _input = new ControllerInputActions();
        _input.Enable();
        
        _isInit = true;
    }
}
