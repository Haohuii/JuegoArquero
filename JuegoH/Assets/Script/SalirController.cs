using UnityEngine;
using UnityEngine.SceneManagement;

public class SalirController : MonoBehaviour
{
    public void LoadGame()
    {
        // Cargar la escena del juego
        SceneManager.LoadScene(0);
    }
}
