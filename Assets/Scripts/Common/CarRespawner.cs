using System;
using UnityEngine;

public class CarRespawner : MonoBehaviour, IDependency<RaceStateTracker>, IDependency<Car>, IDependency<CarInputControl>
{
    [SerializeField] private float _respawnHeight;

    private TrackPoint _respawnTrackPoint;

    private RaceStateTracker _raceStateTracker;
    public void Construct(RaceStateTracker obj) => _raceStateTracker = obj;

    private Car _car;
    public void Construct(Car obj) => _car = obj;

    private CarInputControl _carInputControl;
    public void Construct(CarInputControl obj) => _carInputControl = obj;

    private void Start()
    {
        _raceStateTracker.TrackPointPassed += OnTrackPointPassed;
    }

    private void OnDestroy()
    {
        _raceStateTracker.TrackPointPassed -= OnTrackPointPassed;
    }

    private void OnTrackPointPassed(TrackPoint point)
    {
        _respawnTrackPoint = point;
    }

    public void Respawn()
    {
        if (_respawnTrackPoint == null) return;

        if (_raceStateTracker.State != RaceState.Race) return;

        _car.Respawn(_respawnTrackPoint.transform.position + _respawnTrackPoint.transform.up * _respawnHeight,
            _respawnTrackPoint.transform.rotation);

        _carInputControl.Reset();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) == true)
        {
            Respawn();
        }
    }
}
