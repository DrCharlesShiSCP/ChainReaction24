using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDetection : MonoBehaviour
{
    public float detectionRange = 5f; // Range to detect nearby mines
    private bool isTriggered = false; // Set to true once the mine has been triggered

    private void DetectAndTrigger()
    {
        if (isTriggered) return; // Avoid multiple detections on the same mine
        isTriggered = true; // Mark this mine as triggered

        // Find all nearby mines in the detection range
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRange);
        foreach (Collider nearbyObject in colliders)
        {
            MineDetection nearbyMineDetection = nearbyObject.GetComponent<MineDetection>();
            MineExplosion mineExplosion = nearbyObject.GetComponent<MineExplosion>();

            // Proceed only if the nearby mine hasn't been triggered yet
            if (nearbyMineDetection != null && !nearbyMineDetection.isTriggered)
            {
                mineExplosion.TriggerExplosion(); // Trigger explosion on nearby mines
            }
        }

        // Deactivate the MineDetection script to prevent further triggering
        DeactivateDetection();
    }

    // Public method to initiate the detection (can be called by another script)
    public void TriggerDetection()
    {
        DetectAndTrigger();
    }

    private void DeactivateDetection()
    {
        // Disable this component to stop further detection
        this.enabled = false;
    }

    private void OnDrawGizmosSelected()
    {
        // Draw the detection range in the editor for visualization
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
