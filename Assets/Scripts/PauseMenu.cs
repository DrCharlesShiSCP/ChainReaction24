using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;

    private bool isPaused = false;

    void Start()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        pauseMenu.SetActive(isPaused);

        Time.timeScale = isPaused ? 0 : 1;

        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isPaused;
        if (settingsMenu.activeSelf)
        {
            settingsMenu.SetActive(false);
        }

    }
    public void closeSettings()
    {
        settingsMenu.SetActive(false);
    }
    public void SettingsOpen()
    {
        settingsMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void ResetGame()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
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
