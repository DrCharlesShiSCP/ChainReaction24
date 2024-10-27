using UnityEngine;

public class PlacingPickup : MonoBehaviour
{
    public GameObject explosivePrefab; 
    public float placementRange = 5f; 
    public LayerMask placementLayerMask; // Layer mask to specify valid placement surfaces
    public int maxExplosives = 5; 

    private Camera playerCamera;
    private int currentExplosiveCount = 0; // Current count of placed explosives

    void Start()
    {
        playerCamera = Camera.main; // Get the main camera
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button for placing an explosive
        {
            TryPlaceExplosive();
        }

        if (Input.GetKeyDown(KeyCode.E)) // "E" key for picking up an explosive
        {
            TryPickUpExplosive();
        }
    }

    private void TryPlaceExplosive()
    {
        // Check if the maximum limit of explosives has been reached
        if (currentExplosiveCount >= maxExplosives)
        {
            Debug.Log("Maximum number of explosives reached.");
            return;
        }

        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition); // Ray from the camera through the cursor
        RaycastHit hit;

        // Check if the ray hits a valid placement surface within range
        if (Physics.Raycast(ray, out hit, placementRange, placementLayerMask))
        {
            // Place the explosive at the hit point and increment the count
            Instantiate(explosivePrefab, hit.point, Quaternion.identity);
            currentExplosiveCount++;
        }
        else
        {
            Debug.Log("No valid surface within range for placing an explosive.");
        }
    }

    private void TryPickUpExplosive()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition); // Ray from the camera through the cursor
        RaycastHit hit;

        // Check if the ray hits an explosive within range
        if (Physics.Raycast(ray, out hit, placementRange))
        {
            if (hit.collider.CompareTag("Explosive")) // Ensure the hit object is an explosive
            {
                Destroy(hit.collider.gameObject); // Remove the explosive
                currentExplosiveCount--; // Decrement the count
                Debug.Log("Picked up explosive.");
            }
        }
    }
}
