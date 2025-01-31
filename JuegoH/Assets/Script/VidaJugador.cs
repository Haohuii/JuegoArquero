using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    public int cantidadDeVida;

    public void TomaDano (int dano)
    {
        cantidadDeVida -= dano;
        if (cantidadDeVida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
