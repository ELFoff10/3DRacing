using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private Car car;
    [SerializeField][Range(0f, 1f)] private float normalizeSpeedSnake;
    [SerializeField] private float shakeAmount;

    private void Update()
    {
        if (car.NormalizeLinearVelocity >= normalizeSpeedSnake)
        {
            transform.localPosition += Random.insideUnitSphere * shakeAmount * Time.deltaTime;
        }
    }
}
