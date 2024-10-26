using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("��ըĿ������")]
    // Ŀ�걬ըͰ��ʤ��������
    public GameObject targetExplosiveBarrel;
    // ��ըͰ���ݻٺ��л��ĳ���
    public string sceneToLoadOnTargetExplosiveBarrel;

    [Header("��ʱ������")]
    // ��Ϸ����ʱ������Ϊ��λ��
    public float countdownTime;
    // ����ʱ�������л��ĳ���
    public string sceneToLoadOnTimerEnd;
    // ����ʱ��ʾ��TMP���
    public TMP_Text timerDisplay;

    [Header("ը������")]
    // ը����ǩ������Inspector���޸ģ�
    public string bombTag = "Bomb";

    [Header("���ð�ť����")]
    // ���ð�ť
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
        // ���ٵ�ǰ��ը������
        GameObject[] existingBombs = GameObject.FindGameObjectsWithTag(bombTag);
        foreach (GameObject bomb in existingBombs)
        {
            Destroy(bomb);
        }

        // ʵ����ը����¡
        foreach (GameObject clone in bombClones)
        {
            GameObject newBomb = Instantiate(clone, clone.transform.position, clone.transform.rotation);
            newBomb.transform.localScale = clone.transform.localScale;
        }

        Debug.Log("���÷����Ѵ���");
    }

    void CreateBombClones()
    {
        // ����ը������Ŀ�¡
        GameObject[] originalBombs = GameObject.FindGameObjectsWithTag(bombTag);
        bombClones = new GameObject[originalBombs.Length];
        for (int i = 0; i < originalBombs.Length; i++)
        {
            bombClones[i] = Instantiate(originalBombs[i]);
            bombClones[i].SetActive(false);
        }
    }
}
