using UnityEngine;

public class CamaraSc : MonoBehaviour
{

    public GameObject Target;
    private Vector3 TargetPos;

    public float HaciaAdelante;
    public float Suavidad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TargetPos = new Vector3 (Target.transform.position.x, Target.transform.position.y, transform.position.z);

        if (Target.transform.localScale.x == 1)
        {
            TargetPos = new Vector3 (TargetPos.x + HaciaAdelante, TargetPos.y, transform.position.z);
        }

        if (Target.transform.localScale.x == -1)
        {
            TargetPos = new Vector3 (TargetPos.x - HaciaAdelante, TargetPos.y, transform.position.z);
        }

        transform.position = Vector3.Lerp(transform.position, TargetPos, Suavidad * Time.deltaTime);
    }
}
