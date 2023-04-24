using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private WheelCollider[] wheelColliders;
    [SerializeField] private Transform[] wheelMeshs;
    [SerializeField] private float motorTorque;
    [SerializeField] private float breakTorque;
    [SerializeField] private float steerAngle;

    private void Update()
    {
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            // Крутящий момент = из управления "газ" * максимальный крутящий момент
            wheelColliders[i].motorTorque = Input.GetAxis("Vertical") * motorTorque;

            wheelColliders[i].brakeTorque = Input.GetAxis("Jump") * breakTorque;

            Vector3 position;
            Quaternion rotation;
            // Синхронизировать трансформу коллайдера и колёс
            wheelColliders[i].GetWorldPose(out position, out rotation);

            wheelMeshs[i].position = position; 
            wheelMeshs[i].rotation = rotation;
        }

        // Поворот передних колёс
        wheelColliders[0].steerAngle = Input.GetAxis("Horizontal") * steerAngle;
        wheelColliders[1].steerAngle = Input.GetAxis("Horizontal") * steerAngle;        
    }
}
