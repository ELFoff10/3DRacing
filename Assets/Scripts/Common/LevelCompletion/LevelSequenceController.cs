using UnityEngine.SceneManagement;

public class LevelSequenceController : MonoSingleton<LevelSequenceController>
{
    public static string MainMenuSceneNickname = "Main_Menu";

    public RaceInfo CurrentLevel { get; private set; }

    public int CurrentLevelNumber { get; private set; }

    public void StartLevel(RaceInfo e)
    {
        CurrentLevel = e;
        CurrentLevelNumber = 0;

        SceneManager.LoadScene(e.SceneName);
    }
}