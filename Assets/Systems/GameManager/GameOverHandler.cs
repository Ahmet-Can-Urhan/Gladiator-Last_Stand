using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    public void GoToMainMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart() 
    {
        SceneManager.LoadScene("Arena");
    }
}
