using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersAI : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float attackRange = 3f;
    private Transform target;
    private bool canAttack = true;
    public Animator animator;

    private Rigidbody2D rb;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (target == null)
        {
            Debug.LogError("No player found in the scene. Make sure to tag your player object with 'Player'.");
        }
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (target != null)
        {
            Vector2 direction = target.position - transform.position;
            AnimateMovement(direction);
            float sqrDistanceToPlayer = direction.sqrMagnitude;
            if (sqrDistanceToPlayer <= attackRange * attackRange && canAttack)
            {
                rb.velocity = direction.normalized * moveSpeed;
                AttackPlayer();
            }
            else
            {
                rb.velocity = direction.normalized * 0;
            }

        }
    }
    void AnimateMovement(Vector2 direction)
    {
        if (animator != null)
        {
            if (direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player collided with Monsters");
        }
    }
    void AttackPlayer()
    {
        Debug.Log("Monsters is attacking the player!");
    }

}
