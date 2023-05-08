using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class RaceResultTime : MonoBehaviour, IDependency<RaceTimeTracker>, IDependency<RaceStateTracker>
{
    public const string SaveMark = "_player_best_time";

    public event UnityAction ResultUpdated;
    public event UnityAction ScoreUpdate;

    [SerializeField] private float _goldTime;
    public float GoldTime => _goldTime; 

    public bool IsRecordWasSet => _playerRecordTime != 0;

    private float _playerRecordTime;
    public float PlayerRecordTime => _playerRecordTime;

    private float _currentTime;
    public float CurrentTime => _currentTime;

    private RaceTimeTracker _raceTimeTracker;
    public void Construct(RaceTimeTracker obj) => _raceTimeTracker = obj;

    private RaceStateTracker _raceStateTracker;
    public void Construct(RaceStateTracker obj) => _raceStateTracker = obj;

    private bool isCompleted = false;
    public bool IsCompleted => isCompleted;

    private void Awake()
    {
        Load();
    }

    private void Start()
    {
        _raceStateTracker.Completed += OnRaceCompleted;
    }

    private void OnDestroy()
    {
        _raceStateTracker.Completed -= OnRaceCompleted;
    }

    private void OnRaceCompleted()
    {
        float absoluteRecord = GetAbsoluteRecord();

        if (_raceTimeTracker.CurrentTime < absoluteRecord || _playerRecordTime == 0)
        {
            _playerRecordTime = _raceTimeTracker.CurrentTime;

            Save();
        }

        _currentTime = _raceTimeTracker.CurrentTime;

        ResultUpdated?.Invoke();
    }

    public float GetAbsoluteRecord()
    {
        if (_playerRecordTime < _goldTime && _playerRecordTime != 0)
        {
            ScoreUpdate?.Invoke();
            return _playerRecordTime;
        }
        else
        {
            return _goldTime;
        }
    }

    private void Load()
    {
        _playerRecordTime = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + SaveMark, 0);
    }

    private void Save()
    {
        PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + SaveMark, _playerRecordTime);
    }
}