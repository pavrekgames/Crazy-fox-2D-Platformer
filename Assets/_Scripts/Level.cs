using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private LevelData levelData;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioManager audioManager;

    private void Start()
    {
        SetLevel();
        SetMusic();
    }

    private void SetLevel()
    {
        gameManager = GameManager.instance;
        gameManager.cherries = GameObject.FindGameObjectsWithTag("Cherry");
        gameManager.gems = GameObject.FindGameObjectsWithTag("Gem");
        gameManager.SetLevel(levelData);
    }

    private void SetMusic()
    {
        audioManager = AudioManager.instance;
        audioManager.SetMusic(levelData);
    }

}
