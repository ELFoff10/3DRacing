using UnityEngine;
using UnityEngine.UI;

public class UICountDownTimer : MonoBehaviour, IDependency<RaceStateTracker>
{
    [SerializeField] private Text _text;

    private Timer _countDownTimer;

    private RaceStateTracker _raceStateTracker;
    public void Construct(RaceStateTracker obj) => _raceStateTracker = obj;

    private void Start()
    {
        _raceStateTracker.PreparationStarted += OnRacePreparationStarted;
        _raceStateTracker.Started += OnRaceStarted;

        _text.enabled = false;
    }

    private void OnDestroy()
    {
        _raceStateTracker.PreparationStarted -= OnRacePreparationStarted;
        _raceStateTracker.Started -= OnRaceStarted;
    }

    private void OnRacePreparationStarted()
    {
        _text.enabled = true;
        enabled = true;
    }

    private void OnRaceStarted()
    {
        _text.enabled = false;
        enabled = false;
    }

    private void Update()
    {
        _text.text = _raceStateTracker.CountDownTimer.Value.ToString("F0");

        if (_text.text == "0")
        {
            _text.text = "GO!";
        }
    }
}
