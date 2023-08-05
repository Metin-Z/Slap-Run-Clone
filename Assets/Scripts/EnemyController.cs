using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public Animator _anim;
    public NavMeshAgent _navMesh;
    public Vector3 Target;
    public bool final;
    PlayerController _playerController => PlayerController.instance;
    public void Catch()
    {

        foreach (Rigidbody item in transform.GetComponentsInChildren<Rigidbody>())
        {
            item.velocity = Vector3.zero;
        }

        _navMesh.enabled = false;
        _anim.enabled = false;
        StartCoroutine(Run());
    }
    public bool catchPlayer;
    public IEnumerator Run()
    {
        yield return new WaitForSeconds(1.75f);
        if (!final)
        {
            _anim.SetBool("Run", true);
            _anim.enabled = true;
            _navMesh.enabled = true;
            catchPlayer = true;
        }
    }
    private void Update()
    {
        if (catchPlayer && gameObject.activeSelf)
        {
            if (!GameManager.instance.isGameRunning)
            {
                _anim.SetBool("Dance", true);
                _navMesh.enabled = false;
                return;
            }

            if (!_playerController) return;

            Target = _playerController.transform.position + Vector3.back * 2.5f;

            _navMesh.SetDestination(Target);
        }

    }
}
