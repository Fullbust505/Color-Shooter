using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 0.02f;
    public GameObject bullet;
    private static int hpAmount = 1;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //spawn du tir
            Instantiate(bullet, this.transform.position, this.transform.rotation);
        }

        // Mouvement du joueur
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.W) && Camera.main.WorldToViewportPoint(transform.position).y <= 1) movement += Vector2.up;
        if (Input.GetKey(KeyCode.S) && Camera.main.WorldToViewportPoint(transform.position).y >= 0) movement += Vector2.down;
        if (Input.GetKey(KeyCode.A) && Camera.main.WorldToViewportPoint(transform.position).x >= 0) movement += Vector2.left;
        if (Input.GetKey(KeyCode.D) && Camera.main.WorldToViewportPoint(transform.position).x <= 1) movement += Vector2.right;

        // Appliquer le mouvement
        transform.position += (Vector3)(movement.normalized * speed);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            this.TakeDamage();
        }
    }

    public void TakeDamage()
    {
        hpAmount -= 1;
       
        if (hpAmount <= 0)
        {
            this.PlayerDead();
        }
    }

    void PlayerDead()
    {
        Player[] allplayers = FindObjectsOfType<Player>();
        foreach (Player p in allplayers)
        {
            Destroy(p.gameObject);
        }

        Debug.Log(allplayers.Length + " tous les joueurs ont été détruit.");
    }
}