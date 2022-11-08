using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusActive : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.bonusLevel = true;
            other.GetComponent<PlayerController>().playerSpeed = other.GetComponent<PlayerController>().playerSpeed + 4;
        }
    }
}
