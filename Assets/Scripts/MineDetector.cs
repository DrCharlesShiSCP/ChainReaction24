using UnityEngine;
using TMPro;
public class MineDetector : MonoBehaviour
{
    public GameObject detector;
    public GameObject detectorMap;
    public GadgetSwitch gadgetSwitcher;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gadgetSwitcher = gadgetSwitcher = Object.FindFirstObjectByType<GadgetSwitch>();
        detector.SetActive(false);
        detectorMap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDetectorEquipped()) // Left mouse button for placing an explosive
        {
            Detect();
        }
        else 
        {
            UnDetect();
        }
    }
    private bool IsDetectorEquipped()
    {
        gadgetSwitcher = gadgetSwitcher = Object.FindFirstObjectByType<GadgetSwitch>();
        if (gadgetSwitcher == null)
        {
            Debug.LogWarning("GadgetSwitcher reference is missing.");
            return false;
        }

        bool isEquipped = gadgetSwitcher.currentGadget == Gadget.MetalDetector;
        Debug.Log("Is MetalDetector Equipped: " + isEquipped);
        return isEquipped;
    }
    public void UnDetect()
    {
        detector.SetActive(false);
        detectorMap.SetActive(false);
    }
    public void Detect()
    {
        detector.SetActive(true);
        detectorMap.SetActive(true);
    }
}
