using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionDuration = 1f; // Tiempo que dura la explosión antes de desaparecer
    public string targetLayer = "Destructible"; // Nombre de la capa a destruir
    public float explosionRadius = 2f; // Radio de la explosión

    void Start()
    {
        // Detectar y destruir objetos en el radio de la explosión
        Explode();

        // Destruir la explosión después de su duración
        Destroy(gameObject, explosionDuration);
    }

    void Explode()
    {
        // Obtener todos los objetos dentro del radio de la explosión
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hitCollider in hitColliders)
        {
            // Verificar si el objeto pertenece a la capa objetivo
            if (hitCollider.gameObject.layer == LayerMask.NameToLayer(targetLayer))
            {
                // Destruir el objeto
                Destroy(hitCollider.gameObject);
            }
        }
    }
}
