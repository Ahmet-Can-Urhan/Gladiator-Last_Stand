using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    [SerializeField] private Transform heartsContainer;                                    
    
    private GameObject player;
    private PlayerHealth health;
    
    private RawImage[] hearts;

    [SerializeField] private Texture emptyHeart;
    [SerializeField] private Texture halfHeart;
    [SerializeField] private Texture fullHeart;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<PlayerHealth>();

        hearts = new RawImage[heartsContainer.childCount];

        for (int i = 0; i < heartsContainer.childCount; i++)
        {
            hearts[i] = heartsContainer.GetChild(i).GetComponent<RawImage>();
        }
        
    }
    private void Start() 
    { 
       
        UpdateHearts();
    }

    public void UpdateHearts() 
    {
        float currentHealthf = (health.currentHealth/health.maxHealth)*10;

        for (int i = 0; i < hearts.Length; i++) 
        { 
            if ((float)i+1f > currentHealthf && (float)i < currentHealthf)
                hearts[i].texture = halfHeart;
            else if ((float)i < currentHealthf)
                hearts[i].texture = fullHeart;
            else
                hearts[i].texture = emptyHeart;
        
        

        }

    }
    
    
}
