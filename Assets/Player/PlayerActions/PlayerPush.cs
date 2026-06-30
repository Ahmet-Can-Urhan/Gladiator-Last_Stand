using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPush : MonoBehaviour
{
   private PlayerInputHandler inputHandler;
   private Animator           animator;
   private float             pushRadius = 2f;
   private float             pushForce  = 15f;
   private float             pushDuration = 0.5f;
    public bool              isPushing { get; private set; }
   

    private void Awake()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        inputHandler.InputActions.GamePlay.Push.performed += OnPush;

    }

    private void OnPush(InputAction.CallbackContext context) 
    {
        PerformPush();
    }
    private void PerformPush() 
    {
        StartCoroutine(setPushBool());
        
        animator.SetTrigger("Push");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, pushRadius);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.TryGetComponent<Rigidbody2D>(out Rigidbody2D damageable) && 
                enemy.tag != "Player" &&
                enemy.TryGetComponent<EnemyMovement>(out EnemyMovement movement))
            {
                Vector2 pushDirection = (enemy.transform.position - transform.position).normalized;
                
                damageable.AddForce(pushDirection*pushForce,ForceMode2D.Impulse);
                Debug.Log("Push Applied");
            }
        }
    }

    IEnumerator setPushBool() 
    { 
        isPushing = true;
        yield return new WaitForSeconds(pushDuration);
        isPushing = false;
    }
   

    private void OnDisable()
    {
        inputHandler.InputActions.GamePlay.Push.performed -= OnPush;
    }
}

