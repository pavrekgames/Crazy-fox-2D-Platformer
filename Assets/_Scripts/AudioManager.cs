using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource musicAudioSource;
    public AudioSource cherryAudioSource;
    public AudioSource gemAudioSource;
    public AudioSource gameOverAudioSource;
    public AudioSource finishLevelAudioSource;

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

    public void SetMusic(LevelData levelData)
    {
        musicAudioSource.clip = levelData.backgroundMusic;
        musicAudioSource.Play();
    }

    public void TurnOffMusic()
    {
        musicAudioSource.Stop();
    }

}
