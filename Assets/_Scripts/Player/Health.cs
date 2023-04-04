using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Base")]
    [SerializeField] private PlayerMovementState playerMovement;
    [SerializeField] private Animator animator;
    public bool isDead = false;

    [Header("Audio")]
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deadSound;

    public static event Action OnPlayerDead;

    void Start()
    {
        audioManager = AudioManager.instance;
        audioSource = audioManager.gameOverAudioSource;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && isDead == false)
        {
            Dead();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy") && isDead == false)
        {
            Dead();
        }
    }

    private void Dead()
    {
        animator.SetBool("isRun", false);
        animator.SetTrigger("dead");
        playerMovement.enabled = false;
        GameManager.livesAmount--;
        isDead = true;
        audioSource.PlayOneShot(deadSound);
    }

    public void InvokeDead()
    {
        animator.SetTrigger("restart");
        OnPlayerDead?.Invoke();
    }

}
