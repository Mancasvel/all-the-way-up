using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GlobalDelegateEvents;

public class MinigameTimerComponent : MonoBehaviour
{
    public static event OnLoseMinigame OnLoseEvent;

    float maxTimeRemainig = 60f;
    float timeRemainig;
    Slider timeRemainingRepresentation;
    bool miniGameRunning = true;

    private void Awake()
    {
        timeRemainingRepresentation = GetComponent<Slider>();
        timeRemainingRepresentation.minValue = 0;
        timeRemainingRepresentation.maxValue = maxTimeRemainig;
        timeRemainingRepresentation.value = maxTimeRemainig;
        timeRemainig = maxTimeRemainig;
    }

    private void Update()
    {
        if (miniGameRunning) { 
            if(timeRemainig <= 0)
            {
                OnLoseEvent?.Invoke();
                Time.timeScale = 0;
            } else
            {
                timeRemainig -= Time.deltaTime;
                timeRemainingRepresentation.value = timeRemainig;
            }
        }
    }

    protected void ModifyGameRunning(bool running)
    {
        miniGameRunning = running; 
    }
}
