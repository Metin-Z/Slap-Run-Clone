using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameRunning = false;
    public bool failLevel = false;
    public bool bonusLevel;
    public int score;

    public List<Material> enemyRandomMats;
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
    public void GetScoreMultiplier()
    {
        StartCoroutine(ScoreMultiplier());

    }

    public void FailGame()
    {
        isGameRunning = false;
        failLevel = true;
        bonusLevel = false;
    }
    public IEnumerator ScoreMultiplier()
    {
        while (!bonusLevel && score >= 0)
        {
            yield return new WaitForSeconds(3.25f);
            if (!bonusLevel)
            {
                score -= 1;
            }
            if (score < 0)
            {
                score = 0;
            }

        }
    }

    CinemachineVirtualCamera cam => Camera.main.transform.GetChild(0).transform.GetComponent<CinemachineVirtualCamera>();

    public void FovIncreaser(float value)
    {

        float newFOV = cam.m_Lens.FieldOfView + value;
        float animationDuration = 0.2f;

        DOTween.To(() => cam.m_Lens.FieldOfView, fov => cam.m_Lens.FieldOfView = fov, newFOV, animationDuration);
    }
}
