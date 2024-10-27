using System.Collections.Generic;
using UnityEngine;

public class WinLoseDetector : MonoBehaviour
{
    public List<GameObject> landmines; // List of landmines to check
    public GameObject winScr;
    public GameObject LoseScr;

    void Start()
    {
        winScr.SetActive(false);
        LoseScr.SetActive(false);
    }

    public void DetonateCheck()
    {
        Invoke("CheckWinOrLose", 5f);
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
        winScr.SetActive(true);
        Debug.Log("You Win! All landmines have been destroyed.");
        Time.timeScale = 0f;
        // Add any additional winning logic here
    }

    void Lose()
    {
        LoseScr.SetActive(true);
        Debug.Log("You Lose! Not all landmines are destroyed.");
        Time.timeScale = 0f;
        // Add any additional losing logic here
    }
}
