using UnityEngine;

public class VidaJugador : MonoBehaviour
{
    public int cantidadDeVida;
    public FinController f = new FinController();

    public void TomaDano (int dano)
    {
        cantidadDeVida -= dano;
        if (cantidadDeVida <= 0)
        {
            Destroy(gameObject);
            f.LoadGame();
        }
    }
}
