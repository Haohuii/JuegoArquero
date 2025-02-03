
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    public Transform controladorDisparo;
    public float distanciaLinea;
    public LayerMask capaJugador;
    public bool jugadorEnRango;
    public GameObject balaEnemigo;
    public float tiempoEntreDisparos;
    public float timepoUltimoDisparo;
     public float timepoEsperaDisparo;
    void Start()
    {
        
    }


    void Update()
    {
        jugadorEnRango = Physics2D.Raycast(controladorDisparo.position, -transform.right, distanciaLinea, capaJugador);

        if (jugadorEnRango)
        {
            if (Time.time > tiempoEntreDisparos + timepoUltimoDisparo)
            {
                timepoUltimoDisparo = Time.time;
                Invoke(nameof(Disparar), timepoEsperaDisparo);
            }
        }
    }
    private void Disparar ()
    {
        // Instanciar la bala en la posición del controlador de disparo
        // Asegúrate de que la bala siempre vaya hacia la izquierda
        GameObject bala = Instantiate(balaEnemigo, controladorDisparo.position, controladorDisparo.rotation);

        // Obtener el Rigidbody2D de la bala
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Mover la bala hacia la izquierda con velocidad negativa en x
            rb.linearVelocity = -transform.right * 5f; // 5f es la velocidad de la bala, puedes ajustarla según lo necesites
        }
        // Instantiate(balaEnemigo, controladorDisparo.position, controladorDisparo.rotation);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorDisparo.position, controladorDisparo.position - transform.right * distanciaLinea);
    }
}
