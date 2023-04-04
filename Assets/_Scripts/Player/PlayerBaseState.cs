using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : MonoBehaviour
{

    public abstract void EnterState(PlayerStateManager playerManager);

    public abstract void UpdateState(PlayerStateManager playerManager);

    public abstract void ExitState(PlayerStateManager playerManager);

}
