using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Animator _anim;
    public NavMeshAgent _navMesh;
    public Vector3 Target;
    public void Catch()
    {
        _anim.enabled = false;
        StartCoroutine(Run());
    }
    public bool CatchPlayer;
    public IEnumerator Run()
    {
        yield return new WaitForSeconds(1.75f);
        _anim.SetBool("Run", true);
        _anim.enabled = true;
        CatchPlayer = true;
    }
    private void Update()
    {
        if (CatchPlayer == true)
        {
            if (GameManager.instance.isGameRunning == false)
            {
                _anim.SetBool("Dance", true);
                return;
            }

            Target = new Vector3(
                PlayerController.instance.transform.position.x,
                PlayerController.instance.transform.position.y,
                PlayerController.instance.transform.position.z - 2.5f);
            _navMesh.SetDestination(Target);
        }

    }
}
