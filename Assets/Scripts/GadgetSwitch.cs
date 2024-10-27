using UnityEngine;
using UnityEngine.UI;

public class GadgetSwitch : MonoBehaviour
{
    public Gadget currentGadget = Gadget.MarkingFlag; 
    public Image gadgetUIImage; 
    public Sprite markingFlagSprite; 
    public Sprite metalDetectorSprite; 
    public Sprite explosivesSprite; 
    public Sprite goggleSprite;

    void Start()
    {
        SwitchGadget();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // Press Q to switch gadgets
        {
            SwitchGadget();
        }
    }

    void SwitchGadget()
    {
        currentGadget = (Gadget)(((int)currentGadget + 1) % System.Enum.GetValues(typeof(Gadget)).Length);
        Debug.Log("Current Gadget: " + currentGadget);
        UpdateGadgetUI();
    }

    void UpdateGadgetUI()
    {
        // Update the UI image based on the current gadget
        switch (currentGadget)
        {
            case Gadget.MarkingFlag:
                gadgetUIImage.sprite = markingFlagSprite;
                break;
            case Gadget.MetalDetector:
                gadgetUIImage.sprite = metalDetectorSprite;
                break;
            case Gadget.Explosives:
                gadgetUIImage.sprite = explosivesSprite;
                break;
            case Gadget.Goggles:
                gadgetUIImage.sprite = goggleSprite;
                break;
        }
    }
}
