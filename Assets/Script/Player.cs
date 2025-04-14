using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 0.02f;
    public GameObject bullet;


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

        if (Input.GetKey(KeyCode.W)) movement += Vector2.up;
        if (Input.GetKey(KeyCode.S)) movement += Vector2.down;
        if (Input.GetKey(KeyCode.A)) movement += Vector2.left;
        if (Input.GetKey(KeyCode.D)) movement += Vector2.right;

        // Appliquer le mouvement
        transform.position += (Vector3)(movement.normalized * speed);

    }
}
