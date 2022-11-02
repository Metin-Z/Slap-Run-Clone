using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject restartPanel;
    public static CanvasManager instance;
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
        if (GameManager.instance.isGameRunning == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.instance.isGameRunning = true;
                GameManager.instance.failLevel = false;
                startPanel.SetActive(false);
            }
        }
    }
}
