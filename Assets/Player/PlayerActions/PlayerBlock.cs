using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlock : MonoBehaviour
{
    private PlayerInputHandler inputHandler;
    private Animator animator;
    private PlayerActionManager actionManager;
    [SerializeField] private float blockDuration = 1f;
    public bool IsBlocking { get; private set; }
    private void Awake()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
        animator = GetComponent<Animator>();
        actionManager = GetComponent<PlayerActionManager>();
    }
    private void Start()
    {
        inputHandler.InputActions.GamePlay.Block.performed += OnBlock;
      

    }

    private void OnBlock(InputAction.CallbackContext context) 
    {
        if (!IsBlocking && actionManager.state == PlayerState.IDLE)
        {
            animator.SetTrigger("Block");
            StartCoroutine(PerformBlock());
        }
        
    }

    private void OnDisable()
    {
        inputHandler.InputActions.GamePlay.Block.performed -= OnBlock;
        
    }
    IEnumerator PerformBlock() 
    {
        IsBlocking = true;
        actionManager.SetPlayerState(PlayerState.BLOCK);
        yield return new WaitForSeconds(blockDuration);
        actionManager.SetPlayerState(PlayerState.IDLE);
        IsBlocking = false;
    
    }
}
