using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManComponent : MonoBehaviour
{
    public GameObject camera;
    public GameObject bonusMan;
    Rigidbody _rb;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.isGameRunning = false;
            camera.SetActive(true);
            _rb = bonusMan.GetComponent<Rigidbody>();
            bonusMan.GetComponent<Animator>().enabled = false;
            _rb.constraints = RigidbodyConstraints.None;
            _rb.AddForce(transform.up * 50);
            _rb.AddForce(transform.forward * 75);
        }
    }
}
