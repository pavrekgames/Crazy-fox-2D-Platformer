using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] PlayerMovementState playerMovement;
    public bool isGrounded = false;

    public static event Action OnPlayerGrounded;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Terrain") && isGrounded == false)
        {
            isGrounded = true;
            playerMovement.isGround = isGrounded;
            OnPlayerGrounded?.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Terrain") && isGrounded == false)
        {
            isGrounded = true;
            playerMovement.isGround = isGrounded;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Terrain") && isGrounded == true)
        {
            isGrounded = false;
            playerMovement.isGround = isGrounded;
        }
    }

}
