using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class TradeCupcakeTower : MonoBehaviour, IPointerClickHandler
{
    // Medidor de azucar para saber cuantos puntos para gastar tenemos
    protected static SugarMeterScript sugarMeter;

    // Torreta seleccionada actualmente para ser mejorada o vendida
    protected static TowerScript currentActiveTower;

    private void Start()
    {
        if (!sugarMeter)
        {
            sugarMeter = FindObjectOfType<SugarMeterScript>();
        }
    }

    public static void SetActiveTower(TowerScript newCupcakeTower)
    {
        currentActiveTower = newCupcakeTower;
    }

    public abstract void OnPointerClick(PointerEventData eventData);
}
