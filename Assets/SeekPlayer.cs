using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SeekPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    Transform player;

    Transform currentTarget = null;
    EnemyFOV fov;
    
    float distToPlayer;
    public float speed;
    public float seekDist;
    public float escapeDist;
    NavMeshAgent enemy;
    Rigidbody enemyBody;
    EnemyAI enemyAI;


    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        fov = GetComponent<EnemyFOV>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyBody = GetComponent<Rigidbody>();
        enemy = GetComponent<NavMeshAgent>();

        //makes it so the checkdistance methood is only called once per second and not every frame
        InvokeRepeating("CheckDistance", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentTarget != null || fov.canSeePlayer == true)
        {
            enemy.destination = player.position;
        }
        else
        {
            enemyAI.Patrol();
        }
        
       
    }

    void CheckDistance()
    {
        
        distToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distToPlayer <= seekDist)
        {
            currentTarget = player;
            Debug.Log("going to player");


        }
        else if (distToPlayer <= escapeDist)
        {

            currentTarget = null;
            Debug.Log("not going to player");
        }
    }
}
