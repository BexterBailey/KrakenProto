using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthbarSprite;

    public void UpdateHealthbar(float maxHealth, float currentHealth)
    {
        healthbarSprite.fillAmount = currentHealth/maxHealth;
    }

}
