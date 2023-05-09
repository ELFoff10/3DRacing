using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSound : MonoBehaviour
{
    [SerializeField] private new AudioSource audio;
    [SerializeField] private Car car;

    private void Update()
    {
        if (car.LinearVelocity > 60)
        {
            audio.Play();
        }
    }
}
