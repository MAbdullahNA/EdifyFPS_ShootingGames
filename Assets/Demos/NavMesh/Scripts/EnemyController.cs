using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent _agent;
    Animator _animator;

    public Transform target;
    public float chaseArea = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(target.position, transform.position);
        if (dis <= chaseArea)
        {
            _agent.SetDestination(target.position);
            _agent.isStopped = false;
            if (_agent.velocity.magnitude != 0)
            {
                _animator.SetBool("Walking", true);
            }
            else
            { _animator.SetBool("Walking", false); }
        }
        else
        {
            _agent.isStopped = true;
        }
    }
}
