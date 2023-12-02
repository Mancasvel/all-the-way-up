using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MinigameResultComposer : MonoBehaviour
{

    public UnityEvent OnWinEvent;
    public UnityEvent OnLoseEvent;


    private void OnEnable()
    {
        SliderMinigame.OnWinMinigame += OnWin;
        MinigameTimerComponent.OnLoseEvent += OnLose;
    }

    private void OnWin()
    {
        OnWinEvent?.Invoke();
    }

    private void OnLose()
    {
        OnLoseEvent?.Invoke();

    }
}
