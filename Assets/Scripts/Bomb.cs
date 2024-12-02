using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour

{
    public GameObject explosionPrefab; // Prefab de la explosión
    public float explosionDelay = 3f;  // Tiempo antes de la explosión

    void Start()
    {
        // Invocar la explosión después del tiempo de demora
        Invoke("Explode", explosionDelay);
    }

    void Explode()
    {
        // Asegurarse de que la explosión ocurra en la misma posición que la bomba
        Vector3 explosionPosition = new Vector3(
            Mathf.Round(transform.position.x),
            transform.position.y,
            Mathf.Round(transform.position.z)
        );

        // Crear la explosión en la posición ajustada
        Instantiate(explosionPrefab, explosionPosition, Quaternion.identity);

        // Destruir la bomba
        Destroy(gameObject);
    }

}

