using UnityEngine;
using UnityEngine.SceneManagement; // Para cargar escenas si quieres un menú

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI; // El menú de pausa (opcional, por si quieres mostrar algo)
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Si presiona 'Esc'
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);

        Time.timeScale = 1f; // Reanuda el juego
        isPaused = false;
    }

    void Pause()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true);

        Time.timeScale = 0f; // Detiene el tiempo (pausa)
        isPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Cierra la aplicación cuando está en ejecutable
    }
}
