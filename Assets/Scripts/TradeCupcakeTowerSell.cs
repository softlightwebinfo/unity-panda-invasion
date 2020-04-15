using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TradeCupcakeTowerSell : TradeCupcakeTower
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        // Comprobare si hay una torreta seleccionado para ser vendida
        if (!currentActiveTower) return;
        // Consulto el precio de venta de la torreta
        int sellingPrice = currentActiveTower.sellCost;
        // Sumamos ese dinero al medidor de azucar del usuario
        sugarMeter.AddSugar(sellingPrice);
        // Destruimos el cupcake actual
        currentActiveTower.DestroyTower();
    }
}
