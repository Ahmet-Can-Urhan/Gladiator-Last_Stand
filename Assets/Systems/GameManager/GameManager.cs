using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public GameState currentState { get; private set; }
    public static GameManager Instance { get; private set; }

    private PlayerInputHandler playerInputHandler;

    private PauseHandler pauseHandler;

    private void Awake()
    {
        playerInputHandler = gameObject.GetComponent<PlayerInputHandler>();
        



        currentState = GameState.BOOT;
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        



    }

    private void Start() 
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            SetGameState(GameState.IN_GAME);
            
        }
        else
        {
            SetGameState(GameState.MAIN_MENU);
        }


    }

    public void SetGameState(GameState gameState) 
    { 
        currentState = gameState;
        Debug.Log("Game State changed to: " + currentState.ToString());
    }





}
