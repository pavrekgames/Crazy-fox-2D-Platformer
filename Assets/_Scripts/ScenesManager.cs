using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    [SerializeField] private Canvas mainMenuCanvas;
    [SerializeField] private AudioManager audioManager;

    void Start()
    {
        SceneManager.sceneLoaded += SetScene;
        audioManager = AudioManager.instance;
        mainMenuCanvas = GameObject.Find("Main Menu Canvas").GetComponent<Canvas>();
    }

    private void SetScene(Scene scene, LoadSceneMode loadScene)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            audioManager.TurnOffMusic();
            mainMenuCanvas.enabled = true;
        }
    }

}
