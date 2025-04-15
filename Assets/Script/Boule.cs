using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boule : MonoBehaviour
{
    private float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;
        movement += Vector2.left;
        transform.position += (Vector3)(movement.normalized * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "p1" || other.gameObject.tag == "p2")
        {
            Destroy(this.gameObject);
            other.GetComponent<Player>().TakeDamage();
        }
    }
}
