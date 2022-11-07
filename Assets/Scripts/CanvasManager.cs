using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject restartPanel;
    public GameObject nextLevelPanel;

    public TextMeshProUGUI currentLevelTXT;
    public GameObject currentLevelObject;

    public static CanvasManager instance;
    public int currentLevelID;

    public TextMeshProUGUI totalScoreTXT;
    public GameObject scoreTXT;

    public int totalScore;
    public int scoreMultiplier;

    public virtual void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        currentLevelTXT.text = (PlayerPrefs.GetInt(CommonTypes.LEVEL_FAKE_DATA_KEY) + 1).ToString();

        if (GameManager.instance.isGameRunning == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.instance.isGameRunning = true;
                GameManager.instance.failLevel = false;
                startPanel.SetActive(false);
                currentLevelObject.SetActive(true);
            }
        }
    }
    public void GetLevel()
    {
        totalScore =GameManager.instance.score * scoreMultiplier;
       totalScoreTXT.text = totalScore.ToString();
        nextLevelPanel.SetActive(true);
    }
}
