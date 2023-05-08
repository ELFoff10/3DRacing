using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private const string MainMenuSceneTitle = "Main_Menu";

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenuSceneTitle);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}