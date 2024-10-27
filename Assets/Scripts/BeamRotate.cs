using UnityEngine;

public class BeamRotate : MonoBehaviour
{
    public float rotationSpeed = 50f; // Rotation speed in degrees per second

    void Update()
    {
        // Rotate the object around the y-axis
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
