using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCupcakeTower : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        this.gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        float z = 7.0f;

        this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, z));

        if (Input.GetMouseButtonDown(0) && gameManager.isPointerOnAllAllowedArea())
        {
            // Habilitamos el script de la torreta para que pueda disparar
            GetComponent<TowerScript>().enabled = true;
            // Le añadimos un collider para evitar que se plante otra torreta encima de la misma
            this.gameObject.AddComponent<BoxCollider2D>();
            Destroy(this);
        }
    }
}
