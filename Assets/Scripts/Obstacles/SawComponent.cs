using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawComponent : MonoBehaviour
{
    GameManager gameManager => GameManager.instance;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
        {

            if (other.gameObject.CompareTag("Player"))
            {
                other.TryGetComponent(out PlayerController player);
                player.Dead();
                gameManager.FailGame();

                CanvasManager.instance.currentLevelObject.SetActive(false);

            }
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyController>().catchPlayer = false;
                other.GetComponent<EnemyController>()._anim.enabled = false;
                Destroy(other.gameObject, 1.5f);
            }
        }
    }
}
