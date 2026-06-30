using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SetPlay : MonoBehaviour
{
    private GameObject objectmanager;
    private GameManager gameManager;
    private GameObject transitionImage;
    private TransitionEffect transitionEffect;

    private void Awake()
    {
        objectmanager = GameObject.Find("GameManager");
        gameManager = objectmanager.GetComponent<GameManager>();

        transitionImage = GameObject.Find("TransitionImage");
        transitionEffect = transitionImage.GetComponent<TransitionEffect>();

        

    }


    public void SetPlayGame()
    {

        StartCoroutine(LoadSceneWithFade());

    }
    private IEnumerator LoadSceneWithFade() 
    { 
        yield return StartCoroutine(transitionEffect.Fade(0f, 1f));
        SceneManager.LoadScene("Arena");

    }
    
}

