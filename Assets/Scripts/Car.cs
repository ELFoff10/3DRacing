using UnityEngine;

[RequireComponent (typeof(CarChassis))]
/// <summary>
/// Информационная модель автомобиля.
/// </summary>

// Основная идея, что мы CarChassis выступает посредником, для получения данных из WheelAxle
public class Car : MonoBehaviour // Все скрипты будут взаимодействовать с классом Car    
{
    [SerializeField] private float maxSteerAngle;
    [SerializeField] private float maxBreakTorque;

    [SerializeField] private AnimationCurve engineTorqueCurve;
    [SerializeField] private float maxMotorTorque;
    [SerializeField] private int maxSpeed;

    public float LinearVelocity => chassis.LinearVelocity;

    private CarChassis chassis;

    // DEBUG
    public float ThrottleControl; //  Педаль газа. "Дроссель"
    public float SteerControl; // Поворот
    public float BrakeControl; // Тормоз
    //public float handbrakecontrol; // ручной тормоз

    private void Start()
    {
        chassis = GetComponent<CarChassis>();
    }

    private void Update()
    {
        float engineTorque = engineTorqueCurve.Evaluate(LinearVelocity / maxSpeed) * maxMotorTorque;

        if (LinearVelocity >= maxSpeed) 
        {
            engineTorque = 0;
        }

        chassis.MotorTorque = engineTorque * ThrottleControl;
        chassis.SteerAngle = maxSteerAngle * SteerControl;
        chassis.BreakTorque = maxBreakTorque * BrakeControl;
    }
}
