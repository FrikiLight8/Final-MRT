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
        // Ajustar la posici�n de la explosi�n restando 0.5 al eje X
        Vector3 explosionPosition = new Vector3(
            transform.position.x - 1f, // Restar 0.5 al eje X
            transform.position.y,       // Mantener Y
            transform.position.z        // Mantener Z
        );

        // Crear la explosi�n en la posici�n ajustada
        Instantiate(explosionPrefab, explosionPosition, Quaternion.identity);

        // Destruir la bomba
        Destroy(gameObject);
    }


}

