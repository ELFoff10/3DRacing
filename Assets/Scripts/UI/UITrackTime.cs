using UnityEngine;
using UnityEngine.UI;

public class UITrackTime : MonoBehaviour, IDependency<RaceTimeTracker>, IDependency<RaceStateTracker>
{
    [SerializeField] private Text _text;

    private RaceTimeTracker _raceTimeTracker;
    public void Construct(RaceTimeTracker obj) => _raceTimeTracker = obj;

    private RaceStateTracker _raceStateTracker;
    public void Construct(RaceStateTracker obj) => _raceStateTracker = obj;

    private void Start()
    {
        _raceStateTracker.Started += OnRaceStarted;
        _raceStateTracker.Completed += OnRaceCompleted;

        _text.enabled = false;
    }

    private void OnDestroy()
    {
        _raceStateTracker.Started -= OnRaceStarted;
        _raceStateTracker.Completed -= OnRaceCompleted;
    }

    private void OnRaceStarted()
    {
        _text.enabled = true;
        enabled = true;
    }

    private void OnRaceCompleted()
    {
        _text.enabled = false;
        enabled = false;
    }

    private void Update()
    {
        _text.text = StringTime.SecondToTimeString(_raceTimeTracker.CurrentTime);
    }
}