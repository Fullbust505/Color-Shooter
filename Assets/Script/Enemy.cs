using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private int hpAmount = 4;
    private NavMeshAgent agent;
    public GameObject player;
    public GameObject player2;

    public void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    public void TakeDamage(int value)
    {
        hpAmount -= value;

        if (hpAmount <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}