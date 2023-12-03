using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameComponent : MonoBehaviour
{

    public static event Action OnWinMinigameAction;

    protected void OnWinMinigame()
    {
        OnWinMinigameAction?.Invoke();
    }
}
