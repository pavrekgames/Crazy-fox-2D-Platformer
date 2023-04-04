using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovementState : PlayerBaseState
{
    [SerializeField] private PlayerInputActions playerInput;
    [SerializeField] private PlayerLadderState ladderState;

    [Header("Components")]
    [SerializeField] private Transform player;
    [SerializeField] private Camera maincamera;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpSound;

    [Header("Values")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private bool isRight = true;
    [SerializeField] private bool isOnLadder = false;

    public bool isGround = false;

    private void Start()
    {
        playerInput = new PlayerInputActions();
        playerInput.Enable();
    }

    public override void EnterState(PlayerStateManager playerManager)
    {
        spriteRenderer.flipX = false;
        isOnLadder = false;
    }

    public override void UpdateState(PlayerStateManager playerManager)
    {
        if (Time.timeScale == 1)
        {
            Run();
            Jump();
            StartClimb(playerManager);
        }

        maincamera.transform.position = new Vector3(player.position.x, player.position.y, -1);

    }

    public override void ExitState(PlayerStateManager playerManager)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder") && isOnLadder == false)
        {
            isOnLadder = true;
            ladderState.ladder = collision.GetComponent<Ladder>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder") && isOnLadder == false)
        {
            isOnLadder = true;
            ladderState.ladder = collision.GetComponent<Ladder>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder") && isOnLadder == true)
        {
            isOnLadder = false;
        }
    }

    #region Movement Functions

    private void Run()
    {
        Vector2 direction = playerInput.Player.Movement.ReadValue<Vector2>();

        player.Translate(direction * speed * Time.deltaTime);

        if (direction == Vector2.right)
        {
            animator.SetBool("isRun", true);
            spriteRenderer.flipX = false;
        }
        else if (direction == Vector2.left)
        {
            animator.SetBool("isRun", true);
            spriteRenderer.flipX = true;
        }
        else if (direction == Vector2.zero)
        {
            animator.SetBool("isRun", false);
        }

    }

    private void Jump()
    {
        bool isKeyPressed = playerInput.Player.Jump.ReadValue<float>() > 0.1f;

        if (isKeyPressed && isGround)
        {
            playerRigidbody.velocity = new Vector2(0, jumpHeight);
            animator.SetTrigger("jump");
            audioSource.PlayOneShot(jumpSound);
        }
    }

    private void StartClimb(PlayerStateManager playerManager)
    {
        if (isOnLadder)
        {
            if (playerInput.Player.StartClimb.WasPressedThisFrame())
            {
                playerManager.SwitchState(playerManager.ladderState);
            }
        }
    }

    #endregion
}
