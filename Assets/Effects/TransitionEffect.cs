using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class TransitionEffect : MonoBehaviour
{
    [SerializeField] Image fadeImage;
    [SerializeField] private float fadeDuration = 2f;
    public bool isFaded {  get; private set; }

    private void Awake()
    {
        if (fadeImage == null)
        {
            Debug.LogError("Fade Image is not assigned in the inspector.");
        }
        else 
        {
            fadeImage.gameObject.SetActive(true);
        }
        
    }
    
    public IEnumerator Fade(float startAlpha,float endAlpha)
    {
        float time = 0f;
        
        Color color = fadeImage.color;

        while (time < fadeDuration) 
        {
            Debug.Log(time);
            time += Time.deltaTime;
            Debug.Log(time);
            float alpha = Mathf.Lerp(startAlpha, endAlpha, time / fadeDuration);
            color.a = alpha;
            fadeImage.color = color;

            yield return null;

        }
        color.a = endAlpha;
        fadeImage.color = color;
        isFaded = true;
       
    }
}
