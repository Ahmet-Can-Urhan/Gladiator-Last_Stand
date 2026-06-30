using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Animator                    animator;

    private PlayerInputHandler          inputHandler;
    private Rigidbody2D                 rb;
    public float initialMoveSpeed { get; private set; }
    public float moveSpeed { get; private set; } = 5f;
    private Vector2                     movementInput;
    private PlayerActionManager         actionManager;
    private void Awake()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        actionManager = GetComponent<PlayerActionManager>();
        initialMoveSpeed = moveSpeed;
    }


    private void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        if (movementInput.x < 0) 
        { 
        transform.rotation = new Quaternion(0,180,0,0);
        }
        if (movementInput.x > 0) 
        { 
        transform.rotation = new Quaternion(0,0,0,0);
        }
        
        
        
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = movementInput * moveSpeed;
        float speed = rb.linearVelocity.magnitude;
        animator.SetFloat("Speed", speed);
        

    }
    private void Start()
    {
        inputHandler.InputActions.GamePlay.Move.performed += OnMove;
        inputHandler.InputActions.GamePlay.Move.canceled += OnMove;
    }

    private void OnDisable()
    {
        inputHandler.InputActions.GamePlay.Move.performed -= OnMove;
        inputHandler.InputActions.GamePlay.Move.canceled -= OnMove;
    }

    public void SetMoveSpeedByPercent(int percent) 
    {
        moveSpeed = moveSpeed + (initialMoveSpeed * (percent / 100f));
    } 
}
