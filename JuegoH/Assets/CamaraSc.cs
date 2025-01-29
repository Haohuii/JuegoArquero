using UnityEngine;

public class CamaraSc : MonoBehaviour
{

    public GameObject Target;
    private Vector3 TargetPos;

    public float HaciaAdelante;
    public float Suavidad;
    [SerializeField]
    public float offsetY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula la posición objetivo de la cámara
        TargetPos = new Vector3(Target.transform.position.x, Target.transform.position.y + offsetY, transform.position.z);

        // Determina la dirección en la que el personaje está mirando
        float direccion = Target.transform.localScale.x;

        // Ajusta la posición de la cámara en función de la dirección del personaje
        TargetPos = new Vector3(TargetPos.x + (HaciaAdelante * direccion), TargetPos.y, transform.position.z);

        // Interpola suavemente la posición de la cámara hacia la posición objetivo
        transform.position = Vector3.Lerp(transform.position, TargetPos, Suavidad * Time.deltaTime);
    }
}
