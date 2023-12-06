using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControlHabilitation : MonoBehaviour
{
    void Start()
    {
       Time.timeScale = 1;
    }
    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
