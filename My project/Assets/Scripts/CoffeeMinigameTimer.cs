using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMinigameTimer : MinigameTimerComponent
{
    private void OnEnable()
    {
        MinigameComponent.OnWinMinigameAction += OnWinMinigame;
    }

    private void OnDisable()
    {
        MinigameComponent.OnWinMinigameAction -= OnWinMinigame;
    }

    private void OnWinMinigame()
    {
        ModifyGameRunning
            (false);
    }
}
