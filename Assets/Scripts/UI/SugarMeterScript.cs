using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SugarMeterScript : MonoBehaviour
{
    // Variable que indica donde se mostrara los puntos
    private Text sugarMeter;
    // Variable que guarda el numero de puntos
    private int sugarScore = 50;
    private void Start()
    {
        this.sugarMeter = this.GetComponent<Text>();
        this.UpdateSugarMeter();
    }

    public int getSugarScore() { return sugarScore; }

    public void AddSugar(int sugar)
    {
        this.sugarScore += sugar;

        if (sugarScore < 0)
        {
            sugarScore = 0;
        }
        this.UpdateSugarMeter();
    }

    void UpdateSugarMeter()
    {
        this.sugarMeter.text = this.sugarScore.ToString();
    }
}
