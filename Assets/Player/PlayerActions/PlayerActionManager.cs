using UnityEngine;

public class PlayerActionManager : MonoBehaviour
{
    public PlayerState state { get; private set; }

    private void Awake()
    {
        state = PlayerState.IDLE;
    }

    public void SetPlayerState(PlayerState state)
    {

        this.state = state;
        Debug.Log(this.state);
    }
}
