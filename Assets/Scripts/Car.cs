using UnityEngine;

[RequireComponent (typeof(CarChassis))]
/// <summary>
/// �������������� ������ ����������.
/// </summary>

// �������� ����, ��� �� CarChassis ��������� �����������, ��� ��������� ������ �� WheelAxle
public class Car : MonoBehaviour // ��� ������� ����� ����������������� � ������� Car    
{
    [SerializeField] private float maxMotorTorque;
    [SerializeField] private float maxSteerAngle;
    [SerializeField] private float maxBreakTorque;

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
        chassis.MotorTorque = maxMotorTorque * ThrottleControl;
        chassis.SteerAngle = maxSteerAngle * SteerControl;
        chassis.BreakTorque = maxBreakTorque * BrakeControl;
    }
}
