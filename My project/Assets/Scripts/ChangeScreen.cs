using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreen : MonoBehaviour
{
    [SerializeField]
    string sceneName;
   public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void doExitGame()
    {
        Application.Quit();
        Debug.Log("Aplication exit");
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
