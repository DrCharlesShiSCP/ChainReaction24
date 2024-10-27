using UnityEngine;

public class GoggleGadget : MonoBehaviour
{
    public Camera playerCamera; // Reference to the player's camera
    public int explosiveRangeLayer = 8; // The layer number for explosiveRange (ensure this matches in the Layer settings)
    public GadgetSwitch gadgetSwitcher; // Reference to the GadgetSwitch script to check current gadget
    public GameObject filter;

    private int defaultCullingMask; // Stores the default culling mask

    void Start()
    {
        gadgetSwitcher = gadgetSwitcher = Object.FindFirstObjectByType<GadgetSwitch>();
        // Store the camera's original culling mask
        defaultCullingMask = playerCamera.cullingMask;
        filter.SetActive(false);
    }

    void Update()
    {
        UpdateCullingMask();
    }

    private void UpdateCullingMask()
    {
        gadgetSwitcher = gadgetSwitcher = Object.FindFirstObjectByType<GadgetSwitch>();
        if (gadgetSwitcher.currentGadget == Gadget.Goggles)
        {
            // Enable the explosiveRange layer in the culling mask
            playerCamera.cullingMask = defaultCullingMask | (1 << explosiveRangeLayer);
            filter.SetActive(true);
        }
        else
        {
            // Revert to the default culling mask without the explosiveRange layer
            playerCamera.cullingMask = defaultCullingMask;
            filter.SetActive(false);
        }
    }
}
