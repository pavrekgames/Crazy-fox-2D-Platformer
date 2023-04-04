using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Gem : MonoBehaviour
{

    [SerializeField] private AudioManager audioManager;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gemPick;

    public bool isPicked = false;

    public static event Action OnGemPicked;

    private void Start()
    {
        audioManager = AudioManager.instance;
        audioSource = audioManager.gemAudioSource;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isPicked == false)
        {
            isPicked = true;
            audioSource.PlayOneShot(gemPick);
            GameManager.gemsAmount++;
            OnGemPicked?.Invoke();
            gameObject.SetActive(false);
        }
    }

}
