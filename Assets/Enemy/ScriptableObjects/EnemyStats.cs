using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "Enemy/EnemyStats")]
public class EnemyStats : ScriptableObject
{
   public int maxHealth = 100;
   public float moveSpeed = 3f;
   public float attackRadius = 2;
   public float attackDamage = 10;
   public float attackCooldown = 1.5f;
}
