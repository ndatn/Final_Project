using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersAI : MonoBehaviour
{
    private Vector2 initialPosition;
    private bool isReturning = false;
    private float returnSpeed = 0.5f;
    public float moveSpeed = 1f;
    public float attackRange = 3f;
    private Transform target;
    private bool canAttack = true;
    public Animator animator;
    private Rigidbody2D rb;
    float health, maxHealth = 3f;

    void Start()
    {
        initialPosition = transform.position;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (target == null)
        {
            Debug.LogError("No player found in the scene. Make sure to tag your player object with 'Player'.");
        }
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    void FixedUpdate()
    {
        FindPlayer();
    }

    void FindPlayer()
    {
        if (target != null)
        {
            Vector2 direction = target.position - transform.position;
            float sqrDistanceToPlayer = direction.sqrMagnitude;
            if (sqrDistanceToPlayer <= attackRange * attackRange && canAttack)
            {
                rb.velocity = direction.normalized * moveSpeed;
            }
            else
            {
                if (!isReturning)
                {
                    StartReturningToInitialPosition();
                }

            }
            if (isReturning)
            {
                ReturnToInitialPosition();
            }

            AnimateMovement(rb.velocity);
        }
    }
    void ReturnToInitialPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, initialPosition, returnSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, initialPosition) == 0)
        {
            isReturning = false;
        }
        else { isReturning = true; }
    }
    void StartReturningToInitialPosition()
    {
        isReturning = true;
    }
    void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void AnimateMovement(Vector2 velocity)
    {
        if (animator != null)
        {
            if (velocity.magnitude > 0)
            {
                Vector2 normalizedVelocity = velocity.normalized;
                animator.SetBool("isMoving", true);
                animator.SetFloat("horizontal", normalizedVelocity.x);
                animator.SetFloat("vertical", normalizedVelocity.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }

}
