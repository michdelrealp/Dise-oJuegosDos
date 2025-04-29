using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        // Cambia "GameScene" por el nombre real de tu escena principal
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();

        // Importante: Application.Quit() solo funciona en el build final, no en el editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}


