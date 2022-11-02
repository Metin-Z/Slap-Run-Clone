using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScoreBonusComponent : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bonus"))
        {
            transform.GetComponent<MeshRenderer>().material.DOColor(Color.gray, 1).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
