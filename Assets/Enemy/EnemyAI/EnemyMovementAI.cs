using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovementAI : MonoBehaviour
{
    [SerializeField] private EnemyStats stats;
    private DistanceToPlayer distance;
    

    private EnemyMovement movement;
    

    private void Awake() 
    {
        movement = GetComponent<EnemyMovement>();
        distance = GetComponent<DistanceToPlayer>();
    
    }

    void Update()
    {
        
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (distance.distance >= stats.attackRadius)
        {
            Vector3 direction = distance.direction;
            movement.SetMoveDirection(direction);
        }
        else 
        { 
            movement.SetMoveDirection(Vector3.zero);
        }
    }
}
