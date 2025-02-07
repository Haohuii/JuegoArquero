using UnityEngine;
using UnityEngine.UI;

public class MusicaController : MonoBehaviour {
    public AudioClip musicClip;  // El AudioClip de la música de fondo
    private AudioSource reproductorMusica;  // El AudioSource para reproducir la música
    private static MusicaController instance;

    void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;

       // DontDestroyOnLoad(gameObject);
        reproductorMusica = GetComponent<AudioSource>();
        reproductorMusica.clip = musicClip;
        reproductorMusica.loop = true;  // Aseguramos que la música se repita
        reproductorMusica.Play();

    }
}
