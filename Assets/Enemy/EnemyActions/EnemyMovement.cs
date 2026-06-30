using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyStats      stats;
    [SerializeField] private bool isPrefabReverse;

    private Animator                         animator;

    public Vector3                          moveDirection { get; private set; }
    
    private Rigidbody2D                      rb;
    private GameObject                       player;
    private PlayerPush                       playerPush;
    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerPush = player.GetComponent<PlayerPush>();
        
    }
   
    public void SetMoveDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    private void FixedUpdate()
    {
        if (player.IsUnityNull()) return;
        
            
        
        if (!playerPush.isPushing)
        {
            rb.linearVelocity = moveDirection * stats.moveSpeed;
            float speed = rb.linearVelocity.magnitude;
            animator.SetFloat("Speed", speed);
            
            if ((moveDirection.x < 0 && !isPrefabReverse) || (moveDirection.x > 0 && isPrefabReverse )) 
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            if ((moveDirection.x > 0 && !isPrefabReverse) || (moveDirection.x < 0) && isPrefabReverse) 
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
        }
        
    }




}
