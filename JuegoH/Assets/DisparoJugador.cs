using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisparoJugador : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;

    [SerializeField] private GameObject bala;
    private ControladorTom controladorTom;

    private void Start()
    {
        // Obtener la referencia automáticamente
        controladorTom = FindObjectOfType<ControladorTom>();  // Busca el primer objeto que tenga el script ControladorTom
    }

    private void Update() 
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    private void Disparar() 
    {
        if (controladorTom == null) 
        {
            Debug.LogError("ControladorTom no está asignado.");
            return;
        }
        GameObject flecha = Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
        NewMonoBehaviourScript flechaScript = flecha.GetComponent<NewMonoBehaviourScript>();
        if (controladorTom.mirarIzq)
        {
            flechaScript.SetDireccion(-1);
        }
        else
        {
            flechaScript.SetDireccion(1);
        }
    }
}
