using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    protected int hpAmount;
    public GameObject Player1;
    public GameObject Player2;

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