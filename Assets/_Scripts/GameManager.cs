using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("References")]
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private Menu menu;

    [Header("Level Attributes")]
    [SerializeField] private Transform player;
    [SerializeField] private bool isLevelFinished = false;
    public GameObject[] cherries;
    public GameObject[] gems;
    public LevelData currentLevel;

    [Header("Stats")]
    public static int livesAmount = 3;
    public static int requiredCherriesAmount = 0;
    public static int cherriesAmount = 0;
    public static int gemsAmount = 0;
    public static int unlockedLevels = 1;

    [Header("UI")]
    [SerializeField] private Canvas loadingScreenCanvas;
    [SerializeField] private Canvas newApproachCanvas;
    [SerializeField] private TextMeshProUGUI livesAmountText;
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private Canvas finishLevelCanvas;
    [SerializeField] private TextMeshProUGUI livesAmountText_FinishLevel;
    [SerializeField] private TextMeshProUGUI gemsAmountText_FinishLevel;
    [SerializeField] private Canvas winGameCanvas;

    public static event Action OnSetLevel;

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

    void Start()
    {
        mainMenu = MainMenu.instance;
        menu = Menu.instance;
        Health.OnPlayerDead += GameStatus;
    }

    void Update()
    {
        if (Input.GetKeyDown("return") && isLevelFinished == true && SceneManager.GetActiveScene().buildIndex != 4)
        {
            finishLevelCanvas.enabled = false;
            mainMenu.LoadLevel(currentLevel.level + 1);
        }
        else if (Input.GetKeyDown("return") && isLevelFinished == true && SceneManager.GetActiveScene().buildIndex == 4)
        {
            isLevelFinished = false;
            menu.ExitToMainMenu();
        }
    }

    public void SetLevel(LevelData level)
    {
        loadingScreenCanvas.enabled = false;
        isLevelFinished = false;
        SetStats(level);
        SetPlayer(level);
        SetCherries();
        SetGems();
        OnSetLevel?.Invoke();
    }

    private void GameStatus()
    {
        if (livesAmount > 0)
        {
            StartCoroutine(RestartLevel());
        }
        else
        {
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator RestartLevel()
    {
        audioManager.TurnOffMusic();
        livesAmountText.text = livesAmount.ToString();
        newApproachCanvas.enabled = true;

        yield return new WaitForSeconds(3);

        SetLevel(currentLevel);
        audioManager.SetMusic(currentLevel);
        newApproachCanvas.enabled = false;
        StopCoroutine(RestartLevel());
    }

    private IEnumerator GameOver()
    {
        audioManager.TurnOffMusic();
        livesAmountText.text = livesAmount.ToString();
        gameOverCanvas.enabled = true;

        yield return new WaitForSeconds(3);

        gameOverCanvas.enabled = false;
        menu.ExitToMainMenu();
        StopCoroutine(GameOver());
    }

    #region Set Start Values
    private void SetStats(LevelData level)
    {
        cherriesAmount = 0;
        currentLevel = level;
        requiredCherriesAmount = level.requiredCherriesAmount;
        gemsAmount = level.gemsAmount;
    }

    private void SetPlayer(LevelData level)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        player.GetComponent<Health>().isDead = false;
        player.transform.localPosition = level.startPoint;
        player.gameObject.GetComponent<PlayerMovementState>().enabled = true;
    }

    private void SetCherries()
    {
        foreach (GameObject cherry in cherries)
        {
            cherry.SetActive(true);
            cherry.GetComponent<Cherry>().isPicked = false;
        }
    }

    private void SetGems()
    {
        foreach (GameObject gem in gems)
        {
            gem.SetActive(true);
            gem.GetComponent<Gem>().isPicked = false;
        }
    }

    #endregion

    public void FinishLevel()
    {
        finishLevelCanvas.enabled = true;
        livesAmountText_FinishLevel.text = livesAmount.ToString();
        gemsAmountText_FinishLevel.text = gemsAmount.ToString();
        isLevelFinished = true;
        player.GetComponent<PlayerMovementState>().enabled = false;
        audioManager.TurnOffMusic();
        unlockedLevels++;
    }

    public void WinGame()
    {
        finishLevelCanvas.enabled = true;
        livesAmountText_FinishLevel.text = livesAmount.ToString();
        gemsAmountText_FinishLevel.text = gemsAmount.ToString();
        isLevelFinished = true;
        player.GetComponent<PlayerMovementState>().enabled = false;
        audioManager.TurnOffMusic();
    }

}
