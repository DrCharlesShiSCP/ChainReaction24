using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLoseDetector : MonoBehaviour
{
    public List<GameObject> landmines;
    public GameObject winScr;
    public GameObject LoseScr;
    public float checkDelay;
    public TextMeshProUGUI failTextNumber;
    public int minesLeft;

    void Start()
    {
        winScr.SetActive(false);
        LoseScr.SetActive(false);
    }

    public void DetonateCheck()
    {
        Debug.LogWarning("isDoingDetoCheck");
        Invoke("CheckWinOrLose", checkDelay);
    }

    public int CountRemainingLandmines()
    {
        minesLeft = 0; 
        foreach (GameObject landmine in landmines)
        {
            if (landmine != null) // Only count landmines that have not been destroyed
            {
                minesLeft++;
            }
        }
        Debug.Log("Undestroyed landmines left: " + minesLeft);
        return minesLeft;
    }

    public void CheckWinOrLose()
    {
        bool allDestroyed = true;
        foreach (GameObject landmine in landmines)
        {
            if (landmine != null) 
            {
                allDestroyed = false;
                break;
            }
        }

        if (allDestroyed)
        {
            Win();
        }
        else
        {
            Lose();
        }
    }

    void Win()
    {
        Cursor.lockState = CursorLockMode.None;
        winScr.SetActive(true);
        Debug.LogWarning("You Win! All landmines have been destroyed.");
        Time.timeScale = 0f;
    }

    void Lose()
    {
        Cursor.lockState = CursorLockMode.None;
        LoseScr.SetActive(true);
        Debug.LogWarning("You Lose! Not all landmines are destroyed.");
        Time.timeScale = 0f;

        minesLeft = CountRemainingLandmines();

        failTextNumber.text = "You left " + minesLeft + " landmines undetonated";
    }
}
