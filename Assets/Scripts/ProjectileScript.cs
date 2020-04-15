using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [Tooltip("Cuanto daño recibira el enemigo")]
    public float damage;
    [Tooltip("Velocidad a la que se mueve el projectil")]
    public float speed = 1.0f;
    [Tooltip("Direccion en la que apunta el projectil")]
    public Vector3 direction;
    [Tooltip("Tiempo de vida del projectil en segundos")]
    public float lifeDuration = 10.0f;

    private Rigidbody2D m_rigidbody;

    // Use this for initialization
    void Start()
    {

        this.m_rigidbody = GetComponent<Rigidbody2D>();

        //Normalizamos la dirección del proyectil -> tamaño = 1
        direction = direction.normalized;

        //Rotamos el proyectil
        float angleRad = Mathf.Atan2(-direction.y, direction.x);
        float angleDeg = angleRad * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angleDeg, Vector3.forward);

        //Pre programar destrucción del proyectil
        Destroy(gameObject, this.lifeDuration);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // s = v * t
        //transform.position += ( speed * direction ) * Time.deltaTime;
        this.m_rigidbody.MovePosition(transform.position + (this.speed * this.direction) * Time.fixedDeltaTime);

    }
}
