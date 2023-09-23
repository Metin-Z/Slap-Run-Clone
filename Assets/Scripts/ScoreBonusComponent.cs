using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScoreBonusComponent : MonoBehaviour
{
    public int scoreMultiplier;
    public GameObject pelvis;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bonus") && !GameManager.instance.bonusEnd)
        {
            GameManager.instance.bonusEnd = true;
            transform.GetComponent<MeshRenderer>().material.DOColor(Color.gray, 1).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
            collision.gameObject.TryGetComponent(out Rigidbody rbC);
            rbC.velocity = rbC.velocity / 4;
            pelvis.GetComponent<Rigidbody>().velocity = Vector3.zero;
            pelvis.GetComponent<PelvisController>().enabled = false;
            CanvasManager.instance.scoreMultiplier = scoreMultiplier;
            CanvasManager.instance.GetLevel();

        }
    }
}
