using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
class EngineIndicatorColor
{
    public float MaxRpm;
    public Color color;
}

public class CarEngineIndicator : MonoBehaviour
{
    [SerializeField] private Car car;
    [SerializeField] private Image image;
    [SerializeField] private EngineIndicatorColor[] colors;

    private void Update()
    {
        image.fillAmount = car.EngineRpm / car.EngineMaxRpm;

        for (int i = 0; i < colors.Length; i++)
        {
            if (car.EngineRpm <= colors[i].MaxRpm)
            {
                image.color = colors[i].color;
                break;
            }
        }
    }
}
