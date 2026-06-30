using System.Collections;
using UnityEngine;

public class TurnRed : MonoBehaviour
{

    public void ShowHitEffect()
    {
        StartCoroutine(FlashRed());
    }
    IEnumerator FlashRed()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = Color.white;
    }
}
