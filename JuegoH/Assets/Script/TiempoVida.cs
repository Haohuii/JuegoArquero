using UnityEngine;

public class TiempoVida : MonoBehaviour
{
    [SerializeField] private float tiempoVida;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, tiempoVida);
    }

}
