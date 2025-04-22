using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public PlayerMovementState currenPlayerMovementState = PlayerMovementState.Idle;

  
    public void UpdatePlayerState(PlayerMovementState playerState)
    {
        currenPlayerMovementState = playerState;
    }
}
public enum PlayerMovementState
{
    Idle,
    Walking,
    Running,
    Sprinting,
    Jumping,
    Falling,
    Strafing,
}
