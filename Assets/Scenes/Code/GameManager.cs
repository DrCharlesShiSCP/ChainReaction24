using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("爆炸目标设置")]
    // 目标爆炸桶（胜利条件）
    public GameObject targetExplosiveBarrel;
    // 爆炸桶被摧毁后切换的场景
    public string sceneToLoadOnTargetExplosiveBarrel;

    [Header("计时器设置")]
    // 游戏倒计时（以秒为单位）
    public float countdownTime;
    // 倒计时结束后切换的场景
    public string sceneToLoadOnTimerEnd;
    // 倒计时显示的TMP组件
    public TMP_Text timerDisplay;

    [Header("炸弹设置")]
    // 炸弹标签（可在Inspector中修改）
    public string bombTag = "Bomb";

    [Header("重置按钮设置")]
    // 重置按钮
    public Button resetButton;

    private float currentTime;
    private GameObject[] bombClones;
    private bool resetButtonClicked;

    void Start()
    {
        currentTime = countdownTime;
        CreateBombClones();

        if (resetButton != null)
        {
            resetButton.onClick.AddListener(OnResetButtonClick);
        }
    }

    void Update()
    {
        UpdateCountdownTimer();
        CheckTargetExplosiveBarrel();
        CheckResetCondition();
    }

    void UpdateCountdownTimer()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            currentTime = Mathf.Max(currentTime, 0);
            UpdateTimerDisplay();
        }
        else
        {
            SceneManager.LoadScene(sceneToLoadOnTimerEnd);
        }
    }

    void UpdateTimerDisplay()
    {
        if (timerDisplay != null)
        {
            timerDisplay.text = currentTime.ToString("F2") + "s";
        }
    }

    void CheckTargetExplosiveBarrel()
    {
        if (targetExplosiveBarrel == null)
        {
            SceneManager.LoadScene(sceneToLoadOnTargetExplosiveBarrel);
        }
    }

    void CheckResetCondition()
    {
        if (Input.GetKeyDown(KeyCode.R) || resetButtonClicked)
        {
            ResetMethod();
            resetButtonClicked = false;
        }
    }

    void OnResetButtonClick()
    {
        resetButtonClicked = true;
    }

    void ResetMethod()
    {
        // 销毁当前的炸弹对象
        GameObject[] existingBombs = GameObject.FindGameObjectsWithTag(bombTag);
        foreach (GameObject bomb in existingBombs)
        {
            Destroy(bomb);
        }

        // 实例化炸弹克隆
        foreach (GameObject clone in bombClones)
        {
            GameObject newBomb = Instantiate(clone, clone.transform.position, clone.transform.rotation);
            newBomb.transform.localScale = clone.transform.localScale;
        }

        Debug.Log("重置方法已触发");
    }

    void CreateBombClones()
    {
        // 创建炸弹对象的克隆
        GameObject[] originalBombs = GameObject.FindGameObjectsWithTag(bombTag);
        bombClones = new GameObject[originalBombs.Length];
        for (int i = 0; i < originalBombs.Length; i++)
        {
            bombClones[i] = Instantiate(originalBombs[i]);
            bombClones[i].SetActive(false);
        }
    }
}
