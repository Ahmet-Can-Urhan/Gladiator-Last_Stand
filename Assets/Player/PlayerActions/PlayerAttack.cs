using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private Animator                      animator;
    private PlayerInputHandler            inputHandler;
    public float                         attackDamage { get; private set; } = 20f;
    public float                         baseDamage { get; private set; }

    [SerializeField] BoxCollider2D      attackHitBox;
    [SerializeField] private LayerMask  damageableLayer;

    public float                       attackCooldown { get; private set; } = 0.8f;
    public float baseAttackCooldown { get; private set; }
    private float                       lastAttackTime;

    private PlayerActionManager        actionManager;
    private bool                       CanAttack => Time.time >= lastAttackTime + attackCooldown;
    private void Awake()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
        animator = GetComponent<Animator>();
        actionManager = GetComponent<PlayerActionManager>();
        baseDamage = attackDamage;
        baseAttackCooldown = attackCooldown;
    }
    private void Start()
    {
        inputHandler.InputActions.GamePlay.Attack.performed += OnAttack;
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        if (!CanAttack) { return; }
        if (actionManager.state == PlayerState.IDLE)
        {
            lastAttackTime = Time.time;
            PerformAttack();
        }
    }
    private void PerformAttack()
    {
        animator.SetTrigger("AttackLight");
        StartCoroutine(setPlayerStatetoAttack());
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackHitBox.bounds.center, attackHitBox.bounds.size, damageableLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.TryGetComponent<IDamageable>(out IDamageable damageable) && enemy.tag != "Player")
            {
                damageable.TakeDamage(attackDamage);
            }
        }
    }
    IEnumerator setPlayerStatetoAttack() 
    {
        actionManager.SetPlayerState(PlayerState.ATTACK);
        yield return new WaitForSeconds(attackCooldown);
        actionManager.SetPlayerState(PlayerState.IDLE);
    }
    public void SetPlayerAttackByPercent(int percent)
    {
        attackDamage = attackDamage + (baseDamage * (percent / 100f));

    }
    public void SetAttackCooldownByPercent (int percent)
    {
        attackCooldown = attackCooldown + (baseAttackCooldown * (percent / 100f));

    }

}
