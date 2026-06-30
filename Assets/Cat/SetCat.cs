using UnityEngine;

public class SetCat : MonoBehaviour
{
    [SerializeField]private GameObject                catObject;
    private                 Animator                  catAnimator;
    private                 SpriteRenderer            catRenderer;


    [SerializeField] private RuntimeAnimatorController orangeCatAnimController;
    [SerializeField] private RuntimeAnimatorController whiteCatAnimController;
    [SerializeField] private RuntimeAnimatorController blackCatAnimController;
    [SerializeField] private RuntimeAnimatorController tabbyCatAnimController;

    [SerializeField] private Sprite            orangeCatSprite;
    [SerializeField] private Sprite            whiteCatSprite;
    [SerializeField] private Sprite            blackCatSprite;
    [SerializeField] private Sprite            tabbyCatSprite;
    private void Awake()
    {
        catAnimator = catObject.GetComponent<Animator>();
        catRenderer = catObject.GetComponent<SpriteRenderer>();
    }
    public void OnOrangePicked() 
    {
        catObject.SetActive(true);
        catAnimator.runtimeAnimatorController = orangeCatAnimController;
        catRenderer.sprite = orangeCatSprite;
    }
    public void OnWhitePicked() 
    {
        catObject.SetActive(true);
        catAnimator.runtimeAnimatorController = whiteCatAnimController;
        catRenderer.sprite = whiteCatSprite;
    }
    public void OnBlackPicked()
    {
        catObject.SetActive(true);
        catAnimator.runtimeAnimatorController = blackCatAnimController;
        catRenderer.sprite = blackCatSprite;
    }
    public void OnTabbyPicked() 
    {
        catObject.SetActive(true);
        catAnimator.runtimeAnimatorController = tabbyCatAnimController;
        catRenderer.sprite = tabbyCatSprite;
    }
}
