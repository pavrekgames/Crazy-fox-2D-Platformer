using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLadderState : PlayerBaseState
{
    [SerializeField] private PlayerInputActions playerInput;
    [SerializeField] private PlayerStateManager playerManager;

    [SerializeField] private Transform player;
    [SerializeField] private Camera maincamera;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private float speed = 6f;

    [Header("Ladder")]
    public Ladder ladder;

    public override void EnterState(PlayerStateManager playerManager)
    {
        playerInput = new PlayerInputActions();
        playerInput.Enable();

        GroundDetector.OnPlayerGrounded += PlayerGrounded;
        animator.SetBool("isClimb", true);
        playerRigidbody.gravityScale = 0;
        ladder.DisableCollider();
    }

    public override void UpdateState(PlayerStateManager playerManager)
    {
        Climb();

        maincamera.transform.position = new Vector3(player.position.x, player.position.y, -1);

    }

    public override void ExitState(PlayerStateManager playerManager)
    {
        playerRigidbody.gravityScale = 2;
        animator.SetBool("isClimb", false);
        playerManager.SwitchState(playerManager.movementState);
        GroundDetector.OnPlayerGrounded -= PlayerGrounded;

        if (ladder != null)
        {
            ladder.EnableCollider();
        }

    }

    private void Climb()
    {
        Vector2 direction = playerInput.Player.Climb.ReadValue<Vector2>();

        player.Translate(direction * speed * Time.deltaTime);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            ExitState(playerManager);
        }
    }

    private void PlayerGrounded()
    {
        ExitState(playerManager);
    }

}
