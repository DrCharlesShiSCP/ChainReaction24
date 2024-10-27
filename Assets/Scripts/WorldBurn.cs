using UnityEngine;

public class WorldBurn : MonoBehaviour
{
    public float forceMagnitude = 10f; // Magnitude of the random force

    public void BurnNow()
    {
        Invoke("ActivateChaos", 0.2f);
    }
    public void ActivateChaos()
    {
        // Get all GameObjects in the scene
        GameObject[] allObjects = Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None);

        foreach (GameObject obj in allObjects)
        {
            // Ensure the object has a Transform (it¡¯s not a UI or special component)
            if (obj.GetComponent<Transform>() != null)
            {
                // Add Rigidbody if it doesn¡¯t already have one
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                if (rb == null)
                {
                    rb = obj.AddComponent<Rigidbody>();
                }

                // Apply a random force
                Vector3 randomForce = new Vector3(
                    Random.Range(-1f, 1f),
                    Random.Range(-1f, 1f),
                    Random.Range(-1f, 1f)
                ).normalized * forceMagnitude;

                rb.AddForce(randomForce, ForceMode.Impulse);
            }
        }
    }
}
