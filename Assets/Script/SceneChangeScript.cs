using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    
    public void LoadingScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
