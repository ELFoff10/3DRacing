using System;
using UnityEngine;

public class RaceInputController : MonoBehaviour, IDependency<CarInputControl>, IDependency<RaceStateTracker>
{
    private CarInputControl _carControl;
    public void Construct(CarInputControl obj) => _carControl = obj;

    private RaceStateTracker _raceStateTracker;
    public void Construct(RaceStateTracker obj) => _raceStateTracker = obj;

    private void Start()
    {
        _raceStateTracker.Started += OnRaceStarted;
        _raceStateTracker.Completed += OnRaceFinished;

        _carControl.enabled = false;
    }

    private void OnDestroy()
    {
        _raceStateTracker.Started -= OnRaceStarted;
        _raceStateTracker.Completed -= OnRaceFinished;
    }

    private void OnRaceStarted()
    {
        _carControl.enabled = true;
    }
 
    private void OnRaceFinished()
    {
        _carControl.Stop();
        _carControl.enabled = false;
    }
}
