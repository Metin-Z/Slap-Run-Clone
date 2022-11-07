using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScoreBonusComponent : MonoBehaviour
{
    public int scoreMultiplier;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bonus"))
        {
            transform.GetComponent<MeshRenderer>().material.DOColor(Color.gray, 1).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            CanvasManager.instance.scoreMultiplier = scoreMultiplier;
            CanvasManager.instance.GetLevel();

            //foreach (Rigidbody item in collision.transform.GetComponentsInChildren<Rigidbody>())
            //{
            //    item.isKinematic = false;
            //    item.velocity = Vector3.zero;
            //    item.angularVelocity = Vector3.zero;

            //}
        }
    }
}
