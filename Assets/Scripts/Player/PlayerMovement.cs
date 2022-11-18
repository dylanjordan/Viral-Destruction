using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Info")]
    public Transform groundCheck;
    public LayerMask groundMask;

    [Header("Movement Variables")]
    private float _speed;
    private float _maxSpeed;
    public float _walkSpeed = 10;
    public float _sprintSpeed = 20;
    public float _crouchSpeed = 5;

    public float _acceleration = 10;
    public float _deceleration = 10;
    
    public float _gravity = -9.8f;
    public float _jumpHeight = 3.0f;
    public float disToGround = 0.4f;

    //internal privates
    private CharacterController _controller;
    private InputManager input;

    private Vector2 move;
    private Vector3 _playerVelo;

    private bool isGrounded;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        input = InputManager.Instance;
    }

    private void Update()
    {
        //Update player grounded and movement
        Grav();
        Movement();
        Sprint();
        Crouch();

        //Jump
        if (isGrounded)
        {
            Jump();
        }
    }

    //receives inputs from the InputManager.cs and apply them to the character controller
    public void Movement()
    {
        //Get move input
        move = input.GetPlayerMovement();
        Vector3 movement = (move.y * transform.forward) + (move.x * transform.right).normalized;

        //If player is moving
        if (movement != Vector3.zero)
        {
            //Control speed
            if (_speed < _maxSpeed)
            {
                _speed = _speed + _acceleration * Time.deltaTime;
            }
            else
            {
                _speed = _maxSpeed;
            }
        }
        else
        {
            if(movement == Vector3.zero && _speed > _deceleration * Time.deltaTime)
            {
                _speed = _speed - _deceleration * Time.deltaTime;
            }
            else
            {
                _speed = 0;
            }
        }

        Debug.Log(_speed);
        //Decrease speed if in air
        if (!isGrounded)
        {
            _controller.Move(movement * _speed * 0.7f * Time.deltaTime);
        }
        else
        {
            _controller.Move(movement * _speed * Time.deltaTime);
        }
    }

    private void Grav()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, disToGround, groundMask);

        if (isGrounded && _playerVelo.y < 0)
        {
            _playerVelo.y = -2f;
        }

        _playerVelo.y += _gravity * Time.deltaTime;
        _controller.Move(_playerVelo * Time.deltaTime);
    }

    private void Sprint()
    {
        if (input.GetSprint())
        {
            _maxSpeed = _sprintSpeed;
        }
        else
        {
            _maxSpeed = _walkSpeed;
        }
    }

    private void Crouch()
    {
        if (input.GetCrouch())
        {
            _maxSpeed = _crouchSpeed;
        }
        else
        {
            Sprint();
        }
    }

    public void Jump()
    {
        //Check for jump input
        if (input.GetJumped())
        {
            _playerVelo.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }
    }
}