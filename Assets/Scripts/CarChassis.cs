using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ‘изика всего автомобил€.
/// </summary>
public class CarChassis : MonoBehaviour
{
    [SerializeField] private WheelAxle[] wheelAxles;
    [SerializeField] private float wheelBaseLenght;

    // DEBUG. Ќам пока они нужны дл€ дебага, а потом их можно будет скрыть в инспекторе
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
