using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rikayon : MonoBehaviour {

    public Animator animator;
	[SerializeField] private float maxHealth = 100;
	[SerializeField] private HealthBar healthBar;
	private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealthbar(maxHealth, currentHealth);
    }
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("Attack_1");
        }

	}

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            healthBar.UpdateHealthbar(maxHealth, currentHealth);
            animator.SetTrigger("Die");
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            healthBar.UpdateHealthbar(maxHealth, currentHealth);
            animator.SetTrigger("Take_Damage_1");
        }
    }
}
