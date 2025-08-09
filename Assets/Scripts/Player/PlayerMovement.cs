
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // attrs
    [SerializeField] float maxSpeed = 5f;
    [SerializeField] float damping = 5f;
    [SerializeField] float acceleration = 5f;


    InputSystem_Actions inputActions;
    private Vector2 moveInput;
    Vector2 lastDir;

    // Store delegates
    System.Action<UnityEngine.InputSystem.InputAction.CallbackContext> movePerformed;
    System.Action<UnityEngine.InputSystem.InputAction.CallbackContext> moveCanceled;

    // bool isWalking;

    // refs
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] GameObject interactionSquare;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputActions = new InputSystem_Actions();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();
        UpdateMoveAnimation();
        Update_InteractionSquare_Position();
    }

    void OnEnable()
    {
        movePerformed = ctx => moveInput = ctx.ReadValue<Vector2>();
        moveCanceled = ctx => moveInput = Vector2.zero;

        inputActions.Enable();
        inputActions.Player.Move.performed += movePerformed;
        inputActions.Player.Move.canceled += moveCanceled;
    }
    void OnDisable()
    {
        inputActions.Player.Move.performed -= movePerformed;
        inputActions.Player.Move.canceled -= moveCanceled;
        inputActions.Disable();
    }

    public void Move()
    {
        if (GameManager.Instance.transitionActive || !GameManager.Instance.playerCanMove)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        Vector2 currentSpeed = rb.linearVelocity;
        Vector2 targetSpeed = moveInput.normalized * maxSpeed;
        Vector2 speedDifference = targetSpeed - currentSpeed;

        rb.AddForce(speedDifference * acceleration, ForceMode2D.Force);
        rb.AddForce(-currentSpeed * damping, ForceMode2D.Force);
    }

    public void UpdateMoveAnimation()
    {
        if (!GameManager.Instance.playerCanMove) return;
        if (moveInput != Vector2.zero) lastDir = moveInput;

        if (moveInput == Vector2.zero)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("MoveX", lastDir.x);
            animator.SetFloat("MoveY", lastDir.y);
        }
        else
        {
            animator.SetBool("isWalking", true);
            animator.SetFloat("MoveX", lastDir.x);
            animator.SetFloat("MoveY", lastDir.y);
        }
    }

    void Update_InteractionSquare_Position()
    {
        if (!GameManager.Instance.playerCanMove) return;
        if (moveInput != Vector2.zero) lastDir = moveInput;
        interactionSquare.transform.position =
        rb.transform.position + new Vector3(lastDir.x, lastDir.y, 0);
    }

    public Vector2 GetMoveInput()
    {
        return moveInput;
    }




}
