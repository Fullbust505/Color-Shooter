using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Rusheur : Enemy
{
    private NavMeshAgent agent;
    private Vector3 moveDirection;
    private float speed = 5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        SetTargetPosition();
        hpAmount = 1;
 
    }

    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    void SetTargetPosition()
    {
        if (Mathf.Sqrt(Mathf.Pow(this.transform.position.x - Player1.transform.position.x, 2) + Mathf.Pow(this.transform.position.y - Player1.transform.position.y, 2)) < Mathf.Sqrt(Mathf.Pow(this.transform.position.x - Player2.transform.position.x, 2) + Mathf.Pow(this.transform.position.y - Player2.transform.position.y, 2)))
        {
            Vector3 dir = (Player1.transform.position - transform.position).normalized;
            moveDirection = dir;
        }
        else
        {
            Vector3 dir = (Player2.transform.position - transform.position).normalized;
            moveDirection = dir;
        }
    }
}
