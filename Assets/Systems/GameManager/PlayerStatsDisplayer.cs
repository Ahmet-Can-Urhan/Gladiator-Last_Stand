using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsDisplayer : MonoBehaviour
{
    [SerializeField] private Text healthPercentage;
    [SerializeField] private Text speedPercentage;
    [SerializeField] private Text attackPercentage;
    [SerializeField] private Text attackCooldownPercentage;

    private PlayerHealth playerHealth;
    private PlayerAttack playerAttack;
    private PlayerMovement playerMovement;
    private void Awake()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerHealth = playerObject.GetComponent<PlayerHealth>();
        playerAttack = playerObject.GetComponent<PlayerAttack>();
        playerMovement = playerObject.GetComponent<PlayerMovement>();

    }
    public void displayStats() 
    {
        float healthRatioPercent = ((playerHealth.currentHealth) / (playerHealth.baseHealth)) * 100;
        float speedRatioPercent = ((playerMovement.moveSpeed) / (playerMovement.initialMoveSpeed)) * 100;
        float attackRatioPercent = ((playerAttack.attackDamage) / (playerAttack.baseDamage)) * 100;
        float attackCooldownRatioPercent = ((playerAttack.attackCooldown) / (playerAttack.baseAttackCooldown)) * 100;

        healthPercentage.text = healthRatioPercent + "%";
        speedPercentage.text = speedRatioPercent + "%";
        attackPercentage.text = attackRatioPercent + "%";
        attackCooldownPercentage.text = attackCooldownRatioPercent + "%";


    }
}
