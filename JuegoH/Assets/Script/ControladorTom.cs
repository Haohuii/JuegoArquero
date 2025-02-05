using UnityEngine;

public class ControladorTom : MonoBehaviour
{
    private bool jump;
    private float idleTime = 0f;
    public float maxIdleTime = 5f;
    public bool mirarIzq;

    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        boxCollider.size = spriteRenderer.sprite.bounds.size;
        boxCollider.offset = spriteRenderer.sprite.bounds.center;

        if (Input.GetKey("left"))
        {
            //Aplicar fuerza a la izquierda
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-330f * Time.deltaTime, 0));
            //Activar la animacion de movimientos
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<Animator>().SetBool("arcoV", false);
            gameObject.GetComponent<Animator>().SetBool("atacando", false);

            //Voltear el sprite para mirar a la izquierda
            
            transform.localScale = new Vector3(-1, 1, 1);
            mirarIzq = true;
            // Reseteamos el tiempo de inactividad
            idleTime = 0f;

        }

        if (Input.GetKey("right"))
        {
            //Aplicar fuerza a la derecha
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(330f * Time.deltaTime, 0));
            //Activar la animacion de movimiento
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<Animator>().SetBool("arcoV", false);
            gameObject.GetComponent<Animator>().SetBool("atacando", false);

            //Voltear el sprite para mirar a la izquierda
            
            transform.localScale = new Vector3(1, 1, 1);
            mirarIzq = false;

            // Reseteamos el tiempo de inactividad
            idleTime = 0f;
        }

        //Si no se presiona las teclas 'left' o 'rigth'
        if (!Input.GetKey("left") && !Input.GetKey("right") && !Input.GetKey("space"))
        {
            
            //Desactivar la animación de movimiento
            gameObject.GetComponent<Animator>().SetBool("moving", false);
            gameObject.GetComponent<Animator>().SetBool("atacando", false);

            idleTime += Time.deltaTime;

            // Si el tiempo de inactividad supera el máximo definido
            if (idleTime >= maxIdleTime)
            {
                // Cambiar la animación a arcoVolando
                gameObject.GetComponent<Animator>().SetBool("arcoV", true);
            }
        }
    

        //Saltar cuando se presiona la tecla 'up' y se permite saltar (jump == true)
        if (Input.GetKeyDown("up") && jump)
        {
            //Desactivar la capacidad de saltar hasta que aterrice en una 'cosa'
            jump = false;

            gameObject.GetComponent<Animator>().SetBool("jumping", true);
            gameObject.GetComponent<Animator>().SetBool("arcoV", false);
            gameObject.GetComponent<Animator>().SetBool("atacando", false);

            //Aplicar fuerza arriba
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 335f));
            idleTime = 0f;
        }


        if(Input.GetKey("right") && Input.GetKeyDown("up"))
        {
            gameObject.GetComponent<Animator>().SetBool("jumping", true);
            gameObject.GetComponent<Animator>().SetBool("moving", false);
            gameObject.GetComponent<Animator>().SetBool("atacando", false);
            
        }

        if(Input.GetKey("left") && Input.GetKeyDown("up"))
        {
            gameObject.GetComponent<Animator>().SetBool("jumping", true);
            gameObject.GetComponent<Animator>().SetBool("moving", false);
            gameObject.GetComponent<Animator>().SetBool("atacando", false);
            
        }

        if (Input.GetKey("z"))
        {
            gameObject.GetComponent<Animator>().SetBool("arcoV", false);
            gameObject.GetComponent<Animator>().SetBool("moving", false);
            gameObject.GetComponent<Animator>().SetBool("jumping", false);
            gameObject.GetComponent<Animator>().SetBool("atacando", true);
            idleTime = 0f;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "cosa")
        {
            jump = true;
            gameObject.GetComponent<Animator>().SetBool("jumping", false);
        }
    }


}
