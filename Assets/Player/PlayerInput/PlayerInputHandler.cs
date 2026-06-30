using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public PlayerInputActions InputActions { get; private set; }

    public void Awake()
    {
        InputActions = new PlayerInputActions();
        InputActions.Enable();
    }

    public void OnDisable()
    {
        InputActions.Disable();

    }
}
