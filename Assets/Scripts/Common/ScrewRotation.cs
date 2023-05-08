using UnityEngine;

public class ScrewRotation : MonoBehaviour
{
    private void FixedUpdate()
    {
        Quaternion rotationY = Quaternion.AngleAxis(Random.Range(4, 6), Vector3.forward);
        transform.rotation *= rotationY;
    }
}