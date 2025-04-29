using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject PauseMenuCanvas; // Aquí arrastras tu PauseMenuCanvas en el Inspector
    private bool isPaused = false;

    void Start()
    {
        PauseMenuCanvas.SetActive(false); // Oculta el menú al iniciar el juego
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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

    public void PauseGame()
    {
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f; // Congela el juego
        isPaused = true;
    }

    public void ResumeGame()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f; // Descongela el juego
        isPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo...");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

