using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float playerSpeed;
    public float playerSwipeSpeed;
    public Animator _anim;

    public Rigidbody skelet;
    public virtual void Awake()
    {
        instance = this;

        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (!GameManager.instance.isGameRunning || dead)
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

    EnemyController enemy;
    public void CallPunch(GameObject Enemy)
    {
        enemy = Enemy.GetComponent<EnemyController>();

        if (Enemy.transform.position.x > transform.position.x)
        {
            _anim.SetTrigger("RightP");
        }

        if (Enemy.transform.position.x < transform.position.x)
        {
            _anim.SetTrigger("LeftP");
        }


    }

    public void Punch()
    {
        if (!enemy) return;

        enemy.Catch();
        GameManager.instance.score += 5;
        GameManager.instance.GetScoreMultiplier();
    }

    bool dead;
    public void Dead()
    {
        if (dead) return;

        dead = true;

        foreach (Rigidbody item in transform.GetComponentsInChildren<Rigidbody>())
        {
            item.velocity = Vector3.zero;
        }

        _anim.enabled = false;

    }
}
