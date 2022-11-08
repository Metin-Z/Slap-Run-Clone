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
}
