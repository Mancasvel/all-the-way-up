using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreen : MonoBehaviour
{
   public void ChangeScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
