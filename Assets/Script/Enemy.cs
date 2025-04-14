using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private int hpAmount = 4;
    public GameObject player;
    public GameObject player2;

    public void Start()
    {
    }

    private void Update()
    {
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