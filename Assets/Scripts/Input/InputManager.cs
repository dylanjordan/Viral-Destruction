using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    PlayerInput _movement;

    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        _movement = new PlayerInput();
    }

    private void OnEnable()
    {
        _movement.Enable();
    }

    private void OnDisable()
    {
        _movement.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return _movement.Movement.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseMovement()
    {
        return _movement.Movement.Look.ReadValue<Vector2>();
    }

    public bool GetJumped()
    {
        return _movement.Movement.Jump.triggered;
    }

    public bool GetSprint()
    {
        if (_movement.MovementEffects.SprintEnabled.IsPressed())
        {
            return true;
        }
        if (_movement.MovementEffects.SprintDisabled.WasReleasedThisFrame())
        {
            return false;
        }
        return false;
    }

    public bool GetCrouch()
    {
        return _movement.MovementEffects.Crouch.triggered;
    }
}