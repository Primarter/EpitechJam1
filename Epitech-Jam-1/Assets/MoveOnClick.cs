using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveOnClick : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _moveTarget;
    private Vector3 _lastPosition;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _lastPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                _agent.destination = hit.point;
            }
        }
    }
}
