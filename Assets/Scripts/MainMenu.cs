using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject LevelPage;

    private bool isPaused = false;

    void Start()
    {
        LevelPage.SetActive(false);
        Time.timeScale = 1;
    }


    public void ShowLevels()
    {
        LevelPage.SetActive(true);
    }
    public void HideLevels()
    {
        LevelPage.SetActive(false);
    }
    public void ClickedStartGame()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void toLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void toLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void toLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void toLevel4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void toLevel5()
    {
        SceneManager.LoadScene("Level5");
    }
    public void toLevel6()
    {
        SceneManager.LoadScene("Level6");
    }
    public void toLevel7()
    {
        SceneManager.LoadScene("Level7");
    }
    public void toTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void QuitleGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
