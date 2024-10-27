using UnityEngine;
using TMPro;

public class PlacingFlags : MonoBehaviour
{
    public GadgetSwitch gadgetSwitcher; // Reference to the GadgetSwitcher script
    public GameObject flag;
    public float placementRange = 5f;
    public LayerMask placementLayerMask; // Layer mask to specify valid placement surfaces
    public int maxflags = 5;
    public TextMeshProUGUI flagLeft;

    private Camera playerCamera;
    private int currentflagCount = 0; // Current count of placed explosives

    void Start()
    {
        gadgetSwitcher = gadgetSwitcher = Object.FindFirstObjectByType<GadgetSwitch>();
        playerCamera = Camera.main; // Get the main camera
    }

    void Update()
    {
        flagLeft.text = "Flags left:" + (maxflags - currentflagCount);
        if (Input.GetMouseButtonDown(0) && IsFlagEquipped()) // Left mouse button for placing an explosive
        {
            TryPlaceFlag();
        }

        if (Input.GetKeyDown(KeyCode.E)) // "E" key for picking up an explosive
        {
            TryPickUpFlag();
        }
    }

    private bool IsFlagEquipped()
    {
        gadgetSwitcher = gadgetSwitcher = Object.FindFirstObjectByType<GadgetSwitch>();
        if (gadgetSwitcher == null)
        {
            Debug.LogWarning("GadgetSwitcher reference is missing.");
            return false;
        }

        bool isEquipped = gadgetSwitcher.currentGadget == Gadget.MarkingFlag;
        Debug.Log("Is flag Equipped: " + isEquipped);
        return isEquipped;
    }


    private void TryPlaceFlag()
    {
        if (currentflagCount >= maxflags)
        {
            Debug.Log("Maximum number of MarkingFlag reached.");
            return;
        }

        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition); // Ray from the camera through the cursor
        RaycastHit hit;

        // Check if the ray hits a valid placement surface within range
        if (Physics.Raycast(ray, out hit, placementRange, placementLayerMask))
        {
            // Place the explosive at the hit point and increment the count
            Instantiate(flag, hit.point, Quaternion.identity);
            currentflagCount++;
        }
        else
        {
            Debug.Log("No valid surface within range for placing an explosive.");
        }
    }

    private void TryPickUpFlag()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition); // Ray from the camera through the cursor
        RaycastHit hit;

        // Check if the ray hits an explosive within range
        if (Physics.Raycast(ray, out hit, placementRange))
        {
            if (hit.collider.CompareTag("flag")) // Ensure the hit object is an explosive
            {
                Destroy(hit.collider.gameObject); // Remove the explosive
                currentflagCount--; // Decrement the count
                Debug.Log("Picked up flag.");
            }
        }
    }
}
