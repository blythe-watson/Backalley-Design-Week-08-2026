using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void loadScene()
    {
        string sceneTitle = scene.name;
        SceneManager.LoadScene(sceneTitle);
    }
}
