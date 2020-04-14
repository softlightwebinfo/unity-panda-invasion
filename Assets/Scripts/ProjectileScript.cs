﻿using System.Collections;
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
    public float lifeDuraction = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        direction = direction.normalized;

        //Rotamos Projectil
        float angleRand = Mathf.Atan2(-direction.y, direction.x);
        float angleDeg = angleRand * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angleDeg, Vector3.forward);

        // Preprogramar destruccion del projectil
        Destroy(gameObject, lifeDuraction);
    }

    // Update is called once per frame
    void Update()
    {
        // s = v * t
        transform.position += speed * direction * Time.deltaTime;
    }
}