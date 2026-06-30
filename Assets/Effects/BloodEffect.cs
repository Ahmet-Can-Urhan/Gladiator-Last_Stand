using UnityEngine;
using UnityEngine.UIElements;

public class BloodEffect : MonoBehaviour
{
    [SerializeField] GameObject bloodImages;
    private PlayerHealth playerHealth;

    private void Awake() 
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    

    // Update is called once per frame
    void Update()
    {
        if (playerHealth != null && (playerHealth.currentHealth /playerHealth.maxHealth < 0.3f) && bloodImages.activeSelf == false) 
        {
            
            bloodImages.SetActive(true);
        }
        if (playerHealth != null && (playerHealth.currentHealth / playerHealth.maxHealth > 0.3f) && bloodImages.activeSelf == true)
        {
            bloodImages.SetActive(false);
        }
    }
}
