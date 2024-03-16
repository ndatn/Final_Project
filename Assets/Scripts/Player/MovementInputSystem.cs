// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.InputSystem;

// public class MovementInputSystem : MonoBehaviour
// {
//     private CustomInput _input;
//     private Vector2 moveVector = Vector2.zero;
//     private Rigidbody2D rb;
//     private float moveSpeed = 5f;
//     //Removeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
//     private void AWake()
//     {
//         _input = new CustomInput();
//         rb = GetComponent<Rigidbody2D>();
//     }

//     private void OnEnable()
//     {
//         _input.Enable();
//         _input.Player.movement.performed += OnMovementPerformed;
//         _input.Player.movement.canceled += OnMovementCancelled;
//     }
//     private void OnDisable()
//     {
//         _input.Disable();
//         _input.Player.movement.performed -= OnMovementPerformed;
//         _input.Player.movement.canceled -= OnMovementCancelled;
//     }
//     private void FixedUpdate()
//     {
//         rb.velocity = moveVector * moveSpeed;
//     }
//     private void OnMovementPerformed(InputAction.CallbackContext value)
//     {
//         moveVector = value.ReadValue<Vector2>();
//     }
//     private void OnMovementCancelled(InputAction.CallbackContext value)
//     {
//         moveVector = Vector2.zero;
//     }
// }
