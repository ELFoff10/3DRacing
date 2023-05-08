using UnityEngine;
using UnityEngine.UI;

public class LevelMap : MonoBehaviour
{
    [SerializeField] private RaceInfo _raceInfo;

    [SerializeField] private Image _icon;
    [SerializeField] private Text _title;

    [SerializeField] private GameObject _lockPanel;
    public GameObject LockPanel => _lockPanel;

    public void LoadLevel()
    {
        LevelSequenceController.Instance.StartLevel(_raceInfo);
    }

    public int Initialise()
    {
        var score = LevelCompletion.Instance.GetEpisodeScore(_raceInfo);
        return score;
    }

    public void SetLevelData(RaceInfo race, int score)
    {
        _raceInfo = race;
    }

    private void Start()
    {
        ApplyProperty(_raceInfo);
    }

    public void ApplyProperty(ScriptableObject property)
    {
        _raceInfo = property as RaceInfo;

        _icon.sprite = _raceInfo.Icon;
        _title.text = _raceInfo.Title;
    }
}
