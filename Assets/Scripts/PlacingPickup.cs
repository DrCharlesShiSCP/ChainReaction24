using UnityEngine;
using TMPro;

public class PlacingPickup : MonoBehaviour
{
    public GadgetSwitch gadgetSwitcher; // Reference to the GadgetSwitcher script
    public GameObject explosivePrefab;
    public float placementRange = 5f;
    public LayerMask placementLayerMask; // Layer mask to specify valid placement surfaces
    public int maxExplosives = 5;
    public TextMeshProUGUI bombCount;

    private Camera playerCamera;
    private int currentExplosiveCount = 0; // Current count of placed explosives

    void Start()
    {
        gadgetSwitcher = gadgetSwitcher = Object.FindFirstObjectByType<GadgetSwitch>();
        playerCamera = Camera.main; // Get the main camera
    }

    void Update()
    {
        bombCount.text = "Explosives Left:" + (maxExplosives - currentExplosiveCount);
        if (Input.GetMouseButtonDown(0) && IsExplosiveEquipped()) // Left mouse button for placing an explosive
        {
            TryPlaceExplosive();
        }

        if (Input.GetKeyDown(KeyCode.E)) // "E" key for picking up an explosive
        {
            TryPickUpExplosive();
        }
    }

    private bool IsExplosiveEquipped()
    {
        gadgetSwitcher = gadgetSwitcher = Object.FindFirstObjectByType<GadgetSwitch>();
        if (gadgetSwitcher == null)
        {
            Debug.LogWarning("GadgetSwitcher reference is missing.");
            return false;
        }

        bool isEquipped = gadgetSwitcher.currentGadget == Gadget.Explosives;
        Debug.Log("Is Explosive Equipped: " + isEquipped);
        return isEquipped;
    }


    private void TryPlaceExplosive()
    {
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
