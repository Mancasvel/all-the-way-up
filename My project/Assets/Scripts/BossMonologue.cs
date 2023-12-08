using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossMonologue : MonoBehaviour
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
        Dialogue();
    }


    void Update()
    {
         if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
         {
                if(textComponent.text == lines[index])
                {
                    Next();

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
                Before();

            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Jump();
        }
    }

    public void Jump()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Dialogue()
    {
        index = 0;
        StartCoroutine(Write());
    }
    IEnumerator Write()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }


    void Next()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(Write());

            if (index >= 1)
            {
                fabiolaImg.color = original;
                playerNameTag.SetActive(false);
                FabiolaNameTag.SetActive(true);
            }
            if (index == 3) 
            {
                fabiolaImg.gameObject.SetActive(false);
                FabiolaNameTag.SetActive(false);
                playerNameTag.SetActive(true);
            }
        }
        else
        {
            Jump();
        }
    }

    void Before()
    {
        if (index > 0)
        {
            index--;
            textComponent.text = string.Empty;
            StartCoroutine(Write());
            if (index == 0)
            {
                fabiolaImg.color = mute;
                playerNameTag.SetActive(true);
                FabiolaNameTag.SetActive(false);

            }
            if (index <= 2)
            {
                fabiolaImg.color = original;
                FabiolaNameTag.SetActive(true);
                fabiolaImg.gameObject.SetActive(true);
            }
           
        }
    }

}
