using UnityEngine;
using UnityEngine.Events;

public class RaceCompletedControl : MonoBehaviour, IDependency<RaceResultTime>
{
    private RaceResultTime _raceResultTime;
    public void Construct(RaceResultTime obj) => _raceResultTime = obj;

    [SerializeField] public UnityEvent EventLevelCompleted;

    [SerializeField] private int _raceCompleted = 0; //DEBUG

    private void Start()
    {
        _raceResultTime.ScoreUpdate += OnRaceCompleted;
    }

    private void OnDestroy()
    {
        _raceResultTime.ScoreUpdate -= OnRaceCompleted;
    }

    private void OnRaceCompleted()
    {
        if (_raceCompleted == 1) return;

        _raceCompleted = 1;

        LevelCompletion.SaveLevelResult(_raceCompleted);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.F5))
        {
            _raceCompleted = 0;
        }

        Debug.Log(_raceCompleted);
    }
}