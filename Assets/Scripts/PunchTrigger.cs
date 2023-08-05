using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchTrigger : MonoBehaviour
{
    PlayerController controller;
    private void Awake()
    {
        controller = GetComponentInParent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject Enemy = other.gameObject;

            controller.CallPunch(Enemy);

        }
    }
}
