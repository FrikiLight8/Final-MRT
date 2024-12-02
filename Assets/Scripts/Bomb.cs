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
        // Ajustar la posición de la explosión restando 0.5 al eje X
        Vector3 explosionPosition = new Vector3(
            transform.position.x - 1f, // Restar 0.5 al eje X
            transform.position.y,       // Mantener Y
            transform.position.z        // Mantener Z
        );

        // Crear la explosión en la posición ajustada
        Instantiate(explosionPrefab, explosionPosition, Quaternion.identity);

        // Destruir la bomba
        Destroy(gameObject);
    }


}

