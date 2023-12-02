using System.Collections.Generic;
using UnityEngine;
using static GlobalDelegateEvents;

public class SliderMinigame : MonoBehaviour
{
    public static event OnWinMinigame OnWinMinigame;
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

    int currentSlider = 0;

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
            currentSlider++;
            if(currentSlider == gameSliders.Count)
            {
                OnWinMinigame?.Invoke();
            } else
            {
                gameSliders[currentSlider].StartMoving();
            }
        } else
        {
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
