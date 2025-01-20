using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float dano;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private ParticleSystem particulas;


    private int direccion = 1;

    private void Update()
    {
        transform.Translate(Vector2.right * direccion * velocidad * Time.deltaTime);

    }

    public void SetDireccion (int dir)
    {
        direccion = dir;
        if (dir == -1)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            particulas.Play();
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            particulas.Play();

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("enemigo"))
        {
            other.GetComponent<Enemigo>().TomaDano(dano);
            Destroy(gameObject);
        }
    }
}
