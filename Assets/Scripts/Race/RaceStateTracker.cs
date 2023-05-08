using UnityEngine;
using UnityEngine.Events;

public enum RaceState
{
    Preparation,
    CoundDown,
    Race,
    Passed
}

public class RaceStateTracker : MonoBehaviour/*, IDependency<TrackPointCircuit>*/
{
    public event UnityAction PreparationStarted;
    public event UnityAction Started;
    public event UnityAction Completed;
    public event UnityAction<TrackPoint> TrackPointPassed;
    public event UnityAction<int> LapCompleted;

    private TrackPointCircuit trackPointCircuit;
    //public void Construct(TrackPointCircuit trackPointCircuit) => this._trackPointCircuit = trackPointCircuit; 2 вариант

    //[SerializeField] private Timer _countDownTimer;
    //public Timer CountDownTimer => _countDownTimer;

    [SerializeField] private int _lapsToComplete;

    public bool isLastCircle = false;

    private RaceState state;
    public RaceState State => state;

    private void StartState(RaceState state)
    {
        this.state = state;
    }

    public void Construct(TrackPointCircuit trackPointCircuit)
    {
        this.trackPointCircuit = trackPointCircuit;
    }

    private void Start()
    {
        StartState(RaceState.Preparation);
        
        if (_lapsToComplete == 1)
        {
            isLastCircle = true;
        }

        _countDownTimer.enabled = false;

        _countDownTimer.Finished += OnCountDownTimerFinished;

        trackPointCircuit.TrackPointTriggered += OnTrackPointTriggered;
        trackPointCircuit.LapCompleted += OnLapCompleted;
    }

    private void OnDestroy()
    {
        _countDownTimer.Finished -= OnCountDownTimerFinished;

        trackPointCircuit.TrackPointTriggered -= OnTrackPointTriggered;
        trackPointCircuit.LapCompleted -= OnLapCompleted;
    }

    private void OnTrackPointTriggered(TrackPoint trackPoint)
    {
        TrackPointPassed?.Invoke(trackPoint);
    }

    private void OnCountDownTimerFinished()
    {
        StartRace();
    }

    private void OnLapCompleted(int lapAmount)
    {
        if (trackPointCircuit.Type == TrackType.Sprint)
        {
            CompleteRace();
        }

        if (trackPointCircuit.Type == TrackType.Circular)
        {
            if (lapAmount == _lapsToComplete)
            {
                CompleteRace();
            }

            if ((lapAmount + 1) == _lapsToComplete)
            {
                isLastCircle = true;
            }
        }
        else
        {
            CompleteLap(lapAmount);
        }
    }

    public void LaunchPeparationStarted()
    {
        if (state != RaceState.Preparation)
        {
            return;
        }

        StartState(RaceState.CoundDown);

        _countDownTimer.enabled = true;

        PreparationStarted?.Invoke();
    }

    private void StartRace()
    {
        if (state != RaceState.CoundDown)
        {
            return;
        }

        StartState(RaceState.Race);

        Started?.Invoke();
    }

    private void CompleteRace()
    {
        if (state != RaceState.Race)
        {
            return;
        }

        StartState(RaceState.Passed);

        Completed?.Invoke();
    }

    private void CompleteLap(int lapAmount)
    {
        LapCompleted?.Invoke(lapAmount);
    }
}
