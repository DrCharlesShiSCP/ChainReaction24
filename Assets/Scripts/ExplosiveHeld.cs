using UnityEngine;

public class ExplosiveHeld : MonoBehaviour
{
    public GameObject heldExplosive;
    public GadgetSwitch gadgetSwitcher;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gadgetSwitcher = gadgetSwitcher = Object.FindFirstObjectByType<GadgetSwitch>();
        heldExplosive.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsExplosiveEquipped()) // Left mouse button for placing an explosive
        {
            Detect();
        }
        else
        {
            UnDetect();
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
    public void UnDetect()
    {
        heldExplosive.SetActive(false);
    }
    public void Detect()
    {
        heldExplosive.SetActive(true);
    }
}
