
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaveHandler : MonoBehaviour
{

    
    public int currentWave {  get; private set; }
    private GameObject player;
    private PlayerHealth playerHealth;
    private HeartSystem heartSystem;
    [SerializeField] private GameObject endOfWaveUI;
    [SerializeField] private GameObject defaultUI;
    [SerializeField] private GameObject catSpecialEvent;
    [SerializeField] private GameObject resultPopup;

    [SerializeField] private GameObject backgroundObject;
    [SerializeField] private RawImage background;


    private WaveSpawner waveSpawner;
    private bool isFaded = false;
    private float startAlpha = 0f;
    private float endAlpha = 1f;
    private EndOfWaveHandler endOfWaveHandler;

    private float time = 0f;
    private float fadeDuration = 2f;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

        GameObject heartSystemObject = GameObject.Find("HeartSystem");
        heartSystem = heartSystemObject.GetComponent<HeartSystem>();

        waveSpawner = GetComponent<WaveSpawner>();
        endOfWaveHandler = GetComponent<EndOfWaveHandler>();

    }
    public void OnAllWaveDead()
    {
        StartCoroutine(FadeBackground());
 
    }
    public void OnContinue() 
    {
        if (currentWave == 9) 
        {
            SceneManager.LoadScene("MainMenu");
        }
        endOfWaveHandler.SetModifiers();
        playerHealth.ResetHealth();
        heartSystem.UpdateHearts();
        resultPopup.SetActive(true);
        currentWave++;

    }
    public void OnOkay() 
    {
        
        Time.timeScale = 1f;
        defaultUI.SetActive(true);
        catSpecialEvent.SetActive(false);
        resultPopup.SetActive(false);
        endOfWaveUI.SetActive(false);
        backgroundObject.SetActive(false);
        waveSpawner.SpawnWave(currentWave);
        player.transform.position = new Vector2(-77.16f,3.79f);
    }


    public IEnumerator FadeBackground()
    {

        backgroundObject.SetActive(true);
        Color color = background.color;
        color.a = 0f;
        time = 0f;

        while (time < fadeDuration)
        {
            Debug.Log(time);
            time += Time.deltaTime;
            Debug.Log(time);
            float alpha = Mathf.Lerp(startAlpha, endAlpha, time / fadeDuration);
            color.a = alpha;
            background.color = color;

            yield return null;

        }
        color.a = endAlpha;
        background.color = color;
        isFaded = true;
        
        switch (currentWave)
        {
            case 2:
                endOfWaveHandler.HandleWaveFinishedText();
                defaultUI.SetActive(false);
                catSpecialEvent.SetActive(true);

                Time.timeScale = 0f;
                endOfWaveUI.SetActive(true);
                break;

            default:
                endOfWaveHandler.HandleWaveFinishedText();
                endOfWaveHandler.SetStory();

                Time.timeScale = 0f;
                Debug.Log("END OF WAVE IS CALLED");
                endOfWaveUI.SetActive(true);
                break;
        }
    }
}
