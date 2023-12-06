using System.Collections.Generic;
using UnityEngine;
using static GlobalDelegateEvents;

[RequireComponent(typeof(AudioSource))]
public class SliderMinigame : MinigameComponent
{
    [SerializeField]
    List<GameObject> easySliderPrefabs;
    [SerializeField]
    List<GameObject> mediumSliderPrefabs;
    [SerializeField]
    List<GameObject> hardSliderPrefabs;

    [SerializeField]
    Transform easySliderPosition;
    [SerializeField]
    Transform mediumSliderPosition;
    [SerializeField]
    Transform hardSliderPosition;
    [SerializeField]
    List<MovingSliderComponent> gameSliders = new List<MovingSliderComponent>();
    [SerializeField]
    AudioClip successClip;
    [SerializeField]
    AudioClip wrongClip;

    AudioSource audioSource;

    int currentSlider = 0;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        MovingSliderComponent easyMovingSlider = Instantiate(easySliderPrefabs[Random.Range(0, easySliderPrefabs.Count)], gameObject.transform).GetComponent<MovingSliderComponent>();
        easyMovingSlider.transform.position = easySliderPosition.position;
        gameSliders.Add(easyMovingSlider);

        MovingSliderComponent mediumMovingSlider = Instantiate(mediumSliderPrefabs[Random.Range(0, mediumSliderPrefabs.Count)], gameObject.transform).GetComponent<MovingSliderComponent>();
        mediumMovingSlider.transform.position = mediumSliderPosition.position;
        gameSliders.Add(mediumMovingSlider);

        MovingSliderComponent hardMovingSlider = Instantiate(hardSliderPrefabs[Random.Range(0, hardSliderPrefabs.Count)], gameObject.transform).GetComponent<MovingSliderComponent>();
        hardMovingSlider.transform.position = hardSliderPosition.position;
        gameSliders.Add(hardMovingSlider);

        gameSliders[currentSlider].StartMoving();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttemptSelection();
        }
    }

    public void AttemptSelection()
    {
        bool success = gameSliders[currentSlider].IsSuccess();
        if (success)
        {
            audioSource.PlayOneShot(successClip);
            currentSlider++;
            if(currentSlider == gameSliders.Count)
            {
                OnWinMinigame();
            } else
            {
                gameSliders[currentSlider].StartMoving();
            }
        } else
        {
            audioSource.PlayOneShot(wrongClip);
            currentSlider = 0;
            ResetSliders();
            gameSliders[currentSlider].StartMoving();
        }
    }

    private void ResetSliders()
    {
        foreach(MovingSliderComponent gameSlider in gameSliders){
            gameSlider.ResetMovement();
        }
    }
}
