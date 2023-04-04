using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;

    [Header("Canvases")]
    [SerializeField] private Canvas mainMenuCanvas;
    [SerializeField] private Canvas levelsMenuCanvas;
    [SerializeField] private Canvas loadingScreenCanvas;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonSound;

    [Header("Buttons")]
    [SerializeField] private Button[] buttons;

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

    public void LoadLevel(int level)
    {
        mainMenuCanvas.enabled = false;
        levelsMenuCanvas.enabled = false;
        loadingScreenCanvas.enabled = true;
        audioSource.PlayOneShot(buttonSound);
        GameManager.unlockedLevels = level;
        GameManager.livesAmount = 3;
        SceneManager.LoadScene(level);
    }

    public void LevelsMenu()
    {
        levelsMenuCanvas.enabled = true;
        audioSource.PlayOneShot(buttonSound);
        CheckButtons();
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void CheckButtons()
    {
        for (int i = 0; i < GameManager.unlockedLevels; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void BackToMainMenu()
    {
        levelsMenuCanvas.enabled = false;
        mainMenuCanvas.enabled = true;
        audioSource.PlayOneShot(buttonSound);
    }

}
