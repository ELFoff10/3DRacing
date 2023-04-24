using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WheelAxle
{
    [SerializeField] private WheelCollider leftWheelCollider;
    [SerializeField] private WheelCollider rightWheelCollider;

    [SerializeField] private Transform leftWheelMesh;
    [SerializeField] private Transform rightWheelMesh;

    [SerializeField] private bool isMotor;
    [SerializeField] private bool isSteer;


    public void Update()
    {
        SyncMeshTransform();
    }

    private void SyncMeshTransform()
    {

    }
}
