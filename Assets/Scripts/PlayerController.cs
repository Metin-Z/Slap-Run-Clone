using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float playerSpeed;
    public float playerSwipeSpeed;
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
    void Update()
    {

        Touch();
        Clamp();
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed);
        if (Input.GetMouseButtonDown(0))
        {
            isTouch = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isTouch = false;
        }
    }



    public void Clamp()
    {
        float minX = -2.3f;
        float maxX = 2.3f;
        float xPos = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
    bool isTouch;
    public void Touch()
    {
        if (!isTouch)
            return;
        transform.Translate(Vector3.right * Input.GetAxis("Mouse X") * playerSwipeSpeed * Time.deltaTime);
    }
}
