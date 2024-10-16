using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            transform.parent = other.transform;
            other.GetComponent<Rikayon>().TakeDamage(damageAmount);
        }
    }
}
