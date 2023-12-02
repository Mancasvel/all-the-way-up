using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static GlobalDelegateEvents;

public class MovingSliderComponent : MonoBehaviour
{
    Slider slider;
    [SerializeField]
    MovingSliderData data;

    [SerializeField]
    RectTransform successZone;
    bool isMoving = false;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        successZone.SetLeft(data.visualInit);
        successZone.SetRight(data.visualEnd);
    }

    private void Update()
    {
        if (isMoving)
        {
            SliderMovement();
        }
    }

    private void SliderMovement()
    {
        float targetValue = Mathf.PingPong(Time.time * data.speed, 1.0f);
        slider.value = Mathf.Lerp(slider.minValue, slider.maxValue, targetValue);
    }
    public bool IsSuccess()
    {
        isMoving = false;
        return slider.value >= data.valueInint && slider.value <= data.valueEnd;
    }

    public void StartMoving()
    {
        isMoving = true;
    }

    public void ResetMovement()
    {
        slider.value = 0;
    }
}
