using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [Tooltip("Vida maxima que tendra el jugador")]
    public int maxHealth;
    // Referencia a la health bar filling de la UI de unity
    private Image fillingImage;
    // Vida actual del jugador
    private int currentHealth;

    private void Start()
    {
        this.fillingImage = GetComponent<Image>();
        this.currentHealth = this.maxHealth;

        this.UpdateHealthBar();
    }

    // El metodo aplica daño añ jugador y devuelve el estado de Game Over (true)
    public bool ApplyDamage(int damage)
    {
        // Aplicar el daño a la vida actual
        this.currentHealth -= damage;
        // Si aun me queda vida, debo actualizar la barra de vida actual
        if (currentHealth > 0)
        {
            this.UpdateHealthBar();
            return false;
        }
        currentHealth = 0;
        UpdateHealthBar();
        return true;
    }

    void UpdateHealthBar()
    {
        // Calculo el porcentaje de vida que me queda (da un valor entre 0 y 1)
        float percentage = this.currentHealth * 1.0f / maxHealth;
        // Aplico el porcentage de relleno a la barra de vida
        this.fillingImage.fillAmount = percentage;
    }
}
