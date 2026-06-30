using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemyStats stats;
    private float lastAttackTime = -Mathf.Infinity;
    private Animator animator;
    public bool CanAttack => Time.time >= lastAttackTime + stats.attackCooldown;
    
    private void Awake() 
    { 
        animator = GetComponent<Animator>();
    }
   
    public void TryAttack(IDamageable target) 
    { 
        if (!CanAttack) return;
        lastAttackTime = Time.time;
        animator.SetTrigger("Attack");
        target.TakeDamage((int)stats.attackDamage);
    }
    
    
}
