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
        if (collision.gameObject.CompareTag("Bonus"))
        {
            transform.GetComponent<MeshRenderer>().material.DOColor(Color.gray, 1).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            pelvis.GetComponent<Rigidbody>().isKinematic = false;
            pelvis.GetComponent<PelvisController>().enabled = false;
            CanvasManager.instance.scoreMultiplier = scoreMultiplier;
            CanvasManager.instance.GetLevel();        
        }
    }
}
