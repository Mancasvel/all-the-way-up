using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMinigame : MinigameComponent
{
    [SerializeField]
    DragableItem item;

    private void OnEnable()
    {
        DragableItem.OnCollisionHappen += DetectCollision;
        DragableItem.OnReachEnd += DetectEndMaze;
    }

    private void OnDisable()
    {

        DragableItem.OnCollisionHappen -= DetectCollision;
        DragableItem.OnReachEnd -= DetectEndMaze;
    }

    private void DetectEndMaze()
    {
        OnWinMinigame();
    }

    private void DetectCollision()
    {
        item.transform.position = transform.position;
        item.LetItGo();
    }
}
