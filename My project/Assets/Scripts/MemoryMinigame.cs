using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MemoryMinigame : MinigameComponent
{
    [SerializeField]
    List<FridgeItemData> itemsData;
    [SerializeField]
    List<int> orderToComplete = new List<int>();
    int currentSelected = 0;
    [SerializeField]
    GameObject fridgeItemPrefab;
    [SerializeField]
    Transform fridgeItemClues;

    [SerializeField]
    AudioSource audioSource;

    
    [SerializeField]
    AudioClip successClip;
    [SerializeField]
    AudioClip wrongClip;

    List<SpriteSwitcherComponent> fridgeItems = new List<SpriteSwitcherComponent>();
    List<SpriteSwitcherComponent> fridgeItemsClues = new List<SpriteSwitcherComponent>();

    public static event Action OnResetItems;
    public static event Action OnCorrectSelected;

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        int order = 0;
        foreach(FridgeItemData data in itemsData)
        {
            SpriteSwitcherComponent item = Instantiate(fridgeItemPrefab, transform).AddComponent<SpriteSwitcherComponent>();
            SpriteSwitcherComponent clue = Instantiate(fridgeItemPrefab, fridgeItemClues).AddComponent<SpriteSwitcherComponent>();
            item.Init(data.showingSprite, data.hiddenSprite, order, false, true);
            clue.Init(data.showingSprite, data.hiddenSprite, order, true, false);
            clue.UnsuscribeReset();
            fridgeItems.Add(item);
            fridgeItemsClues.Add(clue);
            orderToComplete.Add(order);
            order++;
        }

        SpriteSwitcherComponent.OnClickItemEvent += OnClickedItem;
        orderToComplete = orderToComplete.OrderBy(x => UnityEngine.Random.Range(0, int.MaxValue)).ToList(); ;
    }
    private void OnDisable()
    {
        SpriteSwitcherComponent.OnClickItemEvent -= OnClickedItem;
    }
    private void Update()
    {
        if(currentSelected == orderToComplete.Count)
        {
            OnWinMinigame();
        }
    }
    private void OnClickedItem(int order)
    {
        if(orderToComplete[currentSelected] == order)
        {
            audioSource.PlayOneShot(successClip);
            fridgeItems[order].ShowSprite();
            fridgeItemsClues[order].ShowSprite(currentSelected+1);
            currentSelected++;
        } else
        {
            audioSource.PlayOneShot(wrongClip);
            fridgeItems[order].ResetImage();
            currentSelected = 0; 
            OnResetItems?.Invoke();
        }
    }
}
