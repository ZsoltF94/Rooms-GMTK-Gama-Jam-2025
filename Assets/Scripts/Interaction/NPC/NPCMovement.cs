

using System.Collections;
using Unity.VisualScripting;

using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    enum State { Patrol, Dialog }
    State currentState = State.Patrol;

    [Header("Movement")]
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] float patrolSpeed;
    [SerializeField] float reachPointDistance;
    [SerializeField] float patrolPointTime;
    [SerializeField] Animator animator;

    [SerializeField] NPCInteraction npcInteraction;
    [SerializeField] Transform player;

    private int currentPatrolpointIndex;
    private bool isWaiting = false;

    // refs
    Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        
        switch (currentState)
        {
            case State.Patrol:
                HandlePatrol();
                break;
            case State.Dialog:
                HandleDialog();
                break;
        }
    }

    public void HandlePatrol()
    {
        if (isWaiting) return;
        animator.SetBool("isWalking", true);
        // get pp direction
        Transform targetPP = patrolPoints[currentPatrolpointIndex];
        Vector2 dir = (targetPP.position - transform.position).normalized;

        // move to pp
        rb.linearVelocity = dir * patrolSpeed;

        animator.SetFloat("MoveX", rb.linearVelocity.x);
        animator.SetFloat("MoveY", rb.linearVelocity.y);

        // if reached pp, change currentPPIndex
        if (Vector2.Distance(transform.position, targetPP.position) <= reachPointDistance
            || !GameManager.Instance.npcsCanMove
            || GameManager.Instance.transitionActive)
        {
            rb.linearVelocity = Vector2.zero;
            isWaiting = true;

            StartCoroutine(ChangePPI());
        }

        if (DialogManager.Instance.isDialog)
        {
            currentState = State.Dialog;
        }
    }
    IEnumerator ChangePPI()
    {
        animator.SetBool("isWalking", false);
        yield return new WaitForSeconds(patrolPointTime);
        currentPatrolpointIndex = (currentPatrolpointIndex + 1) % patrolPoints.Length;
        isWaiting = false;
        animator.SetBool("isWalking", true);
    }

    public void HandleDialog()
    {
        animator.SetBool("isWalking", false);
        // get direction to player
        Vector2 direction = (player.position - transform.position).normalized;

        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);

        if (!DialogManager.Instance.isDialog)
        {
            currentState = State.Patrol;
        }
        
    }
}