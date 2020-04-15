using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private Waypoint nextWaypoint;

    private Waypoint option1, option2;

    // Devuelve la posicion del waypoint actual
    public Vector3 GetPosition()
    {
        return this.transform.position;
    }

    // Devuelve el siquiente punto de ruta
    public Waypoint GetNextWaypoint()
    {
        if (nextWaypoint != null)
        {
            return this.nextWaypoint;
        }

        if (Random.Range(0, 2) == 0)
        {
            return option1;
        }
        return option2;
    }
}
