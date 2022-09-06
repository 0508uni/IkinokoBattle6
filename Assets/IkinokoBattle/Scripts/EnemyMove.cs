using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update

    // [SerializeField] private PlayerController _playerController;

    private NavMeshAgent _agent;
    private RaycastHit[] _raycastHits = new RaycastHit[10];
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
   /* void Update()
    {
        _agent.destination = _playerController.transform.position;
    }*/

    public void OnDetectObject(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            var positionDiff = collider.transform.position - transform.position;

            var distance = positionDiff.magnitude;

            var direction = positionDiff.normalized;

            var hitCount = Physics.RaycastNonAlloc(transform.position, direction, _raycastHits, distance);
            Debug.Log("hitCount:" + hitCount);

            if(hitCount == 0)
            {
                _agent.isStopped = false;
                _agent.destination = collider.transform.position;
            }
            else
            {
                _agent.isStopped = true;
            }
        }
    }
}
