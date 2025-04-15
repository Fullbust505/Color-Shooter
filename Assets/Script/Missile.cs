using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private float speed = 3f;
    public Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "p1" || other.gameObject.tag == "p2")
        {
            Destroy(this.gameObject);
            other.GetComponent<Player>().TakeDamage();
        }
    }

    public void SetDirection(Vector3 dir)
    {
        moveDirection = dir;
        moveDirection.z = 0;
    }

    void OnBecameInvisible()
    {
        Debug.Log("Missile est devenu invisible !");
    }
}