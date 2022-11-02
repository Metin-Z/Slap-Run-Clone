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
        GetTarget(PlayerController.instance.transform);
    }

   public void GetTarget(Transform target)
    {
        _cinemachine.Follow = target;
        _cinemachine.LookAt = target;
    }
}
