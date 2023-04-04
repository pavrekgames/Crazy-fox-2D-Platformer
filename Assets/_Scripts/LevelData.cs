using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData")]
public class LevelData : ScriptableObject
{

    public int level;
    public int requiredCherriesAmount;
    public int gemsAmount;
    public AudioClip backgroundMusic;
    public Vector3 startPoint;

}
