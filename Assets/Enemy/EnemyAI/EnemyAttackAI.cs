using UnityEngine;
using System.Collections;
using Unity.VisualScripting;


public class EnemyAttackAI : MonoBehaviour
{
	[SerializeField] private EnemyStats stats;
	private EnemyAttack attack;
	private DistanceToPlayer distance;
	private GameObject playerObj;
	private Transform player;
	[SerializeField]private BoxCollider2D enemyAttackArea;
	private LayerMask damageableLayer;



	private void Awake()
	{
		distance = GetComponent<DistanceToPlayer>();
		playerObj = GameObject.FindGameObjectWithTag("Player");
		attack = GetComponent<EnemyAttack>();
		player = playerObj.transform;
		
	}

	private void Update()
	{
		if (playerObj.IsUnityNull()) return;
		if (playerObj.IsUnityNull()) return;
		Collider2D[] hitplayer = Physics2D.OverlapBoxAll(enemyAttackArea.bounds.center, enemyAttackArea.bounds.size, damageableLayer);
		foreach (Collider2D player in hitplayer)
		{
			if (player.TryGetComponent<IDamageable>(out IDamageable damageable) && player.tag == "Player")
			{
				attack.TryAttack(damageable);
			}
		}


	}
}