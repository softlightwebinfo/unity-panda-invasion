using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [Header("Variables de ataque")]
    [Tooltip("Distancia maxima a la que puede disparar la torreta")]
    public float rangeRadius;
    [Tooltip("Tiempo de recarga antes de poder disparar otra vez")]
    public float reloadTime;
    [Tooltip("Prefab del tipo de projectil que va a disparar mi torreta")]
    public GameObject projectil;
    [Tooltip("Tiempo que ha pasado desde la ultima vez que la torreta disparo")]
    private float timeSinceLastShot;

    [Header("Niveles de torreta")]
    [Tooltip("Nivel actual de la torreta")]
    private int _upgradeLevel;
    [Tooltip("Sprites de los diferentes niveles de mejora de la torreta")]
    public Sprite[] upgradeSprites;
    [Tooltip("Variables para saber si una torreta se puede actualizar")]
    public bool isUpgradable = true;

    [Header("Economia de la torreta")]
    [Tooltip("Precio de comprar la torreta")]
    public int initialCost;
    [Tooltip("Precio de mejorar la torreta de nivel")]
    public int upgradeCost;
    [Tooltip("Precio de venta de la torreta")]
    public int sellCost;
    [Tooltip("Precio de incremento de venta")]
    public int sellIncrementCost;
    [Tooltip("Precio de incremento de mejora")]
    public int upgradeIncrementCost;

    public int upgradeLevel
    {
        get { return _upgradeLevel; }
        set { _upgradeLevel = value; }
    }


    private void Update()
    {
        if (this.timeSinceLastShot >= this.reloadTime)
        {
            // Codigo de disparar
            this.timeSinceLastShot = 0;
            // Encontrar todos los gameObject que tengan un collider dentro de mi rango de disparo
            // OverlapCircleAll -> desde donde estoy crea un circulo con un rango y traeme todos los Colliders que estan dentro
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(this.transform.position, this.rangeRadius);
            if (hitColliders.Length != 0)
            {
                // Programar la logica de disparo contra los posibles objetivos
                // Bucle entre todos los objetos anteriores para encontrar el panda mas cercano
                float minDistance = int.MaxValue;
                int index = -1;

                for (int i = 0; i < hitColliders.Length; i++)
                {
                    if (hitColliders[i].tag == "Enemy")
                    {
                        // Estoy seguro de que he chocado contra un panda
                        float distance = Vector2.Distance(hitColliders[i].transform.position, this.transform.position);
                        if (distance < minDistance)
                        {
                            index = i;
                            minDistance = distance;
                        }
                    }
                }

                if (index < 0)
                {
                    return;
                }

                Transform target = hitColliders[index].transform;
                Vector2 direction = (target.position - this.transform.position).normalized;

                GameObject projectile = GameObject.Instantiate(this.projectil, this.transform.position, Quaternion.identity) as GameObject;
                projectil.GetComponent<ProjectileScript>().direction = direction;

            }
        }

        this.timeSinceLastShot += Time.deltaTime;
    }

    // Metodo para subir de nivel una torreta
    public void UpgradeTower()
    {
        if (!this.isUpgradable) return;

        // Subimos de nivel
        this.upgradeLevel++;

        if (this.upgradeLevel == upgradeSprites.Length)
        {
            this.isUpgradable = false;
        }

        // Mejorar estados

        rangeRadius += 1f;
        reloadTime -= 0.5f;

        // Subimos los precios de mejora y de venta
        sellCost += sellIncrementCost;
        upgradeCost += upgradeIncrementCost;

        this.GetComponent<SpriteRenderer>().sprite = this.upgradeSprites[this.upgradeLevel];
    }

    private void OnMouseDown()
    {
        // Cuando el usuario clique en una torreta, esta se convierte en la torrecta actual
        TradeCupcakeTower.SetActiveTower(this);
        Debug.Log("He seleccionado una torreta");
    }

    public void DestroyTower()
    {
        Destroy(this.gameObject);
    }
}
