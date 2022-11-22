using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    Transform player;
    float distToPlayer;
    public float speed;
    public float SeekDist;

    Rigidbody enemyBody;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector3.Distance(player.position, transform.position);

        if (distToPlayer <= SeekDist)
        {
            transform.LookAt(player);
            enemyBody.AddForce(transform.forward * speed);


        }
    }
}
