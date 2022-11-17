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
    public float _acceleration;
    public  float _maxSpeed = 10.0f;
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

        //Increase player speed if not max
        if(_speed < _maxSpeed)
        {
            _speed = _speed + _acceleration * Time.deltaTime;
        }
        //Reset player speed if stopped moving
        if(movement == Vector3.zero)
        {
            _speed = 0;
        }
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

    public void Jump()
    {
        //Check for jump input
        if (input.GetJumped())
        {
            _playerVelo.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }
    }
}