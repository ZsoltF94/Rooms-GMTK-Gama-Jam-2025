using System;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    // states
    public enum State
    {
        Wait,
        ChasePlayer
    }
    public State currentState = State.Wait;

    // refs
    [SerializeField] Timer time;
    [SerializeField] Transform playerPos;

    Rigidbody2D rb;

    // attr
    [Header("Monster Movement")]
    [SerializeField] private float moveSpeed = 4f;

    [Header("Monster starts to move")]
    [SerializeField] int hours = 19;
    [SerializeField] int minutes = 30;

    [Header("Animation")]
    [SerializeField] Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Wait:
                HandleWait();
                break;
            case State.ChasePlayer:
                HandleChasePlayer();
                break;
        }
    }

    private void HandleWait()
    {
        animator.SetBool("isMoving", false);
        if (time.GetCurrentTime() >= new DateTime(1, 1, 1, hours, minutes, 0, 0))
        {
            currentState = State.ChasePlayer;

        }
    }

    private void HandleChasePlayer()
    {

        if (GameManager.Instance.transitionActive)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        // get direction to player
        Vector2 dir = (playerPos.position - transform.position).normalized;

        // move to player
        rb.linearVelocity = dir * moveSpeed;

        // animation
        animator.SetBool("isMoving", true);
        animator.SetFloat("MoveX", rb.linearVelocity.x);
        animator.SetFloat("MoveY", rb.linearVelocity.y);
    }
}
