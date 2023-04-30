using UnityEngine;

[RequireComponent (typeof(CarChassis))]
/// <summary>
/// �������������� ������ ����������.
/// </summary>

// �������� ����, ��� �� CarChassis ��������� �����������, ��� ��������� ������ �� WheelAxle
public class Car : MonoBehaviour // ��� ������� ����� ����������������� � ������� Car    
{
    [SerializeField] private float maxSteerAngle;
    [SerializeField] private float maxBreakTorque;

    [SerializeField] private AnimationCurve engineTorqueCurve;
    [SerializeField] private float maxMotorTorque;
    [SerializeField] private int maxSpeed;

    public float LinearVelocity => chassis.LinearVelocity;

    private CarChassis chassis;

    // DEBUG
    public float ThrottleControl; //  ������ ����. "��������"
    public float SteerControl; // �������
    public float BrakeControl; // ������
    //public float handbrakecontrol; // ������ ������

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
