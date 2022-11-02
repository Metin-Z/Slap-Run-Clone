using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedGate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject player = other.gameObject;
            player.GetComponent<PlayerController>().playerSpeed = 6.5f;
            StartCoroutine(FastRun(player));
        }
    }
    public IEnumerator FastRun(GameObject player)
    {
        yield return new WaitForSeconds(3);
        player.GetComponent<PlayerController>().playerSpeed = 4;
    }
}
