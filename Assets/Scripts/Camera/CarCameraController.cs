using UnityEngine;

public class CarCameraController : MonoBehaviour, IDependency<RaceStateTracker>, IDependency<Car>
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CarCameraFollow _follower;
    [SerializeField] private CarCameraShaker _shaker;
    [SerializeField] private CarCameraFovCorrector _fovCorrector;
    [SerializeField] private CameraPathFollower _pathFollower;

    private Car _car;
    public void Construct(Car obj) => _car = obj;

    private RaceStateTracker _raceStateTracker;
    public void Construct(RaceStateTracker obj) => _raceStateTracker = obj;

    private void Awake()
    {
        _follower.SetProperties(_car, _camera);
        _shaker.SetProperties(_car, _camera);
        _fovCorrector.SetProperties(_car, _camera);
    }

    private void Start()
    {
        _raceStateTracker.PreparationStarted += OnPreparationsStarted;
        _raceStateTracker.Completed += OnCompleted;

        _follower.enabled = false;
        //_pathFollower.enabled = true;
    }

    private void OnDestroy()
    {
        _raceStateTracker.PreparationStarted -= OnPreparationsStarted;
        _raceStateTracker.Completed -= OnCompleted;
    }

    private void OnPreparationsStarted()
    {
        _follower.enabled = true;
        //_pathFollower.enabled = false;
    }

    private void OnCompleted()
    {
        /*_pathFollower.enabled = true;
        _pathFollower.StartMoveToNearestPoint();
        _pathFollower.SetLookTarget(_car.transform);*/

        _follower.enabled = false;
    }
}
