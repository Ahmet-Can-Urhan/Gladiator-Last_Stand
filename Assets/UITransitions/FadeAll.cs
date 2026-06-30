using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;


public class FadeAll : MonoBehaviour
{
    
    [SerializeField] private float fadeDuration = 2f;
    private GameObject[] allChildren;
    public bool isFaded { get; private set; }

    private void  Start() 
    {
        allChildren = GetComponentsInChildren<Transform>(true)
        .Select(t => t.gameObject)
        .ToArray();
       
    }
    public void StartFadeIn()
    {

        
        for (int i = 0; i < allChildren.Length; i++) 
        { 
            allChildren[i].SetActive(true);
        }

        StartCoroutine(Fade(0f, 1f));
    }
    public void StartFadeOut() 
    {
        for (int i = 0; i < allChildren.Length; i++)
        {
            allChildren[i].SetActive(true);
        }

        StartCoroutine(Fade(1f, 0f));
    }
    public IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float time = 0f;

        while (time <= fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, time / fadeDuration);

            foreach (GameObject go in allChildren)
            {
                if (go.TryGetComponent<UnityEngine.UI.Image>(out var img))
                {
                    Color c = img.color;
                    c.a = alpha;
                    img.color = c;
                }
                else if (go.TryGetComponent<UnityEngine.UI.Text>(out var txt))
                {
                    Color c = txt.color;
                    c.a = alpha;
                    txt.color = c;
                }
            }

            if (time >= fadeDuration) 
            { 
                isFaded = true;
            }
            yield return null;
        }
    }

}
