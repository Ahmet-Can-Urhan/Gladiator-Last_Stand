using UnityEngine;

public class CatMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    private Animator catAnimator;
    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerRigidBody = player.GetComponent<Rigidbody2D>();
        catAnimator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        catAnimator.SetFloat("Speed",playerRigidBody.linearVelocity.magnitude);
        
    }
}
