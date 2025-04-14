using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBulletOnScreen : MonoBehaviour
{
    void Update()
    {
        // Vérifier si l'objet est en dehors de l'écran
        if (!IsObjectOnScreen())
        {
            Destroy(this.gameObject);
        }
    }

    bool IsObjectOnScreen()
    {
        // Obtenir les coordonnées de l'objet dans l'espace de la caméra
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);

        // Si l'objet est en dehors des limites de l'écran (valeurs entre 0 et 1)
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1;
    }
}
