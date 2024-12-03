using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Asegúrate de incluir esto para TextMeshPro

public class UI : MonoBehaviour
{
    public TMP_Text bombCooldownText; // UI TextMeshPro para mostrar el tiempo de espera de la bomba
    public TMP_Text gameTimeText; // UI TextMeshPro para mostrar el tiempo total de la partida

    public float bombCooldown = 2f; // Tiempo de espera entre bombas
    private float lastBombTime = -Mathf.Infinity; // Última vez que se colocó una bomba
    private float gameTime = 0f; // Tiempo total de la partida

    void Update()
    {
        // Actualizar el tiempo total de la partida
        gameTime += Time.deltaTime;
        UpdateGameTimeUI();

        // Calcular el tiempo restante para la bomba
        float timeUntilBomb = bombCooldown - (Time.time - lastBombTime);
        if (timeUntilBomb < 0)
        {
            timeUntilBomb = 0; // No permitir que el tiempo de espera sea negativo
        }

        // Actualizar la UI con el tiempo de espera para la bomba
        UpdateBombCooldownUI(timeUntilBomb);

        // Detectar si se presiona la tecla para colocar una bomba
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastBombTime + bombCooldown)
        {
            PlaceBomb();
        }
    }

    void UpdateGameTimeUI()
    {
        // Muestra el tiempo de la partida en formato de minutos y segundos
        int minutes = Mathf.FloorToInt(gameTime / 60f);
        int seconds = Mathf.FloorToInt(gameTime % 60f);
        gameTimeText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }

    void UpdateBombCooldownUI(float timeUntilBomb)
    {
        // Muestra el tiempo restante para la bomba
        int secondsRemaining = Mathf.FloorToInt(timeUntilBomb);
        bombCooldownText.text = string.Format("Bomb Ready: {0} s", secondsRemaining);
    }

    void PlaceBomb()
    {
        // Coloca la bomba en la posición del jugador
        // (suponiendo que tengas una función que haga esto, como en el código anterior)
        lastBombTime = Time.time; // Actualiza el tiempo de la última bomba
    }
}
