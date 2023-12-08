using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogueHelper : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text textComponent;
    public string[] lines;
    public UnityEvent OnFinishText = new UnityEvent();
    public float textSpeed;
    [SerializeField]
    private int index = 0;
    private float initialWaitText = 1f;
    [SerializeField]
    private bool isTyping = false;

    IEnumerator Start()
    {
        textComponent.text = string.Empty;
        yield return new WaitForSeconds(initialWaitText);
        if (dialoguePanel)
        {
            dialoguePanel.SetActive(true);
        }
        NextLine();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (isLastText() && !isTyping)
            {
                OnFinishText?.Invoke();
            }
            else
            {
                if (!isTyping)
                {
                    NextLine();
                }
                else
                {
                    PrintLineComplete();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousLine();
        }
    }



    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            ResetTyping();
        }
    }
    void PreviousLine()
    {
        StopAllCoroutines();
        if (index > 0)
        {
            index--;
            PrintLineComplete();
        }

    }
    void PrintLineComplete()
    {
        StopAllCoroutines();
        isTyping = false;
        textComponent.text = lines[index];
    }


    void ResetTyping()
    {

        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        isTyping = true;
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        isTyping = false;
    }
    bool isLastText()
    {
        return index == lines.Length - 1;
    }
}
