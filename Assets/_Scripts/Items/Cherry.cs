using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip cherryPick;

    public bool isPicked = false;

    public static event Action OnCherryPicked;

    private void Start()
    {
        audioManager = AudioManager.instance;
        audioSource = audioManager.cherryAudioSource;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isPicked == false)
        {
            isPicked = true;
            audioSource.PlayOneShot(cherryPick);
            GameManager.cherriesAmount++;
            OnCherryPicked?.Invoke();
            gameObject.SetActive(false);
        }
    }

}
