using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera _cinemachine;
    public static CameraController instance;
    public virtual void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        StartCoroutine(ChekTarget());
    }

   public void GetTarget(Transform target)
    {
        _cinemachine.Follow = target;
        _cinemachine.LookAt = target;
    }
    public IEnumerator ChekTarget()
    {
        yield return new WaitForSeconds(0.2f);
        GetTarget(PlayerController.instance.transform);

    }
}
