using UnityEngine;

public class CarCameraController : MonoBehaviour /*, IDependency<RaceStateTracker>, IDependency<Car>*/
{
    [SerializeField] private Car car;
    [SerializeField] private new Camera camera;
    [SerializeField] private CarCameraFollow follower;
    [SerializeField] private CarCameraShaker shaker;
    [SerializeField] private CarCameraFovCorrector fovCorrector;
    [SerializeField] private CarCameraPathFollower pathFollower;

    //public void Construct(Car obj) => _car = obj;

    [SerializeField] private RaceStateTracker raceStateTracker;
    //public void Construct(RaceStateTracker obj) => _raceStateTracker = obj;

    private void Awake()
    {
        follower.SetProperties(car, camera);
        shaker.SetProperties(car, camera);
        fovCorrector.SetProperties(car, camera);
    }

    private void Start()
    {
        raceStateTracker.PreparationStarted += OnPreparationsStarted;
        raceStateTracker.Completed += OnCompleted;

        follower.enabled = false;
        pathFollower.enabled = true;
    }

    private void OnDestroy()
    {
        raceStateTracker.PreparationStarted -= OnPreparationsStarted;
        raceStateTracker.Completed -= OnCompleted;
    }

    private void OnPreparationsStarted()
    {
        follower.enabled = true;
        pathFollower.enabled = false;
    }

    private void OnCompleted()
    {
        pathFollower.enabled = true;
        pathFollower.StartMoveToNearestPoint();
        pathFollower.SetLookTarget(car.transform);

        follower.enabled = false;
    }
}
