using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalDelegateEvents
{
    public delegate void OnWinMinigame();
    public delegate void OnLoseMinigame();
    public delegate int OnClickMinigameItem();
}
