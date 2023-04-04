using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public static Menu instance;

    [Header("References")]
    [SerializeField] private PlayerMovementState playerMovement;

    [Header("Canvases")]
    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private Canvas loadingScreenCanvas;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonSound;
    [SerializeField] private AudioMixerSnapshot pauseAudioSnapshot;
    [SerializeField] private AudioMixerSnapshot unpauseAudioSnapshot;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (Input.GetKeyDown("escape") && Time.timeScale == 1)
            {
                PauseGame();
            }
            else if (Input.GetKeyDown("escape") && Time.timeScale == 0)
            {
                ResumeGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        pauseAudioSnapshot.TransitionTo(0.01f);
        menuCanvas.enabled = true;
        audioSource.PlayOneShot(buttonSound);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        unpauseAudioSnapshot.TransitionTo(0.01f);
        menuCanvas.enabled = false;
        audioSource.PlayOneShot(buttonSound);
    }

    public void ExitToMainMenu()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementState>();
        playerMovement.enabled = false;
        Time.timeScale = 1;
        unpauseAudioSnapshot.TransitionTo(0.01f);
        menuCanvas.enabled = false;
        loadingScreenCanvas.enabled = true;
        audioSource.PlayOneShot(buttonSound);
        SceneManager.LoadScene(0);
    }

}
