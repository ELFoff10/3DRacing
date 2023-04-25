using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ����� ����������.
/// </summary>
public class CarChassis : MonoBehaviour
{
    [SerializeField] private WheelAxle[] wheelAxles;
    [SerializeField] private float wheelBaseLenght;

    // DEBUG. ��� ���� ��� ����� ��� ������, � ����� �� ����� ����� ������ � ����������
    public float MotorTorque;
    public float BreakTorque;
    public float SteerAngle;

    private void FixedUpdate()
    {
        UpdateWheelAxles();
    }

    private void UpdateWheelAxles()
    {
        for (int i = 0; i < wheelAxles.Length; i++)
        {
            wheelAxles[i].Update();

            wheelAxles[i].ApplyMotorTorque(MotorTorque); 
            wheelAxles[i].ApplySteerAngle(SteerAngle, wheelBaseLenght);
            wheelAxles[i].ApplyBrakeTorque(BreakTorque);
        }
    }
}
