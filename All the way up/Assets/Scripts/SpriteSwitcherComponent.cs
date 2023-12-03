using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GlobalDelegateEvents;

public class SpriteSwitcherComponent : MonoBehaviour
{
    Image image;
    Button button;
    [SerializeField]
    Sprite showingSprite;
    [SerializeField]
    Sprite hiddenSprite;
    [SerializeField]
    int order;
    TMP_Text orderText;

    public static event Action<int> OnClickItemEvent;

    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        orderText = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        MemoryMinigame.OnResetItems += ResetImage;
    }

    private void OnDisable()
    {

        MemoryMinigame.OnResetItems -= ResetImage;
    }

    public void UnsuscribeReset()
    {
        MemoryMinigame.OnResetItems -= ResetImage;
    }
    public void Init(Sprite showingSprite,  Sprite hiddenSprite, int order, bool showOrder)
    {
        this.showingSprite = showingSprite;
        this.hiddenSprite = hiddenSprite;
        this.order = order;
        orderText.text = "";
        orderText.gameObject.SetActive(showOrder);
        ResetImage();
        button.onClick.AddListener(delegate () { ClickOnItem(); });
    }

    private void ClickOnItem()
    {
        OnClickItemEvent?.Invoke(order);

    }
    public void ShowSprite(int order)
    {
        orderText.text = order.ToString();
        ShowSprite();
    }
    public void ShowSprite()
    {
        image.sprite = showingSprite;
        button.interactable = false;
    }

    public void ResetImage()
    {
        image.sprite = hiddenSprite;
        button.interactable = true;
    }
}
