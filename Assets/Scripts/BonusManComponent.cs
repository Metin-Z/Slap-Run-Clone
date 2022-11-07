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
            _rb.mass = 0.65f;
            item.mass = 0.65f;
            //item.constraints = RigidbodyConstraints.FreezePositionX;
            //item.constraints = RigidbodyConstraints.FreezeRotation;
            item.AddForce(transform.up * 4* multiplier);
            item.AddForce(transform.forward * 8 * multiplier);
            item.isKinematic = false;
            item.constraints = RigidbodyConstraints.FreezePositionX;
            
        }
    }
}
