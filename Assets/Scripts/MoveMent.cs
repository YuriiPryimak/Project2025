using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMent : MonoBehaviour
{
    public float _speed = 6.0f;
    private CharacterController _characterController;
    public float _gravity = -9.8f;
    public float jumpHeight = 2.0f; 
    private float _verticalVelocity; 
    private bool isGrounded;

    private void Update()
    {
        
        
        isGrounded = _characterController.isGrounded;

        
        float deltaX = Input.GetAxis("Horizontal") * _speed;
        float deltaZ = Input.GetAxis("Vertical") * _speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        if (isGrounded)
        {
           
            _verticalVelocity = 0f;

            
            if (Input.GetButton("Jump"))
            {
                _verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * _gravity); 
            }
        }
        else
        {
            
            _verticalVelocity += _gravity * Time.deltaTime;
        }

        
        movement.y = _verticalVelocity;

       
        movement = Vector3.ClampMagnitude(movement, _speed);

       
        movement = transform.TransformDirection(movement);

        
        _characterController.Move(movement * Time.deltaTime);
    }

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
       
           
    }
}
