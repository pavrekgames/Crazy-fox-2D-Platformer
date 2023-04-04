using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private bool hasFinished = false;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip finishLevelSound;

    void Start()
    {
        gameManager = GameManager.instance;

        audioManager = AudioManager.instance;
        audioSource = audioManager.finishLevelAudioSource;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && hasFinished == false)
        {
            if (GameManager.cherriesAmount == GameManager.requiredCherriesAmount && SceneManager.GetActiveScene().buildIndex != 4)
            {
                gameManager.FinishLevel();
                audioSource.PlayOneShot(finishLevelSound);
            }
            else if (GameManager.cherriesAmount == GameManager.requiredCherriesAmount && SceneManager.GetActiveScene().buildIndex == 4)
            {
                gameManager.WinGame();
                audioSource.PlayOneShot(finishLevelSound);
            }
        }
    }

}
