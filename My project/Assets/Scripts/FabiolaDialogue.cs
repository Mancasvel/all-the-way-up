using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FabiolaDialogue : MonoBehaviour
{
    public GameObject playerNameTag;
    public GameObject FabiolaNameTag;

    public Image fabiolaImg;
    public GameObject dialoguePanel;
    public TMP_Text textComponent;

    public Color original;
    public Color mute;
    public string[] lines;
    public Button button;

    public int sceneName;
    public float textSpeed;
    private int index;
   
    void Start()
    {
        original = fabiolaImg.color ;
        fabiolaImg.color = mute;
        textComponent.text = string.Empty;
        BeginDialogue();
    }


    void Update()
    {
         if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
         {
                if(textComponent.text == lines[index])
                {
                    LineAfter();

                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
         }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (textComponent.text == lines[index])
            {
                LineBefore();

            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Change();
        }
    }

    public void Change()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void BeginDialogue()
    {
        index = 0;
        StartCoroutine(WriteLine());
    }
    IEnumerator WriteLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }


    void LineAfter()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(WriteLine());

            if (index == 1)
            {
                fabiolaImg.color = original;
                playerNameTag.SetActive(false);
                FabiolaNameTag.SetActive(true);
            }
            if (index == 2) 
            {
                fabiolaImg.color = mute;
                FabiolaNameTag.SetActive(false);
            }
            if (index == 3)
            {
                fabiolaImg.color = original;
                FabiolaNameTag.SetActive(true);
            }
            if (index == 4)
            {
                fabiolaImg.color = mute;
                FabiolaNameTag.SetActive(false);
            }
            if (index == 5)
            {
                fabiolaImg.color = original;
                FabiolaNameTag.SetActive(true);
            }
            if (index == 6)
            {
                fabiolaImg.color = mute;
                FabiolaNameTag.SetActive(false);
            }
        }
        else
        {
            Change();
        }
    }

    void LineBefore()
    {
        if (index > 0)
        {
            index--;
            textComponent.text = string.Empty;
            StartCoroutine(WriteLine());
            if (index == 0)
            {
                fabiolaImg.color = mute;
                playerNameTag.SetActive(true);
                FabiolaNameTag.SetActive(false);

            }
            if (index == 1)
            {
                fabiolaImg.color = original;
                FabiolaNameTag.SetActive(true);
            }
            if (index == 2) 
            {
                fabiolaImg.color = mute;
                FabiolaNameTag.SetActive(false);
            }
            if (index == 3)
            {
                fabiolaImg.color = original;
                FabiolaNameTag.SetActive(true);
            }
            if (index == 4)
            {
                fabiolaImg.color = mute;
                FabiolaNameTag.SetActive(false);
            }
            if (index == 5)
            {
                fabiolaImg.color = original;
                FabiolaNameTag.SetActive(true);
            }
        
        }
    }

}
