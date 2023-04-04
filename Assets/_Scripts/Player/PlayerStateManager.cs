using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;
    public PlayerMovementState movementState;
    public PlayerLadderState ladderState;

    void Start()
    {
        currentState = movementState;
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState playerState)
    {
        currentState = playerState;
        currentState.EnterState(this);
    }

}
