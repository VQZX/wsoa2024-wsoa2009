using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    /// <summary>
    /// Change the scene to <paramref name="sceneName"></paramref>.
    /// </summary>
    /// <param name="sceneName">
    /// The scene to change to.
    /// </param>
    public void ChangeScenes(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
