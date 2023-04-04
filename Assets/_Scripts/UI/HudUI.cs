using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI livesAmount;
    [SerializeField] private TextMeshProUGUI cherriesAmount;
    [SerializeField] private TextMeshProUGUI currentCherriesAmount;
    [SerializeField] private TextMeshProUGUI gemsAmount;

    void Start()
    {
        Cherry.OnCherryPicked += UpdateCurrentCherriesAmount;
        Gem.OnGemPicked += UpdateGemsAmount;
        GameManager.OnSetLevel += UpdateCherriesAmount;
        GameManager.OnSetLevel += UpdateCurrentCherriesAmount;
        GameManager.OnSetLevel += UpdateGemsAmount;
        GameManager.OnSetLevel += UpdateLivesAmount;
        Health.OnPlayerDead += UpdateLivesAmount;
    }

    void UpdateLivesAmount()
    {
        livesAmount.text = GameManager.livesAmount.ToString();
    }

    void UpdateCherriesAmount()
    {
        cherriesAmount.text = GameManager.requiredCherriesAmount.ToString();
    }

    void UpdateCurrentCherriesAmount()
    {
        currentCherriesAmount.text = GameManager.cherriesAmount.ToString();
    }

    void UpdateGemsAmount()
    {
        gemsAmount.text = GameManager.gemsAmount.ToString();
    }

}
