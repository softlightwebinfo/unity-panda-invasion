using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TradeCupcakeTowerUpgrade : TradeCupcakeTower
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (!currentActiveTower) return;

        // Solo podremos subirla de nivel si no esta ya al maximo y si tenemos suficiente dinero
        int upgradePrice = currentActiveTower.upgradeCost;

        if (currentActiveTower.isUpgradable && upgradePrice <= sugarMeter.getSugarScore())
        {
            sugarMeter.AddSugar(-upgradePrice);
            // Subo de nivel la torreta actual
            currentActiveTower.UpgradeTower();
        }
    }
}
