using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TradeCupcakeTowerBuy : TradeCupcakeTower
{
    [Tooltip("Variable para identificar el prefab de la torreta que debemos instanciar con este botón")]
    public GameObject cupcakeTowerPrefab;

    public override void OnPointerClick(PointerEventData eventData)
    {
        // Recuperamos el precio de crear una torreta
        int price = cupcakeTowerPrefab.GetComponent<TowerScript>().initialCost;

        // Comprobaremos si el usuario tiene suficiente dinero para poder comprar esta torreta

        if (price <= sugarMeter.getSugarScore())
        {
            // Aqui tengo suficiente dinero, asi que puedo comprar la torreta
            // Descuento del contador
            sugarMeter.AddSugar(-price);
            // Instanciamos
            GameObject newTower = Instantiate(cupcakeTowerPrefab);
            // Asignamos a la torreta actual
            currentActiveTower = newTower.GetComponent<TowerScript>();
        }
    }
}
