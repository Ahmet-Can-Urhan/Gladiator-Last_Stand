using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{

    private GameManager gameManager;
    public float maxHealth  { get; private set; }
    public float currentHealth { get; private set; }
    public float baseHealth { get; private set; }

    [SerializeField] private GameObject deadBody;
    [SerializeField] private GameObject gameOverPanel;
    
    private PlayerBlock playerBlock;
    private Animator animator;
    private TurnRed turnred;

    [SerializeField] private GameObject heartSystemObject;
    private HeartSystem heartSystem;


    private void Awake()
    {
        maxHealth = 100f;
        currentHealth = maxHealth;
        playerBlock = GetComponent<PlayerBlock>();
        turnred = GetComponent<TurnRed>();
        animator = GetComponent<Animator>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        
        
        heartSystem = heartSystemObject.GetComponent<HeartSystem>();

        baseHealth = currentHealth;

    }

    public void TakeDamage(float damage)
    {
        if (!playerBlock.IsBlocking)
        {
            currentHealth -= damage;
            
            Debug.Log($"Player took {damage} damage, current health: {currentHealth}");
            
            heartSystem.UpdateHearts();
                
            
            turnred.ShowHitEffect();

        }
        else 
        {
            Debug.Log("Player blocked attack.");
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        gameManager.SetGameState(GameState.GAME_OVER);
        animator.SetBool("IsDead", true);
        StartCoroutine(HandleDeath());
    }
   private IEnumerator HandleDeath() 
    {
        
        yield return new WaitForSeconds(1);
        Instantiate(deadBody, transform.position,transform.rotation);
        Destroy(gameObject);

        gameOverPanel.SetActive(true);
        FadeAll fadeAll = gameOverPanel.GetComponent<FadeAll>();
        fadeAll.StartFadeIn();
    }

    public void ResetHealth() 
    { 
        currentHealth = maxHealth;
        
    }
    public void SetHealthByPercent(int percent) 
    {
        maxHealth = maxHealth + (baseHealth * (percent / 100f));
        
    }
}
