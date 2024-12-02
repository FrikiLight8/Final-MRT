using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

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
    }
}

