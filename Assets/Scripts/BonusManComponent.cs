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
            StartCoroutine(KickBonusMan());
        }
    }
    public IEnumerator KickBonusMan()
    {
        PlayerController.instance._anim.SetBool("Run", false);
        PlayerController.instance._anim.SetBool("Kick", true);

        yield return new WaitForSeconds(0.8f);

        _rb = bonusMan.GetComponent<Rigidbody>();
        bonusMan.GetComponent<Animator>().enabled = false;

        _rb.constraints = RigidbodyConstraints.FreezePositionX;
        _rb.constraints = RigidbodyConstraints.FreezeRotation;

        int multiplier = GameManager.instance.score;

        foreach (Rigidbody item in bonusMan.GetComponentsInChildren<Rigidbody>())
        {
            _rb.mass = 1;
            item.mass = 0.8f;
            item.AddForce(transform.up * 6* multiplier);
            item.AddForce(transform.forward * 15 * multiplier);
            item.isKinematic = false;                       
            item.velocity = Vector3.zero;
            item.angularVelocity = Vector3.zero;
            
        }
    }
}
