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
            Time.timeScale = 0.5f;
            PlayerController.instance.enabled = false;
            StartCoroutine(KickBonusMan());
        }
    }
    public IEnumerator KickBonusMan()
    {
        PlayerController.instance._anim.SetBool("Run", false);
        PlayerController.instance._anim.SetBool("Kick", true);

        yield return new WaitForSeconds(0.8f);
        PlayerController.instance._anim.SetBool("Kick", false);
        PlayerController.instance._anim.SetBool("Run", false);
        PlayerController.instance._anim.SetBool("Dance", true);
        Time.timeScale = 1f;
        _rb = bonusMan.GetComponent<Rigidbody>();
        bonusMan.GetComponent<Animator>().enabled = false;

        _rb.constraints = RigidbodyConstraints.FreezePositionX;
        _rb.constraints = RigidbodyConstraints.FreezeRotation;

        int multiplier = GameManager.instance.score;

        _rb.AddForce(transform.up * 4 * multiplier);
        _rb.AddForce(transform.forward * 8 * multiplier);     
    }
}
