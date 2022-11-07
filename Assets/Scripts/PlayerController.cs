using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float playerSpeed;
    public float playerSwipeSpeed;
    public Animator _anim;
    public virtual void Awake()
    {
            instance = this;
     
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (GameManager.instance.isGameRunning == false)
            return;
        _anim.SetBool("Run", true); 
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject Enemy = other.gameObject;
            Punch(Enemy);
            GameManager.instance.score+=5;
            GameManager.instance.GetScoreMultiplier();
        }
    }
    public void Punch(GameObject Enemy)
    {
        if (Enemy.transform.position.x > transform.position.x)
        {
            _anim.SetBool("RightP", true);
        }
        else
        {
            _anim.SetBool("RightP", false);
        }

        if (Enemy.transform.position.x < transform.position.x)
        {
            _anim.SetBool("LeftP", true);
        }
        else
        {
            _anim.SetBool("LeftP", false);
        }
        Enemy.GetComponent<EnemyController>().Catch();

    }
}
