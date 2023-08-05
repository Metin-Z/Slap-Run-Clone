using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManComponent : MonoBehaviour
{
    PlayerController playerController => PlayerController.instance;
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
            playerController.enabled = false;
            StartCoroutine(KickBonusMan());

            other.transform.position = new Vector3(bonusMan.transform.position.x, other.transform.position.y, other.transform.position.z);
        }
    }
    public IEnumerator KickBonusMan()
    {
        playerController._anim.SetBool("Run", false);
        playerController._anim.SetBool("Kick", true);

        yield return new WaitForSeconds(0.3f);
        playerController._anim.SetBool("Kick", false);
        playerController._anim.SetBool("Run", false);
        playerController._anim.SetBool("Dance", true);
        Time.timeScale = 1f;
        _rb = bonusMan.GetComponent<Rigidbody>();
        bonusMan.GetComponent<Animator>().enabled = false;

        foreach (Rigidbody item in bonusMan.GetComponentsInChildren<Rigidbody>())
        {
            item.velocity = Vector3.zero;
        }

        _rb.constraints = RigidbodyConstraints.FreezePositionX;
        _rb.constraints = RigidbodyConstraints.FreezeRotation;

        int multiplier = GameManager.instance.score;

        _rb.AddForce(transform.up * 4 * multiplier);
        _rb.AddForce(transform.forward * 8 * multiplier);
    }
}
