using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{
    private PlayerInputHandler playerInputHandler;

    [SerializeField] private GameObject pauseMenu;
    private GameManager gameManager;
    private PlayerStatsDisplayer playerStatsDisplayer;

    private void Awake()
    {
        playerInputHandler = gameObject.GetComponent<PlayerInputHandler>();
        gameManager = gameObject.GetComponent<GameManager>();
        playerStatsDisplayer = GetComponent<PlayerStatsDisplayer>();
    }

    private void Start()
    {
        if (gameManager.currentState == GameState.IN_GAME)
        {
            playerInputHandler.InputActions.GamePlay.Pause.performed += OnPause;

        }
        
    }

    public void OnPause(InputAction.CallbackContext context) 
    {
        if (Time.timeScale == 0f)
        {
            gameManager.SetGameState(GameState.IN_GAME);
            pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;

        }
        else if (Time.timeScale == 1.0f)
        {
            playerStatsDisplayer.displayStats();
            pauseMenu.SetActive(true);
            gameManager.SetGameState(GameState.PAUSED);

            Time.timeScale = 0f;
        }
    }
    public void ContinueGame()
    {
        gameManager.SetGameState(GameState.IN_GAME);
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void GoToMainMenu() 
    {
        gameManager.SetGameState(GameState.MAIN_MENU);
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }
}
