using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBulletOnScreen : MonoBehaviour
{
    void Update()
    {
        // V�rifier si l'objet est en dehors de l'�cran
        if (!IsObjectOnScreen())
        {
            Destroy(this.gameObject);
        }
    }

    bool IsObjectOnScreen()
    {
        // Obtenir les coordonn�es de l'objet dans l'espace de la cam�ra
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);

        // Si l'objet est en dehors des limites de l'�cran (valeurs entre 0 et 1)
        return screenPoint.x >= 0 && screenPoint.x <= 1 && screenPoint.y >= 0 && screenPoint.y <= 1;
    }
}
