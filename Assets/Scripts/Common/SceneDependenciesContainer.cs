using UnityEngine;

public interface IDependency<T>
{
    void Construct(T obj);
}

public class SceneDependenciesContainer : Dependencies
{
    [SerializeField] private RaceStateTracker _raceStateTracker;
    [SerializeField] private RaceTimeTracker _raceTimeTracker;
    [SerializeField] private RaceResultTime _raceResultTime;
    [SerializeField] private CarInputControl _carInputControl;
    [SerializeField] private TrackPointCircuit _trackPointCircuit;
    [SerializeField] private Car _car;
    [SerializeField] private CarCameraController _carCameraController;

    protected override void BindAll(MonoBehaviour monoBehaviorInScene)
    {
        Bind<RaceStateTracker>(_raceStateTracker, monoBehaviorInScene);
        Bind<CarInputControl>(_carInputControl, monoBehaviorInScene);
        Bind<TrackPointCircuit>(_trackPointCircuit, monoBehaviorInScene);
        Bind<Car>(_car, monoBehaviorInScene);
        Bind<CarCameraController>(_carCameraController, monoBehaviorInScene);
        Bind<RaceTimeTracker>(_raceTimeTracker, monoBehaviorInScene);
        Bind<RaceResultTime>(_raceResultTime, monoBehaviorInScene);
    }


    #region 3 way setting
    //1 Вариант
    /*private void Bind(MonoBehaviour mono)
    {
        if (mono is IDependency<RaceStateTracker>)
        {
            (mono as IDependency<RaceStateTracker>).Construct(_raceStateTracker);
        }

        if (mono is IDependency<CarInputControl>)
        {
            (mono as IDependency<CarInputControl>).Construct(_carInputControl);
        }

        if (mono is IDependency<TrackPointCircuit>)
        {
            (mono as IDependency<TrackPointCircuit>).Construct(_trackPointCircuit);
        }

        if (mono is IDependency<Car>)
        {
            (mono as IDependency<Car>).Construct(_car);
        }

        if (mono is IDependency<CarCameraController>)
        {
            (mono as IDependency<CarCameraController>).Construct(_carCameraController);
        }

        if (mono is IDependency<RaceTimeTracker>)
        {
            (mono as IDependency<RaceTimeTracker>).Construct(_raceTimeTracker);
        }

        if (mono is IDependency<RaceResultTime>)
        {
            (mono as IDependency<RaceResultTime>).Construct(_raceResultTime);
        }
    }*/

    //2 Вариант
    /*    private void Bind(MonoBehaviour mono)
        {
            IDependency<TrackPointCircuit> t = mono as IDependency<TrackPointCircuit>;

            if (t != null)
            {
                t.Construct(_trackPointCircuit);
            }
        }*/

    //3 Вариант 
    /*    private void Bind(MonoBehaviour mono)
        {
            (mono as IDependency<TrackPointCircuit>)?.Construct(_trackPointCircuit);
        }*/

    #endregion

    /*    private void Awake()
        {
            MonoBehaviour[] allMonoBehavioursInScene = FindObjectsOfType<MonoBehaviour>();

            for (int i = 0; i < allMonoBehavioursInScene.Length; i++)
            {
                Bind(allMonoBehavioursInScene[i]);
            }
        }*/

    private void Awake()
    {
        FindAllObjectToBind();
    }
}