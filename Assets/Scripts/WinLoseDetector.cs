using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WinLoseDetector : MonoBehaviour
{
    public List<GameObject> landmines; // List of landmines to check
    public GameObject winScr;
    public GameObject LoseScr;
    public float checkDelay;

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
    public void CheckWinOrLose()
    {
        // Check if all landmines are destroyed
        bool allDestroyed = true;
        foreach (GameObject landmine in landmines)
        {
            if (landmine != null) // If any landmine still exists
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
    }
}
