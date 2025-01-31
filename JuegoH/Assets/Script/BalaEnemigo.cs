using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{

    public float velocidad;
    public int dano;

    void Update()
    {
        transform.Translate(Time.deltaTime * velocidad * Vector2.right);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out VidaJugador vidaJugador))
        {
            vidaJugador.TomaDano(dano);
            Destroy(gameObject);

        }
    }
}
