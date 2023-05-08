using UnityEngine;
using UnityEngine.UI;

public class UIRaceRecord : MonoBehaviour, IDependency<RaceResultTime>, IDependency<RaceStateTracker>
{
    [SerializeField] private GameObject _goldRecordObject;
    [SerializeField] private GameObject _playerRecordObject;
    [SerializeField] private Text _goldRecordTime;
    [SerializeField] private Text _playerRecordTime;

    private RaceResultTime _raceResultTime;
    public void Construct(RaceResultTime obj) => _raceResultTime = obj;

    private RaceStateTracker _raceStateTracker;
    public void Construct(RaceStateTracker obj) => _raceStateTracker = obj;

    private void Start()
    {
        _raceStateTracker.Started += OnRaceStart;
        _raceStateTracker.Completed += OnRaceCompleted;

        _goldRecordObject.SetActive(false);
        _playerRecordObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _raceStateTracker.Started -= OnRaceStart;
        _raceStateTracker.Completed -= OnRaceCompleted;
    }

    private void OnRaceStart()
    {
        if (_raceResultTime.PlayerRecordTime > _raceResultTime.GoldTime || _raceResultTime.IsRecordWasSet == false)
        {
            _goldRecordObject.SetActive(true);
            _goldRecordTime.text = StringTime.SecondToTimeString(_raceResultTime.GoldTime);
        }

        if (_raceResultTime.IsRecordWasSet == true)
        {
            _playerRecordObject.SetActive(true);
            _playerRecordTime.text = StringTime.SecondToTimeString(_raceResultTime.PlayerRecordTime);
        }
    }

    private void OnRaceCompleted()
    {
        _goldRecordObject.SetActive(false);
        _playerRecordObject.SetActive(false);
    }
}