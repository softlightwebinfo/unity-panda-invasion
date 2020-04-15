using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private Waypoint nextWaypoint;

    // Devuelve la posicion del waypoint actual
    public Vector3 GetPosition()
    {
        return this.transform.position;
    }

    // Devuelve el siquiente punto de ruta
    public Waypoint GetNextWaypoint()
    {
        return this.nextWaypoint;
    }
}
