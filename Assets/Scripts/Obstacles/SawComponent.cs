using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawComponent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")||other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Animator>().enabled = false;

            if (other.gameObject.CompareTag("Player"))
            {
                other.GetComponent<PlayerController>().enabled = false;
                GameManager.instance.isGameRunning = false;
                GameManager.instance.failLevel = true;
                GameManager.instance.bonusLevel = false;
                CanvasManager.instance.currentLevelObject.SetActive(false);

            }
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyController>().CatchPlayer = false;
                Destroy(other.gameObject, 1.5f);
            }
        }
    }
}
