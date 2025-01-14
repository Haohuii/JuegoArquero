using UnityEngine;

public class EnemigoMover : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 5.0f;
    public float speed = 2.0f;
    private Rigidbody2D rb;
    private Vector2 movement;

    private float randomDirection;
    private float changeDirectionTime = 1f;  // Tiempo en segundos entre cambios de dirección aleatorios
    private float lastDirectionChangeTime = 0f;  // Momento del último cambio de dirección

    private float minX, maxX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Obtener los límites de la pantalla en el mundo
        Vector2 screenMin = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));  // Esquina inferior izquierda
        Vector2 screenMax = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));  // Esquina superior derecha

         // Limitar la posición del enemigo a los límites en el eje X
        minX = screenMin.x + 0.5f; // Ajusta esto según el tamaño de tu sprite
        maxX = screenMax.x - 0.5f; // Ajusta esto según el tamaño de tu sprite
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRadius) 
        {
            Vector2 direction = (player.position - transform.position).normalized;

            movement = new Vector2(direction.x, 0);
        } 
        else
        {
            Comportamiento();
        }

        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);

        LimitarPosicion();

        GirarEnDireccion();
    }





    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    public void Comportamiento()
    {
        // Solo cambiar la dirección aleatoria si ha pasado el tiempo suficiente
        if (Time.time - lastDirectionChangeTime > changeDirectionTime)
        {
            // Generar una nueva dirección aleatoria
            randomDirection = Random.Range(-1f, 1f); // El rango es entre -1 y 1 para generar una dirección aleatoria
            movement = new Vector2(randomDirection, 0).normalized; // Normalizamos para mantener la misma velocidad en todas las direcciones
            
            // Actualizar el tiempo del último cambio
            lastDirectionChangeTime = Time.time;
        }
    }
     
    void GirarEnDireccion()
    {
        // Girar el enemigo dependiendo de la dirección de su movimiento en el eje X
        if (movement.x > 0)
        {
            // Si se mueve hacia la derecha, asegurarse que el enemigo mire a la derecha
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (movement.x < 0)
        {
            // Si se mueve hacia la izquierda, asegurarse que el enemigo mire a la izquierda
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void LimitarPosicion()
    {
        // Restringir la posición del enemigo para que no se salga de la pantalla en el eje X
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);

        // Aplicar la posición restringida
        transform.position = new Vector2(clampedX, transform.position.y);
    }
}
