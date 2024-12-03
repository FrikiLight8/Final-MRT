using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para reiniciar la escena
using UnityEngine.UI; // Necesario para interactuar con los UI buttons

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;  // Referencia al panel del menú de pausa
    private bool isPaused = false;

    void Update()
    {
        // Detectar si se presiona la tecla de pausa (Esc o P)
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Pausar el juego
    void PauseGame()
    {
        pauseMenuUI.SetActive(true); // Activar el menú de pausa
        Time.timeScale = 0f; // Detener el tiempo del juego
        isPaused = true; // Marcar el juego como pausado

        // Activar el mouse
        Cursor.visible = true; // Hacer el cursor visible
        Cursor.lockState = CursorLockMode.None; // Liberar el cursor (puede moverse libremente)
    }

    // Reanudar el juego
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // Desactivar el menú de pausa
        Time.timeScale = 1f; // Reanudar el tiempo del juego
        isPaused = false; // Marcar el juego como no pausado

        // Desactivar el mouse
        Cursor.visible = false; // Hacer el cursor invisible
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor al centro de la pantalla
    }

    // Reiniciar la escena
    public void RestartGame()
    {
        Time.timeScale = 1f; // Asegurarse de que el tiempo vuelva a la normalidad
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reiniciar la escena actual
    }

    // Salir del juego
    public void QuitGame()
    {
        // Salir del juego (solo funciona en un build, no en el editor)
        Application.Quit();
    }
}
