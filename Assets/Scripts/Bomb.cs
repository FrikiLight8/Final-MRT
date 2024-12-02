using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour

{
    public GameObject explosionPrefab; // Prefab de la explosi�n
    public float explosionDelay = 3f;  // Tiempo antes de la explosi�n

    void Start()
    {
        // Invocar la explosi�n despu�s del tiempo de demora
        Invoke("Explode", explosionDelay);
    }

    void Explode()
    {
        // Asegurarse de que la explosi�n ocurra en la misma posici�n que la bomba
        Vector3 explosionPosition = new Vector3(
            Mathf.Round(transform.position.x),
            transform.position.y,
            Mathf.Round(transform.position.z)
        );

        // Crear la explosi�n en la posici�n ajustada
        Instantiate(explosionPrefab, explosionPosition, Quaternion.identity);

        // Destruir la bomba
        Destroy(gameObject);
    }

}

