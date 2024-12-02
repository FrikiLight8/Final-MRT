using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed = 5f;
    private Rigidbody rb;
    [SerializeField]
    public GameObject bombPrefab; // Prefab de la bomba
    public float bombCooldown = 2f; // Tiempo de espera entre colocar bombas
    private float lastBombTime = -Mathf.Infinity; // Última vez que se colocó una bomba

    [SerializeField]
    private Transform bombSpawnPoint; // El GameObject desde el que se invocarán las bombas

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Entrada de movimiento (en el plano XZ global)
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W)) moveX = -1f;  // Arriba
        if (Input.GetKey(KeyCode.S)) moveX = 1f; // Abajo
        if (Input.GetKey(KeyCode.A)) moveZ = -1f; // Izquierda
        if (Input.GetKey(KeyCode.D)) moveZ = 1f;  // Derecha

        // Crear el vector de movimiento y normalizar
        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized;

        // Aplicar el movimiento
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // Detectar si se presiona la tecla para colocar una bomba
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastBombTime + bombCooldown)
        {
            PlaceBomb();
        }
    }

    void PlaceBomb()
    {
        // Usar la posición del GameObject de referencia (bombSpawnPoint) para colocar la bomba
        Vector3 bombPosition = new Vector3(
            bombSpawnPoint.position.x, // Usar X del GameObject de referencia
            0f,                        // Fijar Y en 0
            bombSpawnPoint.position.z  // Usar Z del GameObject de referencia
        );

        // Instanciar la bomba en la posición ajustada
        Instantiate(bombPrefab, bombPosition, Quaternion.identity);

        // Actualizar el tiempo de colocación de la última bomba
        lastBombTime = Time.time;
    }
}
