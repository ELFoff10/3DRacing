using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIRecord : MonoBehaviour, IDependency<RaceResultTime>, IDependency<RaceStateTracker>, IDependency<RaceTimeTracker>
{
    [SerializeField] private GameObject panelRecord;
    [SerializeField] private GameObject newGoldRecordObject;
    [SerializeField] private TextMeshProUGUI goldRecordTime;
    [SerializeField] private TextMeshProUGUI playerRecordTime;
    [SerializeField] private TextMeshProUGUI newGoldRecordTime;

    private RaceResultTime raceResultTime;
    public void Construct(RaceResultTime obj) => raceResultTime = obj;

    private RaceStateTracker raceStateTracker;
    public void Construct(RaceStateTracker obj) => raceStateTracker = obj;

    private RaceTimeTracker raceTimeTracker;
    public void Construct(RaceTimeTracker obj) => raceTimeTracker = obj;

    private void Start()
    {
        raceStateTracker.Completed += OnRaceCompleted;

        panelRecord.SetActive(false);
    }

    private void OnDestroy()
    {
        raceStateTracker.Completed -= OnRaceCompleted;
    }

    private void OnRaceCompleted()
    {
        panelRecord.SetActive(true);

        if (raceResultTime.PlayerRecordTime > raceTimeTracker.CurrentTime)
        {
            newGoldRecordObject.SetActive(true);
            newGoldRecordTime.enabled = true;
            newGoldRecordTime.text = StringTime.SecondToTimeString(raceTimeTracker.CurrentTime);
        }

        else
        {
            newGoldRecordObject.SetActive(false);
            newGoldRecordTime.enabled = false;
        }

        goldRecordTime.text = StringTime.SecondToTimeString(raceResultTime.PlayerRecordTime);
        playerRecordTime.text = StringTime.SecondToTimeString(raceTimeTracker.CurrentTime);
    }
}