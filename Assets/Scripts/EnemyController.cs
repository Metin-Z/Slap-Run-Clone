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
    public Rigidbody rbSkeleton;
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
        foreach (Rigidbody item in rbSkeleton.GetComponentsInChildren<Rigidbody>())
        {
            item.AddForce(Vector3.forward * GameManager.instance.score*5*PlayerController.instance.playerSpeed);
            item.AddForce(Vector3.up * (GameManager.instance.score*5*PlayerController.instance.playerSpeed/4) /2);
        }
        //rb.constraints = RigidbodyConstraints.None;
    }
    public bool catchPlayer;
    public IEnumerator Run()
    {
        yield return new WaitForSeconds(1.75f);
        if (!GameManager.instance.bonusLevel)
        {
            //rb.constraints = RigidbodyConstraints.FreezePositionY;
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

            if (_navMesh != null && _navMesh.isActiveAndEnabled)
            {
                _navMesh.SetDestination(Target);
            }
        }
    }

    private void Awake()
    {
        foreach (CharacterJoint item in transform.GetComponentsInChildren<CharacterJoint>())
        {
            item.enableProjection = true;
        }
    }
}
