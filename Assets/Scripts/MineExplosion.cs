using System.Collections;
using UnityEngine;

public class MineExplosion : MonoBehaviour
{
    public GameObject explosionEffect; // Placeholder for explosion particle effect
    public float destructionDelay = 2f; // Delay before the mine is destroyed, allowing effect to play
    private bool hasExploded = false; // To prevent multiple explosions of the same mine

    public void TriggerExplosion()
    {
        Debug.Log("triggered");
        if (hasExploded) return; // Avoid multiple explosions on the same mine
        hasExploded = true;

        // Play the explosion effect
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        Invoke("testDestroy", 1f);
    }

    public void testDestroy()
    {
        MineDetection detection = GetComponent<MineDetection>();
        if (detection != null)
        {
            detection.TriggerDetection();
        }
        Destroy(gameObject);
        Debug.Log("destoryed");
    }
}
