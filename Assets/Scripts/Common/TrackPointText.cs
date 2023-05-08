using UnityEngine;
using TMPro;

public class TrackPointText : MonoBehaviour, IDependency<RaceStateTracker>, IDependency<TrackPointCircuit>
{
    [SerializeField] private TrackPoint _trackPoint;
    [SerializeField] private TextMeshPro _text;

    private RaceStateTracker _raceStateTracker;
    public void Construct(RaceStateTracker obj) => _raceStateTracker = obj;

    private TrackPointCircuit _trackPointCircuit;
    public void Construct(TrackPointCircuit obj) => _trackPointCircuit = obj;

    private void FixedUpdate()
    {
        if (_trackPointCircuit.Type == TrackType.Circular)
        {
            if (_trackPoint.IsFirst == true && _trackPoint.IsLast == true && _trackPoint.IsFinish == false)
            {
                _text.text = "start";
            }
            else
            {
                _text.text = "check point";
            }

            if (_trackPoint.IsFirst == false && _trackPoint.IsLast == false)
            {
                _text.text = "check point";
            }

            if (_trackPoint.IsFirst == true && _trackPoint.IsLast == true && _trackPoint.IsFinish == true && _raceStateTracker.isLastCircle == true)
            {
                _text.text = "finish";
            }
        }

        if (_trackPointCircuit.Type == TrackType.Sprint)
        {
            if (_trackPoint.IsFirst == true && _trackPoint.IsLast == false)
            {
                _text.text = "start";
            }

            if (_trackPoint.IsFirst == false && _trackPoint.IsLast == true)
            {
                _text.text = "finish";
            }

            if (_trackPoint.IsFirst == false && _trackPoint.IsLast == false)
            {
                _text.text = "check point";
            }
        }

    }
}
