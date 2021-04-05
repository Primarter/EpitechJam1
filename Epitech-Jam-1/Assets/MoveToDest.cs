using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToDest : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _moveTarget;
    private Animator _anim;
    private float _speed = 0;
    private Vector3 _lastPosition;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
        _lastPosition = transform.position;
    }

    private void Update()
    {
        _speed = Mathf.Lerp(_speed, (transform.position - _lastPosition).magnitude / Time.deltaTime, 0.75f);
        _anim.SetFloat("Speed", _speed);
        _lastPosition = transform.position;
    }

    public void setMoveTarget(Vector3 dest)
    {
        _agent.destination = dest;
    }

    public void unsetMoveTarget()
    {
        _agent.destination = this.transform.position;
    }
}