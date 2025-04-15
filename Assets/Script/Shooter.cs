using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Shooter : Enemy
{
    private NavMeshAgent agent;
    private Vector3 moveDirection;
    public GameObject missile;
    private float cooldown = 1f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        SetTargetPosition();
        hpAmount = 2;
    }

    void Update()
    {
        SetTargetPosition();
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {

            // Instanciation
            GameObject missileClone = Instantiate(missile, this.transform.position, this.transform.rotation);

            Missile missileScript = missileClone.GetComponent<Missile>();
            if (missileScript != null)
            {
                missileScript.SetDirection(moveDirection); // ou public field
            }
            cooldown = 1f;
        }
    }

    void SetTargetPosition()
    {
        if (Mathf.Sqrt(Mathf.Pow(this.transform.position.x - Main.Joueur1.transform.position.x, 2) + Mathf.Pow(this.transform.position.y - Main.Joueur1.transform.position.y, 2)) < Mathf.Sqrt(Mathf.Pow(this.transform.position.x - Main.Joueur2.transform.position.x, 2) + Mathf.Pow(this.transform.position.y - Main.Joueur2.transform.position.y, 2)))
        {
            Vector3 dir = (Main.Joueur1.transform.position - transform.position).normalized;
            moveDirection = dir;
        }
        else
        {
            Vector3 dir = (Main.Joueur2.transform.position - transform.position).normalized;
            moveDirection = dir;
        }
    }
}
