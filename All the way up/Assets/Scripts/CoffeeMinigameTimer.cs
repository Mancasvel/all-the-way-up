using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMinigameTimer : MinigameTimerComponent
{
    private void OnEnable()
    {
        SliderMinigame.OnWinMinigame += OnWinMinigame;
    }

    private void OnDisable()
    {
        SliderMinigame.OnWinMinigame -= OnWinMinigame;
    }

    private void OnWinMinigame()
    {
        ModifyGameRunning(false);
    }
}
