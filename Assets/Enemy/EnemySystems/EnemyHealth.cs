using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyStats enemyStats;
    [SerializeField] private GameObject deadBody;
    private float currentHealth;
    private TurnRed turnred;
    public bool isDead {  get; private set; }

    private WaveSpawner waveSpawner;

    private void Awake()
    {
        currentHealth = enemyStats.maxHealth;
        turnred = GetComponent<TurnRed>();
        waveSpawner = GameObject.Find("WaveSystem").GetComponent<WaveSpawner>();

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, enemyStats.maxHealth);

        
        turnred.ShowHitEffect();
        if (currentHealth <= 0)
        {
            Die();
        }
        
    }
    public void Die() 
    { 
     waveSpawner.enemyDead();


     Instantiate(deadBody,transform.position,transform.rotation);
     Destroy(gameObject);
      
     
    }
}
