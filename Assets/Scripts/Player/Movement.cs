using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 2f;
    public Animator animator;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();

    }
    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        AnimateMovement(movement);
        rb.velocity = movement * speed;
    }
    void AnimateMovement(Vector2 movement)
    {
        if (animator != null)
        {
            if (movement.magnitude > 0)
            {
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
}
