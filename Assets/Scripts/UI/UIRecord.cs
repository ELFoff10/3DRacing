using UnityEngine;
using UnityEngine.UI;

public class UIRecord : MonoBehaviour, IDependency<RaceResultTime>, IDependency<RaceStateTracker>, IDependency<RaceTimeTracker>
{
    [SerializeField] private GameObject _panelRecord;
    [SerializeField] private GameObject _newGoldRecordObject;
    [SerializeField] private Text _goldRecordTime;
    [SerializeField] private Text _playerRecordTime;
    [SerializeField] private Text _newGoldRecordTime;

    private RaceResultTime _raceResultTime;
    public void Construct(RaceResultTime obj) => _raceResultTime = obj;

    private RaceStateTracker _raceStateTracker;
    public void Construct(RaceStateTracker obj) => _raceStateTracker = obj;

    private RaceTimeTracker _raceTimeTracker;
    public void Construct(RaceTimeTracker obj) => _raceTimeTracker = obj;

    private void Start()
    {
        _raceStateTracker.Completed += OnRaceCompleted;

        _panelRecord.SetActive(false);
    }

    private void OnDestroy()
    {
        _raceStateTracker.Completed -= OnRaceCompleted;
    }

    private void OnRaceCompleted()
    {
        _panelRecord.SetActive(true);

        if (_raceResultTime.PlayerRecordTime > _raceTimeTracker.CurrentTime)
        {
            _newGoldRecordObject.SetActive(true);
            _newGoldRecordTime.enabled = true;
            _newGoldRecordTime.text = StringTime.SecondToTimeString(_raceTimeTracker.CurrentTime);
        }

        else
        {
            _newGoldRecordObject.SetActive(false);
            _newGoldRecordTime.enabled = false;
        }

        _goldRecordTime.text = StringTime.SecondToTimeString(_raceResultTime.PlayerRecordTime);
        _playerRecordTime.text = StringTime.SecondToTimeString(_raceTimeTracker.CurrentTime);
    }
}