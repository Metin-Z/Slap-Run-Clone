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
            }
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.GetComponent<EnemyController>().CatchPlayer = false;
                Destroy(other.gameObject, 1.5f);
            }
        }
    }
}
