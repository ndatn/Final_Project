using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
public class Movement : MonoBehaviour
{
    public float speed = 2f;
    public Animator animator;
    public Rigidbody2D rb;
    public Transform Aim;
    public bool canMove = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        if (canMove)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(horizontal, vertical);
            AnimateMovement(movement);
            rb.velocity = movement * speed;

            if (movement != Vector2.zero)
            {
                Vector3 aimDirection = Vector3.left * movement.x + Vector3.down * movement.y;
                Debug.Log(aimDirection);
                Debug.Log(Vector3.forward);
                Aim.rotation = Quaternion.LookRotation(Vector3.forward, aimDirection);

            }
        }
    }
    void AnimateMovement(Vector2 movement)
    {
        if (animator != null)
        {
            if (movement.magnitude > 0)
            {
                // Debug.Log(movement.magnitude);
                animator.SetBool("isMoving", true);
                animator.SetFloat("horizontal", movement.x);
                animator.SetFloat("vertical", movement.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            Debug.Log("Enter");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Circle")
        {
            Debug.Log("Exit");
        }
    }
    void LockMovement()
    {
        canMove = true;
    }
    void UnLockMovement()
    {
        canMove = false;
    }
}
