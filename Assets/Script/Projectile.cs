using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;
        movement += Vector2.right;
        transform.position += (Vector3)(movement.normalized * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            print("Enemy " + collision.gameObject.name);
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<Enemy>().TakeDamage(1);
        }
    }
}