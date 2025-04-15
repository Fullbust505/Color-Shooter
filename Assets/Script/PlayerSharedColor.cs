using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using UnityEngine;

public class PlayerSharedColor : MonoBehaviour
{
    public bool isPlayerOne = true; // Coche ça pour le joueur 1 dans l’inspecteur
    public GameObject bullet;

    private Renderer rend;
    private float speed = 0.02f;
    private float bHoldTimer = 0f;
    private float switchThreshold = 1f;
    private bool hasSwitched = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        UpdateColor();
    }

    void Update()
    {
        // Gestion du changement de couleur synchronisé
        if (Input.GetKey(KeyCode.B) && isPlayerOne)
        {
            bHoldTimer += Time.deltaTime;

            if (bHoldTimer >= switchThreshold && !hasSwitched)
            {
                GameState.ToggleColor();  // Change la couleur globale
                hasSwitched = true;
            }
        }
        else
        {
            Debug.Log("B est reset");
            bHoldTimer = 0f;
            hasSwitched = false;
        }

        UpdateColor();

        // Tir
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }

        Vector2 movement = Vector2.zero;

        if (isPlayerOne)
        {
            if (Input.GetKey(KeyCode.W) && Camera.main.WorldToViewportPoint(transform.position).y <= 1) movement += Vector2.up;
            if (Input.GetKey(KeyCode.S) && Camera.main.WorldToViewportPoint(transform.position).y >= 0) movement += Vector2.down;
            if (Input.GetKey(KeyCode.A) && Camera.main.WorldToViewportPoint(transform.position).x >= 0) movement += Vector2.left;
            if (Input.GetKey(KeyCode.D) && Camera.main.WorldToViewportPoint(transform.position).x <= 1) movement += Vector2.right;
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow) && Camera.main.WorldToViewportPoint(transform.position).y <= 1) movement += Vector2.up;
            if (Input.GetKey(KeyCode.DownArrow) && Camera.main.WorldToViewportPoint(transform.position).y >= 0) movement += Vector2.down;
            if (Input.GetKey(KeyCode.LeftArrow) && Camera.main.WorldToViewportPoint(transform.position).x >= 0) movement += Vector2.left;
            if (Input.GetKey(KeyCode.RightArrow) && Camera.main.WorldToViewportPoint(transform.position).x <= 1) movement += Vector2.right;
        }

        transform.position += (Vector3)(movement.normalized * speed);
    }

    void UpdateColor()
    {
        if (isPlayerOne)
        {
            rend.material.color = GameState.currentColor;
        }
        else
        {
            rend.material.color = GameState.GetOppositeColor();
        }
    }
}