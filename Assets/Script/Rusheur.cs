using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject Player1;
    public GameObject Player2;
    private Vector3 moveDirection;
    private float speed = 5f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        SetTargetPosition();
 
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
