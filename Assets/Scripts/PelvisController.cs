using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelvisController : MonoBehaviour
{
    Vector3 startPos;
    private void Start()
    {
        startPos = transform.localPosition;
    }
    void Update()
    {
        transform.localPosition = startPos;      
    }
}
