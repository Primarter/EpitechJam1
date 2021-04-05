using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] public int health = 100;

    void Update()
    {
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) {
            Destroy(this.gameObject);
            // Animator anim = GetComponent<Animator>();
            // if (anim) {
            //     anim.SetTrigger("Die");
            // } else
            //     Destroy(this.gameObject);
        }
    }

    public int getHealth()
    {
        return this.health;
    }

    public void Heal(int heal)
    {
        health += heal;
    }
}
