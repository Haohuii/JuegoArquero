using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    
    [SerializeField] private GameObject efectoMuerte;

    public void TomaDano (float dano)
    {
        vida -= dano;
        if (vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        Instantiate(efectoMuerte, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


}
