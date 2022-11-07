using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PunchBar : MonoBehaviour
{
    public static PunchBar instance;
    Slider _slider;
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
        _slider = GetComponent<Slider>();
    }
    private void Update()
    {
        _slider.value = GameManager.instance.score;
    }
}
