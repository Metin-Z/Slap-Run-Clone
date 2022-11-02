using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject startPanel;

    private void Update()
    {
        if (GameManager.instance.isGameRunning == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.instance.isGameRunning = true;
                startPanel.SetActive(false);
            }
        }
    }
}
