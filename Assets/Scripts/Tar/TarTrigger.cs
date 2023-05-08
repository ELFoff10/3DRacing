using UnityEngine;

public class TarTrigger : MonoBehaviour
{
    [SerializeField] private CarChassis _carChassis;

    private void OnTriggerEnter(Collider other)
    {
        _carChassis.Rigidbody.mass = 5000000;
    }

    private void OnTriggerExit(Collider other)
    {
        _carChassis.Rigidbody.mass = 2000;
    }
}