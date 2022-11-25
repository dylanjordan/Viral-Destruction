using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{

    NavMeshAgent agent;

    public Transform[] waypoints;
    int index;
    Vector3 target; 

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdatePos();
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }


    private void UpdatePos()
    {
        target = waypoints[index].position;
        agent.SetDestination(target);
    }

    private void UpdateWaypoint()
    {
        index++;
        if (index == waypoints.Length)
        {
            index = 0;
        }
    }

    public void Patrol()
    {
        if (Vector3.Distance(transform.position, target) < 2)
        {

            UpdateWaypoint();
            UpdatePos();
        }
    }
}
