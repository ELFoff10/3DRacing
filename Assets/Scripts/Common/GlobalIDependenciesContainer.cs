using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalIDependenciesContainer : Dependencies
{
    [SerializeField] private Pauser _pauser;

    private static GlobalIDependenciesContainer _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    protected override void BindAll(MonoBehaviour monoBehaviorInScene)
    {
        Bind<Pauser>(_pauser, monoBehaviorInScene);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode arg1)
    {
        FindAllObjectToBind();
    }
}
