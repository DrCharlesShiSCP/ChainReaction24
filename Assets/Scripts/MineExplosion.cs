using System.Collections;
using UnityEngine;

public class MineExplosion : MonoBehaviour
{
    public GameObject explosionEffect; // Placeholder for explosion particle effect
    public float destructionDelay = 2f; // Delay before the mine is destroyed, allowing effect to play
    private bool hasExploded = false; // To prevent multiple explosions of the same mine

    public void TriggerExplosion()
    {
        if (hasExploded) return; // Avoid multiple explosions on the same mine
        hasExploded = true;

        // Play the explosion effect
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Start the destruction delay
        StartCoroutine(DestroyAfterDelay());

        // Trigger detection for chain reaction (if applicable)
        MineDetection detection = GetComponent<MineDetection>();
        if (detection != null)
        {
            detection.TriggerDetection();
        }
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destructionDelay);
        Destroy(gameObject); // Destroy this mine after delay
    }
}
