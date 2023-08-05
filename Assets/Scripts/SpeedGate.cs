using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedGate : MonoBehaviour
{
    public float speed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            player.GetComponent<PlayerController>().playerSpeed = player.GetComponent<PlayerController>().playerSpeed + speed;
        }
    }
}
